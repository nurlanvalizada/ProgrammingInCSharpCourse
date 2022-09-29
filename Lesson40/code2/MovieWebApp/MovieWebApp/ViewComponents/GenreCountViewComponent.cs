using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieWebApp.Data;
using MovieWebApp.Models;

namespace MovieWebApp.ViewComponents;

public class GenreCountViewComponent : ViewComponent
{
    private readonly MovieWebAppContext _context;

    public GenreCountViewComponent(MovieWebAppContext context)
    {
        _context = context;
    }
    
    public async Task<IViewComponentResult> InvokeAsync(Genre genre)
    {
        var result = await _context.Movie.Where(m => m.Genre == genre)
                                   .GroupBy(x => x.Genre)
                                   .Select(x => new GenreCountViewModel
                                   {
                                       Genre = x.Key,
                                       Count = x.Count()
                                   }).FirstOrDefaultAsync() ?? new GenreCountViewModel
        {
            Genre = genre,
            Count = 0
        };

        return View(result);
    }
}