using System;
using System.Linq;
using System.Linq.Expressions;
using Abituriyent.Info.Core.Domain;
using Abituriyent.Info.Repository.Base;

namespace Abituriyent.Info.Repository.Abstract
{
    public interface INewsRepository : IRepository<News>
    {
        IQueryable<News> FindNewsWithoutFullContent(Expression<Func<News, bool>> predicate);
    }
}