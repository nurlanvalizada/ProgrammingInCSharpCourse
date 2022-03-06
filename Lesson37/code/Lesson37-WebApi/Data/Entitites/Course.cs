using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lesson30_WebApi.Data.Entitites
{
    [Table("tblCourse")]
    public class Course : BaseEntity<int>
    {
        [Key]
        public override int Id { get; set; }

        [MaxLength(20)]
        [Required]
        public string Name { get; set; }

        [Column("CreatedDate", TypeName = "datetime")]
        public DateTime? CreationTime { get; set; }

        [NotMapped]
        public string OnlyForCsharpSide { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
