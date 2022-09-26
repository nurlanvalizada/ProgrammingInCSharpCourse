using System;
using System.ComponentModel.DataAnnotations;

namespace MovieWebApp.Models
{
    public class Movie
    {
        public int ID { get; set; }
        
        [StringLength(30, MinimumLength = 5)]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        
        [Range(10, 10000, ErrorMessage = "Price is not correct")]
        public decimal Price { get; set; }
    }
}
