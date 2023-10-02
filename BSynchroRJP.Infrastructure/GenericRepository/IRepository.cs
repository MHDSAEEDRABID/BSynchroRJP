using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BSynchroRJP.Infrastructure.GenericRepository
{
    public interface IRepository<TEntity,TKey>
    {
        Task<TEntity> GetAsync(
        [NotNull] Expression<Func<TEntity, bool>> predicate,
        bool includeDetails = true,
        CancellationToken cancellationToken = default
        );

        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> InsertAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);
    }
}
