using System.Linq;
using System.Threading.Tasks;
using Lesson30_WebApi.Data;
using Lesson30_WebApi.Data.Entitites;
using Microsoft.EntityFrameworkCore;

namespace Lesson30_WebApi.Repository
{
    public interface ICourseRepository : IRepository<Course, int>
    {
        Task<Course> FindByName(string name);
    }

    public class CourseRepository : EfRepository<Course, int>, ICourseRepository
    {
        private readonly StudentDbContext _studentDbContext;

        public CourseRepository(StudentDbContext studentDbContext) : base(studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }

        public async Task<Course> FindByName(string name)
        {
            var course = await _studentDbContext.Set<Course>()
                .Where(c => c.Name.Contains(name))
                .FirstOrDefaultAsync();
            return course;
        }
    }
}