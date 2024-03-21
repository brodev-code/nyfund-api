using NyFund.Data.DataAccessLayer.Database;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using NyFund.Core.Framework.DataAccessLayer.EntityCore.Repository;
using NyFund.Core.Framework.Base;

namespace NyFund.Data.DataAccessLayer.EntityCore.Repository
{
    public partial class EntityRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        public readonly DbContextBase dbContext;
        protected DbSet<TEntity> DbSet { get; }

        public EntityRepository(DbContextBase dbContext)
        {
            this.dbContext = dbContext;
            DbSet = this.dbContext.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public void Add(List<TEntity> entities)
        {
            DbSet.AddRange(entities);
        }

        public Task AddAsync(TEntity entity)
        {
            return DbSet.AddAsync(entity).AsTask();
        }

        public Task AddAsync(List<TEntity> entities)
        {
            return DbSet.AddRangeAsync(entities);
        }

        public int Count(Expression<Func<TEntity, bool>> predicate = null)
        {
            return DbSet.Count(predicate);
        }

        public Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            return DbSet.CountAsync(predicate);
        }

        public void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public void Delete(List<TEntity> entities)
        {
            DbSet.RemoveRange(entities);
        }

        public Task DeleteAsync(TEntity entity)
        {
            Delete(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(List<TEntity> entities)
        {
            Delete(entities);
            return Task.CompletedTask;
        }

        public void Update(TEntity entity)
        {
            DbSet.Update(entity);
        }

        public void Update(List<TEntity> entities)
        {
            DbSet.UpdateRange(entities);
        }

        public Task UpdateAsync(TEntity entity)
        {
            Update(entity);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(List<TEntity> entities)
        {
			DbSet.UpdateRange(entities);
            return Task.CompletedTask;
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            var query = CreateQuery(predicate: predicate, include: include);
            return query?.SingleOrDefault();
        }

        public TResult Get<TResult>(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, Expression<Func<TEntity, TResult>> selector = null)
        {
            var query = CreateQuery(predicate: predicate, include: include);
            return query.Select(selector).SingleOrDefault();
        }

        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            var query = CreateQuery(predicate: predicate, include: include);
            return query.SingleOrDefaultAsync();
        }

        public Task<TResult> GetAsync<TResult>(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, Expression<Func<TEntity, TResult>> selector = null)
        {
            var query = CreateQuery(predicate: predicate, include: include);
            return query.Select(selector).SingleOrDefaultAsync();
        }

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            var query = CreateQuery(predicate, orderBy, include);
            return query.ToList();
        }

        public IEnumerable<TResult> GetList<TResult>(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, Expression<Func<TEntity, TResult>> selector = null)
        {
            var query = CreateQuery(predicate, orderBy, include);
            return query.Select(selector).ToList();
        }

        public async Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            var query = CreateQuery(predicate, orderBy, include);
            return await query.ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<TResult>> GetListAsync<TResult>(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, Expression<Func<TEntity, TResult>> selector = null)
        {
            var query = CreateQuery(predicate, orderBy, include);
            return await query.Select(selector).ToListAsync().ConfigureAwait(false);
        }

        public IEnumerable<TEntity> GetPagedList(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, int skip = 0, int take = 20)
        {
            var query = CreateQuery(predicate, orderBy, include);
            return query.Skip(skip).Take(take).ToList();
        }

        public IEnumerable<TResult> GetPagedList<TResult>(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, Expression<Func<TEntity, TResult>> selector = null, int skip = 0, int take = 20)
        {
            var query = CreateQuery(predicate, orderBy, include);
            return query.Skip(skip).Take(take).Select(selector).ToList();
        }

        public async Task<IEnumerable<TEntity>> GetPagedListAsync(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, int skip = 0, int take = 20)
        {
            var query = CreateQuery(predicate, orderBy, include);
            return await query.Skip(skip).Take(take).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<TResult>> GetPagedListAsync<TResult>(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, Expression<Func<TEntity, TResult>> selector = null, int skip = 0, int take = 20)
        {
            var query = CreateQuery(predicate, orderBy, include);
            return await query.Skip(skip).Take(take).Select(selector).ToListAsync().ConfigureAwait(false);
        }

        public IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> predicate = null,
                                            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                            bool disableTracking = true)
        {
            IQueryable<TEntity> query = DbSet;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return query;
        }
        protected IQueryable<TEntity> CreateQuery(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true)
        {
            IQueryable<TEntity> query = DbSet;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return query;
        }
    }
}
