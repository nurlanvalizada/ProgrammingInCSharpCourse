using System;
using System.Linq.Expressions;
using Abituriyent.Info.Core.Domain;
using Abituriyent.Info.Repository.Base;

namespace Abituriyent.Info.Repository.Abstract
{
    public interface IStudentRepository : IRepository<Student>
    {
        Student GetSingleWithoutImage(Expression<Func<Student, bool>> predicate);

        Tuple<string, byte[]> GetStudentImage(int id);
        Tuple<string, byte[]> GetStudentImageByPersonId(int id);

        void UpdateExceptImage(Student entity);
    }
}