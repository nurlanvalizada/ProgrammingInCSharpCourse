using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieWebApp.Data;
using MovieWebApp.Models;
using MovieWebApp.Models.Dtos;

namespace MovieWebApp.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly MovieWebAppContext _context;
        private IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;

        public CreateModel(MovieWebAppContext context,
                           IWebHostEnvironment webHostEnvironment,
                           IMapper mapper)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _mapper = mapper;
        }
        
        public List<SelectListItem> GenreList { get; set; } = new();

        public IActionResult OnGet()
        {
            foreach (Genre genreEnum in Enum.GetValues(typeof(Genre)))
                GenreList.Add(new SelectListItem() { Text = genreEnum.ToString(), Value = ((int)genreEnum). ToString() });
            
            return Page();
        }

        [BindProperty]
        public MovieModel Movie { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            var movie = _mapper.Map<Movie>(Movie);
            
            var folderName = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", "images");
            if(!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }
            
            var fileName = Guid.NewGuid() + Path.GetExtension(Movie.Image.FileName);
            var fileFullPath = Path.Combine(folderName, fileName);
            
            using (var fileStream = new FileStream(fileFullPath, FileMode.Create))
            {
                await Movie.Image.CopyToAsync(fileStream);
            }

            movie.ImageUrl = fileName;

            _context.Movie.Add(movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
