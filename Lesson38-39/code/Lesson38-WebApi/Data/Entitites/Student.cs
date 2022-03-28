using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lesson30_WebApi.Data.Entitites
{
    public class Student : BaseEntity<int>, ISoftDelete
    {
        [Key]
        public override int Id { get; set; }

        [MaxLength(20)]
        public string Name { get; set; }

        [StringLength(30, MinimumLength = 19)]
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public double? Salary { get; set; }

        [ForeignKey(nameof(Gender))]
        public int? GendexrId { get; set; }

        public Gender Gender { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }
        public bool IsDeleted { get; set; }
    }
}
