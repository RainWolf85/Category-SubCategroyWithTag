using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Services.Contracts;
using Data;

namespace Services.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext DbContext;

        public DbSet<TEntity> Entities { get; }
        public virtual IQueryable<TEntity> Table => Entities;
        public virtual IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();

        public Repository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
            Entities = DbContext.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true)
        {
            await Entities.AddAsync(entity, cancellationToken);
            if (saveNow)
            {
                await DbContext.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true)
        {
            await Entities.AddRangeAsync(entities, cancellationToken);
            if (saveNow)
            {
                await DbContext.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true)
        {
            Entities.Remove(entity);
            if (saveNow)
            {
                await DbContext.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true)
        {
            Entities.RemoveRange(entities);
            if (saveNow)
            {
                await DbContext.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<TEntity> GetByIdAsync(CancellationToken cancellationToken, params object[] ids)
        {
            if (ids == null) return null;

            return await Entities.FindAsync(ids, cancellationToken);
        }

        public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true)
        {
            Entities.Update(entity);
            if (saveNow)
            {
                await DbContext.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true)
        {
            Entities.UpdateRange(entities);
            if (saveNow)
            {
                await DbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}