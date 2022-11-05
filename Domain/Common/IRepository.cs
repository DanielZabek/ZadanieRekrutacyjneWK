using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Employees
{
    public interface IRepository<TEntity, in TKey> where TEntity : IAggregateRoot<TKey>
    {
        Task<TEntity> GetByIdAsync(TKey id, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    }
}
