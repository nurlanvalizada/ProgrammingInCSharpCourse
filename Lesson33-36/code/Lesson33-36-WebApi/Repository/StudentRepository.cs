using System.Collections.Generic;
using System.Threading.Tasks;
using Lesson30_WebApi.Data;
using Lesson30_WebApi.Data.Entitites;
using Microsoft.EntityFrameworkCore;

namespace Lesson30_WebApi.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDbContext _context;
        public StudentRepository(StudentDbContext context)
        {
            _context = context;
        }
        public async Task<Student> Add(Student entity)
        {
            await _context.Students.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Student> Delete(int id)
        {
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> Get(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> Update(Student entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}