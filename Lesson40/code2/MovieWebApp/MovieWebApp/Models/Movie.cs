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
        public Genre Genre { get; set; }
        
        [Range(10, 10000, ErrorMessage = "Price is not correct")]
        public double Price { get; set; }
        
        [MaxLength(1000)]
        public string Description { get; set; }
    }

    public enum Genre : byte
    {
        Comedy,
        Action,
        Romance,
        Horror,
        Thriller,
        Drama,
        Documentary,
        Animation,
        Family,
        Fantasy,
        Adventure,
        Mystery,
        SciFi,
        Western,
        War
    }
}
