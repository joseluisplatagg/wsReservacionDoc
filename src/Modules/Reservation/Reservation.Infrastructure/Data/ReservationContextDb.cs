using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Reservation.Domain.Common;
using SharedKernel.API.Middlewares;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Infrastructure.Data
{
    public class ReservationContextDb(DbContextOptions<ReservationContextDb> options, ICurrentUserProvider currentUserProvider) : DbContext(options)
    {
        private readonly ICurrentUserProvider _currentUserProvider = currentUserProvider;
        //public DbSet<EcmIdempotencyRecord> IdempotencyRecords { get; set; }
        // Sobreescribir el metodo SaveChangesAsync para que se actualicen las propiedades de auditoria
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var currentUserId = _currentUserProvider.Email;
            foreach (var entry in ChangeTracker.Entries<BaseDomainModel>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.MarkAsCreated(currentUserId);
                        break;
                    case EntityState.Modified:
                        entry.Entity.MarkAsUpdated(currentUserId);
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ReservationContextDb).Assembly);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var properties = entityType.GetProperties()
                    .Where(p => p.ClrType == typeof(DateTime) || p.ClrType == typeof(DateTime?));

                foreach (var property in properties)
                {
                    property.SetColumnType("timestamp with time zone");
                }
            }
        }
    }
}
