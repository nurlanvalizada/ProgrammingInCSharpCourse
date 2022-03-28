using System.Threading.Tasks;
using Lesson30_WebApi.Data;
using Lesson30_WebApi.Data.Entitites;
using Lesson30_WebApi.Repository;

namespace Lesson30_WebApi.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRepository<Student, int> StudentRepository { get; set; }
        public ICourseRepository CourseRepository { get; set; }

        private readonly StudentDbContext _studentDbContext;

        public UnitOfWork(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;

            StudentRepository = new EfRepository<Student, int>(studentDbContext);
            CourseRepository = new CourseRepository(studentDbContext);
        }
       
        public async Task Commit()
        {
            await _studentDbContext.SaveChangesAsync();
        }
    }
}