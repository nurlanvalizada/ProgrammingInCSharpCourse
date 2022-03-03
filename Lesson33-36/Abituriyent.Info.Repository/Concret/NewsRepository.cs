using System;
using System.Linq;
using System.Linq.Expressions;
using Abituriyent.Info.Core.Domain;
using Abituriyent.Info.Repository.Abstract;
using Abituriyent.Info.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace Abituriyent.Info.Repository.Concret
{
    public class NewsRepository : Repository<News>, INewsRepository
    {
        public NewsRepository(DbContext context) : base(context) { }

        public IQueryable<News> FindNewsWithoutFullContent(Expression<Func<News, bool>> predicate)
        {
            IQueryable<News> query = Context.Set<News>();
            query = query.Select(n => new News
            {
                Id = n.Id,
                AdminId = n.AdminId,
                PublishDate = n.PublishDate,
                ImageUrl = n.ImageUrl,
                Title = n.Title,
                ShortContent = n.ShortContent
            }).Where(predicate);
            return query;
        }
    }
}