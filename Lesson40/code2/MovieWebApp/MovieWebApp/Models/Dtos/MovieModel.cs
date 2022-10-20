using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace MovieWebApp.Models.Dtos;

public class MovieModel
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
    
    public string ImageUrl { get; set; }
        
    public IFormFile Image { get; set; }
}