using System;
using System.Linq;
using System.Linq.Expressions;

namespace Abituriyent.Info.Repository.Base
{
    public interface IRepository<TEntity> : IDisposable
    {
        IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeProperties);

        TEntity GetSingle(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);

        bool Any(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);

        int Count();

        int Count(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        IQueryable<TEntity> DeleteWhere(Expression<Func<TEntity, bool>> predicate);
    }
}
