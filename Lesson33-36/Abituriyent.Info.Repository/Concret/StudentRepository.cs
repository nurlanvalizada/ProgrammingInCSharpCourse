using System;
using System.Linq;
using System.Linq.Expressions;
using Abituriyent.Info.Core.Domain;
using Abituriyent.Info.Repository.Abstract;
using Abituriyent.Info.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace Abituriyent.Info.Repository.Concret
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(DbContext context) : base(context) { }

        public Student GetSingleWithoutImage(Expression<Func<Student, bool>> predicate)
        {
            IQueryable<Student> query = Context.Set<Student>();
            query = query.Where(predicate).Select(s => new Student
            {
                Id = s.Id,
                Address = s.Address,
                DateOfBirth = s.DateOfBirth,
                FatherName = s.FatherName,
                GroupId = s.GroupId,
                HomePhone = s.HomePhone,
                MobilePhone = s.MobilePhone,
                PersonId = s.PersonId,
                SchoolId = s.SchoolId,
                Person = s.Person
            });
           
            return query.SingleOrDefault();
        }

        public Tuple<string, byte[]> GetStudentImage(int id)
        {
            return
                Context.Set<Student>()
                    .Where(s => s.Id == id)
                    .Select(s => new Tuple<string, byte[]>(s.ImageContentType, s.Image))
                    .SingleOrDefault();
        }

        public Tuple<string, byte[]> GetStudentImageByPersonId(int id)
        {
            return
                Context.Set<Student>()
                    .Where(s => s.PersonId == id)
                    .Select(s => new Tuple<string, byte[]>(s.ImageContentType, s.Image))
                    .SingleOrDefault();
        }

        public void UpdateExceptImage(Student entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.Entry(entity).Property(e => e.Image).IsModified = false;
            Context.Entry(entity).Property(e => e.ImageContentType).IsModified = false;
        }
    }
}