using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public interface IGenericRepository<TEntity, in TKey>: IDisposable where TEntity: IEntity 
    {
        Task<IEnumerable<TEntity>> GetAll(CancellationToken cancellationToken = default(CancellationToken));
        Task<TEntity> GetById(TKey id, CancellationToken cancellationToken = default(CancellationToken));
        Task<TEntity> Insert(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));        
        TEntity Update(TEntity entity, TKey id, CancellationToken cancellationToken = default(CancellationToken));
        void Delete(TKey id);
        void Delete(Func<TEntity, Boolean> where);
        IEnumerable<TEntity> GetMany(Func<TEntity, bool> where);
        Task<IEnumerable<TEntity>> GetManyQueryable(Func<TEntity, bool> where);
        Task<IEnumerable<TEntity>> Pagination(int top, int skip, Func<TEntity, object> orderBy, bool ascending = true, CancellationToken cancellationToken = default(CancellationToken));
        TEntity Get(Func<TEntity, Boolean> where);
        Task<IEnumerable<TEntity>> GetWithInclude(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate, params string[] include);
        bool Exists(int id);
        TEntity GetSingle(Func<TEntity, bool> predicate);
        TEntity GetFirst(Func<TEntity, bool> predicate);
    }
}

    
