using System.Threading.Tasks;
using Lesson30_WebApi.Data.Entitites;
using Lesson30_WebApi.Repository;

namespace Lesson30_WebApi.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IRepository<Student, int> StudentRepository { get; set; }
        public ICourseRepository CourseRepository { get; set; }
        public Task Commit();
    }
}
