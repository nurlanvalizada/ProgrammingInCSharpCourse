using System.Collections.Generic;
using System.Threading.Tasks;
using Lesson30_WebApi.Data.Entitites;

namespace Lesson30_WebApi.Repository
{
    public interface IStudentRepository
    {
        Task<Student> Get(int id);

        Task<IEnumerable<Student>> GetAll();

        Task<Student> Add(Student entity);

        Task<Student> Delete(int id);

        Task<Student> Update(Student bookEntity);
    }
}
