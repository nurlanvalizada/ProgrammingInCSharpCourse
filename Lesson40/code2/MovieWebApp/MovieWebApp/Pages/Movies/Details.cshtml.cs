using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MovieWebApp.Data;
using MovieWebApp.Models;
using MovieWebApp.Models.Dtos;

namespace MovieWebApp.Pages.Movies
{
    [Authorize(Policy = "WithPassport")]
    public class DetailsModel : PageModel
    {
        private readonly MovieWebAppContext _context;
        private readonly IMapper _mapper;

        public DetailsModel(MovieWebAppContext context,
                            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public MovieModel Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = _mapper.Map<MovieModel>(await _context.Movie.FirstOrDefaultAsync(m => m.ID == id));

            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
