using Lesson30_WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson30_WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private readonly ISingletonOperation _singletonOperation;
        private readonly ITransientOperation _transientOperation;
        private readonly IServiceProvider _serviceProvider;

        public StudentController(
            ISingletonOperation singletonOperation,
            ITransientOperation transientOperation,
            IServiceProvider serviceProvider)
        {
            _singletonOperation = singletonOperation;
            _transientOperation = transientOperation;
            _serviceProvider = serviceProvider;
        }

        private static List<Student> _students = new List<Student>();

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
        public List<Student> GetAll() 
        {
            return _students;
        }

        [HttpGet("student/{id}")]
        public IActionResult GetStudent(int id, string name, int age)
        {
            var request = Request;
            var context = HttpContext;
            var user = User;

            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost("create")]
        public IActionResult CreateStudent([FromBody] Student student)
        {
            _students.Add(student);
            return Created($"/api/student/student/{student.Id}", student);
        }

        [HttpPut("update")]
        public Student UpdateStudent(int id, Student newStudent)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            student.Name = newStudent.Name;

            return newStudent;
        }

        [HttpDelete("delete")]
        public Student DeleteStudent(int id) 
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            _students.Remove(student);

            return student;
        }
    }
}
