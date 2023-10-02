using BSynchroRJP.Domain.Base;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BSynchroRJP.Infrastructure.GenericRepository
{
    public class EfCoreRepository<TDbContext, TEntity,TKey>  : IRepository<TEntity,TKey>
    where TDbContext : DbContext
    where TEntity : BaseEntity
    {
        protected virtual TDbContext dbContext { get; set; }

        public async Task<TEntity> GetAsync(
        [NotNull] Expression<Func<TEntity, bool>> predicate,
        bool includeDetails = true,
        CancellationToken cancellationToken = default
        )
        {
            var  query =  dbContext.Set<TEntity>().AsQueryable();

            if (includeDetails)
                query = query.Include(x => x is BaseEntity || x is ICollection<BaseEntity>);

            var entity  = await query.SingleOrDefaultAsync(predicate);

            if (entity is null)
            {
                throw new KeyNotFoundException("The Key is not Exist");
            }

            return entity;
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            await dbContext.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            dbContext.Update(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(TEntity entity)
        {
            dbContext.Remove(entity);
            await dbContext.SaveChangesAsync();
        }




        
    }
}
