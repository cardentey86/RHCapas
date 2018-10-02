using Core.Entity;
using Core.Interfaces;
using Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : Entity<TKey>
    {

        internal RHDbContext _context;
        internal DbSet<TEntity> DbSet;


        public GenericRepository(RHDbContext context)
        {
            this._context = context;
            this.DbSet = _context.Set<TEntity>();
        }
       
        public void Delete(TKey id)
        {
            TEntity entityToDelete = DbSet.Find(id);

            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            DbSet.Remove(entityToDelete);
        }       

        public virtual async Task<TEntity> GetById(TKey id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll(CancellationToken cancellationToken = default(CancellationToken))
        {
            IQueryable<TEntity> query = DbSet;
            return await query.ToListAsync();
        }

        public virtual async Task<TEntity> Insert(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                entity.CreatedDate = DateTime.UtcNow;
                entity.ModifiedDate = DateTime.UtcNow;
                await DbSet.AddAsync(entity);
            }
            catch (Exception ex)
            {
                throw new EntityException(entity, "Insert failed because the entity already exists!", ex);
            }

            return entity;
        }

        public Task<IEnumerable<TEntity>> Pagination(int top, int skip, Func<TEntity, object> orderBy, bool ascending = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public virtual TEntity Update(TEntity entity, TKey id, CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {                
                entity.ModifiedDate = DateTime.UtcNow;
                DbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw new EntityException(entity, "Insert failed because the entity already exists!", ex);
            }

            return entity;
        }

        public virtual IEnumerable<TEntity> GetMany(Func<TEntity, bool> where)
        {
            return DbSet.Where(where).ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> GetManyQueryable(Func<TEntity, bool> where)
        {

            IQueryable<TEntity> query = DbSet.Where(where).AsQueryable();
            return await query.ToListAsync();
        }

        public TEntity Get(Func<TEntity, Boolean> where)
        {
            return DbSet.Where(where).FirstOrDefault<TEntity>();
        }

        public void Delete(Func<TEntity, Boolean> where)
        {
            IQueryable<TEntity> objects = DbSet.Where<TEntity>(where).AsQueryable();
            foreach (TEntity obj in objects)
                DbSet.Remove(obj);
        }

        //public virtual async Task<IEnumerable<TEntity>> GetAll()
        //{
        //    return await DbSet.ToListAsync();
        //}

        public async Task<IEnumerable<TEntity>> GetWithInclude(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate, params string[] include)
        {
            IQueryable<TEntity> query = this.DbSet;
            query = include.Aggregate(query, (current, inc) => current.Include(inc));
            var result = query.Where(predicate);
            return await result.ToListAsync();
        }

        public bool Exists(int id)
        {
            return DbSet.Find(id) != null;
        }

        public TEntity GetSingle(Func<TEntity, bool> predicate)
        {
            return DbSet.Single<TEntity>(predicate);
        }

        public TEntity GetFirst(Func<TEntity, bool> predicate)
        {
            return DbSet.FirstOrDefault<TEntity>(predicate);
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
