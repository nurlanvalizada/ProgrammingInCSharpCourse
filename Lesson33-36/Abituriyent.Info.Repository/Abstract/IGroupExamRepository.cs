using Abituriyent.Info.Core.Domain;
using Abituriyent.Info.Repository.Base;

namespace Abituriyent.Info.Repository.Abstract
{
    public interface IGroupExamRepository : IRepository<GroupExam>
    {
        bool IsExamAvailable(int studentGroupId, int examId);
    }
}