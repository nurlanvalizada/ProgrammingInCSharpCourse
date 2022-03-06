using System;
using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace Lesson30_WebApi.Models
{
    public class StudentModel
    {
        public int Id { get; set; }

        //[RegularExpression("")]
        //[Required]
        //[MaxLength(10)]
        public string Name { get; set; }

        //[Required]
        //[MinLength(5)]
        public string Surname { get; set; }

        //[Range(100,1000)]
        public double? Salary { get; set; }

        public DateTime DateOfBirth { get; set; }

        //[Required]
       // [Range(1,3)]
        public int GenderId { get; set; }
    }

    public class StudentValidator : AbstractValidator<StudentModel>
    {
        public StudentValidator()
        {
            RuleFor(x => x.Name).Length(1, 10);
            RuleFor(x => x.Surname).Length(min:10, max:40);
            RuleFor(x => x.Salary).InclusiveBetween(100, 1000);
            RuleFor(x => x.GenderId).InclusiveBetween(1, 3);
            RuleFor(x => x.GenderId).GreaterThan(1);
        }
    }
}
