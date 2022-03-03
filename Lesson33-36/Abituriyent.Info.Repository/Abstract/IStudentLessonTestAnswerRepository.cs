using Abituriyent.Info.Core.Domain;
using Abituriyent.Info.Repository.Base;

namespace Abituriyent.Info.Repository.Abstract
{
    public interface IStudentLessonTestAnswerRepository : IRepository<StudentLessonTestAnswer>
    {
        bool IsAlreadyAnswered(int studentId, int lessonId);
    }
}