using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieWebApp.Data;
using MovieWebApp.Models;

namespace MovieWebApp.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly MovieWebAppContext _context;

        public CreateModel(MovieWebAppContext context)
        {
            _context = context;
        }
        
        public List<SelectListItem> GenreList { get; set; } = new();

        public IActionResult OnGet()
        {
            foreach (Genre genreEnum in Enum.GetValues(typeof(Genre)))
                GenreList.Add(new SelectListItem() { Text = genreEnum.ToString(), Value = ((int)genreEnum). ToString() });
            
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Movie.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
