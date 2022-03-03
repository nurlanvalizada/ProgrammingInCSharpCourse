using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lesson30_WebApi.Data.Entitites
{
    public class StudentCourse
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public int StudentTestId { get; set; }
        [ForeignKey(nameof(StudentTestId))]
        public Student Student { get; set; }

        [ForeignKey(nameof(Course))]
        public int CoursexId { get; set; }
        public Course Course { get; set; }
    }
}
