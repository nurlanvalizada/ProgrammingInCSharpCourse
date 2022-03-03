using System;
using System.Linq;
using System.Linq.Expressions;
using Abituriyent.Info.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Abituriyent.Info.Repository.Base
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        public IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Context.Set<T>();
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Context.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return query.FirstOrDefault(predicate);
        }
        
        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Any(predicate);
        }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Context.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return query.Where(predicate);
        }

        public virtual int Count()
        {
            return Context.Set<T>().Count();
        }

        public virtual int Count(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Count(predicate);
        }

        public virtual void Add(T entity)
        {
            EntityEntry dbEntityEntry = Context.Entry(entity);
            dbEntityEntry.State=EntityState.Added;
        }
       
        public virtual void Update(T entity)
        {
            EntityEntry dbEntityEntry = Context.Entry(entity);
            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            EntityEntry dbEntityEntry = Context.Entry(entity);
            dbEntityEntry.State = EntityState.Deleted;
        }

        public IQueryable<T> DeleteWhere(Expression<Func<T, bool>> predicate)
        {
            var entities = Context.Set<T>().Where(predicate);

            foreach (var entity in entities)
                Context.Entry(entity).State = EntityState.Deleted;

            return entities;
        }

        public virtual void Dispose()
        {
            if (Context == null) return;
            Context.Dispose();
            Context = null;
        }
    }
}