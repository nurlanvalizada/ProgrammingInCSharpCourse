using Lesson30_WebApi.Configurations;
using Lesson30_WebApi.Data.Entitites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;
using Lesson30_WebApi.UnitOfWork;

namespace Lesson30_WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private readonly ISingletonOperation _singletonOperation;
        private readonly ITransientOperation _transientOperation;
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;
        private readonly PositionOptions _positionOptions;
        private readonly IUnitOfWork _unitOfWork;

        public StudentController(
            ISingletonOperation singletonOperation,
            ITransientOperation transientOperation,
            IServiceProvider serviceProvider,
            IConfiguration configuration,
            IOptions<PositionOptions> positionAccessor,
            IUnitOfWork unitOfWork)

        {
            _singletonOperation = singletonOperation;
            _transientOperation = transientOperation;
            _serviceProvider = serviceProvider;
            _configuration = configuration;
            _positionOptions = positionAccessor.Value;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("Guid")]
        public object GetGuids()
        {
            var scopedOperation1 = (IScopedOperation)_serviceProvider.GetService(typeof(IScopedOperation));
            var transientOperation1 = (ITransientOperation)_serviceProvider.GetService(typeof(ITransientOperation));

            var scopedOperation2 = (IScopedOperation)_serviceProvider.GetService(typeof(IScopedOperation));
            var transientOperation2 = (ITransientOperation)_serviceProvider.GetService(typeof(ITransientOperation));

            var data = new
            {
                Singlton = _singletonOperation.Id,
                Transient1 = transientOperation1.Id,
                Scoped1 = scopedOperation1.Id,
                Transient2 = transientOperation2.Id,
                Scoped2 = scopedOperation2.Id
            };

            return data;
        }


        [HttpGet("all")]
        public async Task<object> GetAll()
        {
            var query = await _unitOfWork.StudentRepository.GetAllList();

            return query.ToList();
        }

        //[HttpGet("studentCourseReport")]
        //public async Task<object> GetReport()
        //{
        //    //var query = from sc in _studentDbContext.StudentCourses
        //    //            join s in _studentDbContext.Students on sc.StudentId equals s.Id
        //    //            join c in _studentDbContext.Courses on sc.CourseId equals c.Id
        //    //            join g in _studentDbContext.Genders on s.GenderId equals g.Id
        //    //            select new
        //    //            {
        //    //                s.Name,
        //    //                s.Surname,
        //    //                s.DateOfBirth,
        //    //                GenderName = g.Name,
        //    //                CourseName = c.Name,
        //    //                sc.StartDate,
        //    //                sc.EndDate
        //    //            };

        //    //await _studentDbContext.Database.ExecuteSqlRawAsync("insert into tblGender values (4, 'Unknown')");

        //    var query = _studentDbContext.StudentCourseQueries.FromSqlRaw(
        //        @"select s.Name, s.Surname, s.DateOfBirth, c.Name CourseName, sc.StartDate, sc.EndDate from tblStudentCourse sc
        //        join tblStudent s on sc.StudentId = s.Id
        //        join tblCourse c on sc.CourseId = c.Id");

        //    return await query.ToListAsync();
        //}

        //[HttpGet("genders")]
        //public async Task<object> GetGenders()
        //{
        //    var genders = await _studentDbContext.Genders.Include(g => g.Students).Select(g => new
        //    {
        //        g.Name,
        //        Students = g.Students.Select(s => new
        //        {
        //            s.Name,
        //            s.Surname,
        //            s.Salary,
        //            s.DateOfBirth
        //        })
        //    }).ToListAsync();

        //    return genders;
        //}

        [HttpGet("student/{id}")]
        public async Task<IActionResult> GetStudent(int id, string name, int age)
        {
            var student = await _unitOfWork.StudentRepository.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateStudent([FromBody] Student student)
        {
            await _unitOfWork.StudentRepository.Add(student);
            await _unitOfWork.Commit();

            return Created($"/api/student/student/{student.Id}", student);
        }

        [HttpPut("update")]
        public async Task<Student> UpdateStudent(int id, Student newStudent)
        {
            var student = await _unitOfWork.StudentRepository.Find(id);

            student.Name = newStudent.Name;
            student.Salary = newStudent.Salary;

            await _unitOfWork.StudentRepository.Update(student);
            await _unitOfWork.Commit();

            return student;
        }

        [HttpDelete("delete")]
        public async Task<Student> DeleteStudent(int id)
        {
            var student = await _unitOfWork.StudentRepository.Find(id);

            await _unitOfWork.StudentRepository.Delete(student);

            await _unitOfWork.Commit();

            return student;
        }

        [HttpGet("configs")]
        public object GetConfigurations()
        {
            var configurations = new
            {
                GeneralApiKey = _configuration["ApiKey"],
                SmsApiKey = _configuration["SmsApi:ApiKey"],
                FromNumber = _configuration["SmsApi:FromNumber"],
                PositionsOptions = _positionOptions
            };

            return configurations;
        }
    }
}
