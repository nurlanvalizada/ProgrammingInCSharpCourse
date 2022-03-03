using System.Collections.Generic;
using System.Linq;
using Abituriyent.Info.Core.Domain;
using Abituriyent.Info.Repository.Abstract;
using Abituriyent.Info.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace Abituriyent.Info.Repository.Concret
{
    public class StudentLessonRepository : Repository<StudentLesson>, IStudentLessonRepository
    {
        public StudentLessonRepository(DbContext context) : base(context) { }

        public int GetActiveStudentsCount(IEnumerable<int> courseLessonIds)
        {
            return Context.Set<StudentLesson>().Where(
                        stdLesson => courseLessonIds.Contains(stdLesson.CourseLessonId) && (stdLesson.EndDate == null))
                       .GroupBy(stdLesson => stdLesson.StudentId)
                       .Count();
        }
    }
}