using System.Collections.Generic;
using Abituriyent.Info.Core.Domain;
using Abituriyent.Info.Repository.Base;

namespace Abituriyent.Info.Repository.Abstract
{
    public interface IStudentLessonRepository : IRepository<StudentLesson>
    {
        int GetActiveStudentsCount(IEnumerable<int> lessonIds);
    }
}