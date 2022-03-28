using Lesson30_WebApi.Configurations;
using Lesson30_WebApi.Data.Entitites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Lesson30_WebApi.Helpers;
using Lesson30_WebApi.Models;
using Lesson30_WebApi.UnitOfWork;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

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
        private readonly ILogger<StudentController> _logger;

        public StudentController(
            ISingletonOperation singletonOperation,
            ITransientOperation transientOperation,
            IServiceProvider serviceProvider,
            IConfiguration configuration,
            IOptions<PositionOptions> positionAccessor,
            IUnitOfWork unitOfWork, 
            ILogger<StudentController> logger)

        {
            _singletonOperation = singletonOperation;
            _transientOperation = transientOperation;
            _serviceProvider = serviceProvider;
            _configuration = configuration;
            _positionOptions = positionAccessor.Value;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpGet("Guid")]
        [Authorize("SuperUser")]
        public object GetGuids()
        {
            var user = HttpContext.User;

            var isInAdminRole = user.IsInRole("Admin");

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
        [MyAuthorize]
        public async Task<object> GetAll()
        {
            var user = HttpContext.User;

            _logger.LogInformation("Request accepted at {date}", DateTime.Now);

            var query = await _unitOfWork.StudentRepository.GetAllList();

            var result = query.ToList();

            _logger.LogWarning("Request successfully completed at {date}, result: {result}", DateTime.Now, JsonSerializer.Serialize(result));

            return result;
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
            var user = HttpContext.User;

            var student = await _unitOfWork.StudentRepository.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> CreateStudent([FromBody] StudentModel studentModel, [FromServices]IOptions<ApiBehaviorOptions> apiBehaviour)
        {
            if (ModelState.IsValid)
            {
                var student = new Student
                {
                    DateOfBirth = studentModel.DateOfBirth,
                    Name = studentModel.Name,
                    Surname = studentModel.Surname,
                    Salary = studentModel.Salary,
                    GendexrId = studentModel.GenderId
                };

                await _unitOfWork.StudentRepository.Add(student);
                await _unitOfWork.Commit();

                return Created($"/api/student/student/{student.Id}", student);
            }

            return apiBehaviour.Value.InvalidModelStateResponseFactory(ControllerContext);
        }

        [AllowAnonymous]
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
            try
            {
                _logger.LogInformation("Request accepted to delete the student with id: {id}", id);

                var student = await _unitOfWork.StudentRepository.Find(id);

                _logger.LogDebug("Student is fetched from database successfully", id);

                await _unitOfWork.StudentRepository.Delete(student);

                await _unitOfWork.Commit();

                _logger.LogDebug("Student is deleted from db and transaction committed {id}", id);

                _logger.LogInformation("Request is successfully completed to delete the student: {id}", id);

                return student;
            }
            catch (Exception exc)
            {
              _logger.LogError(exc, "Error occurred when deleting the student with id {id}", id);
              throw;
            }
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
