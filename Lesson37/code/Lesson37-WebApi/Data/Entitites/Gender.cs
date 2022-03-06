using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lesson30_WebApi.Data.Entitites
{
    public class Gender : ISoftDelete
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int Idx { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public ICollection<Student> Students { get; set; }
        public bool IsDeleted { get; set; }
    }
}
