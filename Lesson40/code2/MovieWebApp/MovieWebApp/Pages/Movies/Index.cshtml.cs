using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MovieWebApp.Data;
using MovieWebApp.Models.Dtos;

namespace MovieWebApp.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly MovieWebAppContext _context;
        private readonly IMapper _mapper;

        public IndexModel(MovieWebAppContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IList<MovieModel> Movies { get;set; }

        public async Task OnGetAsync()
        {
            Movies = _mapper.Map<IList<MovieModel>>(await _context.Movie.ToListAsync());
        }
    }
}
