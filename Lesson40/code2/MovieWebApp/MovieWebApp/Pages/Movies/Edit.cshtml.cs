using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieWebApp.Data;
using MovieWebApp.Models;
using MovieWebApp.Models.Dtos;

namespace MovieWebApp.Pages.Movies
{
    public class EditModel : PageModel
    {
        private readonly MovieWebAppContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;

        public EditModel(MovieWebAppContext context,
                         IMapper mapper,
                         IWebHostEnvironment environment)
        {
            _context = context;
            _mapper = mapper;
            _environment = environment;
        }
        
        public List<SelectListItem> GenreList { get; set; } = new();

        [BindProperty]
        public MovieModel Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieEntity = await _context.Movie.FirstOrDefaultAsync(m => m.ID == id);
            
            if (movieEntity == null)
            {
                return NotFound();
            }

            Movie = _mapper.Map<MovieModel>(movieEntity);
            
            foreach (Genre genreEnum in Enum.GetValues(typeof(Genre)))
                GenreList.Add(new SelectListItem() { Text = genreEnum.ToString(), Value = ((int)genreEnum). ToString() });
            
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            var movieEntity = _mapper.Map<Movie>(Movie);

            if(Movie.Image != null)
            {
                var directory = Path.Combine(_environment.WebRootPath, "uploads", "images");
                if(Directory.Exists(directory) == false)
                {
                    Directory.CreateDirectory(directory);
                }
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(Movie.Image.FileName);

                await using (var fileStream = new FileStream(Path.Combine(directory, fileName), FileMode.Create))
                {
                    await Movie.Image.CopyToAsync(fileStream);
                }
                
                movieEntity.ImageUrl = fileName;
            }

            _context.Attach(movieEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(movieEntity.ID))
                {
                    return NotFound();
                }

                throw;
            }

            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPostImageDeleteAsync(int movieId)
        {
            var movieEntity = await _context.Movie.FindAsync(movieId);
            
            if(movieEntity == null) return RedirectToPage("./Index");
            
            var fileFullUrl = Path.Combine(_environment.WebRootPath, "uploads", "images", movieEntity.ImageUrl);
            if(System.IO.File.Exists(fileFullUrl))
            {
                System.IO.File.Delete(fileFullUrl);
            }
            movieEntity.ImageUrl = null;
            _context.Movie.Update(movieEntity);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        
        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.ID == id);
        }
    }
}
