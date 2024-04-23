using NonameDictionary.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NonameDictionary.Api.Application.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task<int> AddAsync(TEntity Entity);
        int Add(TEntity Entity);
        int Add(IEnumerable<TEntity> Entity);
        Task<int> AddAsync(IEnumerable<TEntity> Entity);

        Task<int> UpdateAsync(TEntity Entity);
        int Update(TEntity Entity);

        Task<int> DeleteAsync(TEntity Entity);
        int Delete(TEntity Entity);
        Task<int> DeleteAsync(Guid id);
        int Delete(Guid id);
        bool DeleteRange(Expression<Func<TEntity, bool>> predicate);

        Task<int> AddOrUpdateAsync(TEntity Entity);
        int AddOrUpdate(TEntity Entity);

        IQueryable<TEntity> AsQueryable();
        Task<List<TEntity>> GetAll(bool noTracking = true);

        Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> predicate, bool noTracking = true, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> GetByIdAsync(Guid id,bool noTracking = true, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> predicate, bool noTracking = true, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, bool noTracking = true, params Expression<Func<TEntity, object>>[] includes);
        IQueryable<TEntity> Get (Expression<Func<TEntity, bool>> predicate, bool noTracking = true, params Expression<Func<TEntity, object>>[] includes);

        Task BulkDeleteById(IEnumerable<Guid> id);
        Task BulkDelete(Expression<Func<TEntity, bool>> predicate);
        Task BulkDelete(IEnumerable<TEntity> entities);
        Task BulkUpdate(IEnumerable<TEntity> entities);
        Task BulkAdd(IEnumerable<TEntity> entities);


    }
}
