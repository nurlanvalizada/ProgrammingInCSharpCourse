using Abituriyent.Info.Core.Domain;
using Abituriyent.Info.Repository.Abstract;
using Abituriyent.Info.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace Abituriyent.Info.Repository.Concret
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        private readonly ILessonRepository _lessonRepository;
        public CourseRepository(DbContext context, ILessonRepository lessonRepository) : base(context)
        {
            _lessonRepository = lessonRepository;
        }

        public int GetActiveStudentsCount(int courseId)
        {
            return _lessonRepository.GetActiveStudentsCount(courseId);
        }
    }
}