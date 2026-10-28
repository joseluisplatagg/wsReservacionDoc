using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Reservation.Application.Contracts.Data;
using Reservation.Domain.Common;
using Reservation.Infrastructure.Data.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Infrastructure.Data
{
    public class UnitOfWork(ReservationContextDb dbContext) : IUnitOfWork
    {
        private Hashtable? _repositories;
        private readonly ReservationContextDb _dbContext = dbContext;

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseDomainModel
        {
            _repositories ??= [];

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(BaseRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _dbContext);

                _repositories.Add(type, repositoryInstance);
            }

            return (IBaseRepository<TEntity>)_repositories[type]!;
        }

        public async Task<int> CompleteAsync()
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                var result = await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
                return result;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                await transaction.RollbackAsync();
                throw new InvalidOperationException("El registro ya no coincide con la versión de la base de datos (Error de concurrencia).", ex);
            }
            catch (DbUpdateException ex) when (ex.InnerException is PostgresException pgEx)
            {
                await transaction.RollbackAsync();
                var failures = new List<ValidationFailure>();
                switch (pgEx.SqlState)
                {
                    case "23503":
                        if (pgEx.MessageText.Contains("delete"))
                        {
                            failures.Add(new ValidationFailure("Id", "No se puede eliminar el registro porque tiene dependencias activas."));
                        }
                        else
                        {
                            failures.Add(new ValidationFailure("DocumentNameId", "Error de consistencia: El Id proporcionado no existe en el catálogo."));
                        }
                        break;

                    case "23505": // Único / Duplicado
                        failures.Add(new ValidationFailure("Name", "Operación duplicada: Ya existe un registro con estos datos únicos."));
                        break;

                    case "23502": // Not Null
                        failures.Add(new ValidationFailure(pgEx.ColumnName ?? "Campo", "Este campo es obligatorio y no puede quedar vacío."));
                        break;

                    default:
                        failures.Add(new ValidationFailure("Database", "Ocurrió un error inesperado al persistir los cambios relacionales."));
                        break;
                }
                throw new ValidationException(failures);
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
