using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieWebApp.Models;

namespace MovieWebApp.Data
{
    public class MovieWebAppContext : DbContext
    {
        public MovieWebAppContext (DbContextOptions<MovieWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; }
    }
}
