using Calendar.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar.Application.Contracts.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseDomainModel;

        Task<int> CompleteAsync();
    }
}
