using Login.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Login.Application.Contracts.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseDomainModel;

        Task<int> CompleteAsync();
    }
}
