using Abituriyent.Info.Core.Domain;
using Abituriyent.Info.Repository.Base;

namespace Abituriyent.Info.Repository.Abstract
{
    public interface ICourseRepository : IRepository<Course>
    {
        int GetActiveStudentsCount(int courseId);
    }
}