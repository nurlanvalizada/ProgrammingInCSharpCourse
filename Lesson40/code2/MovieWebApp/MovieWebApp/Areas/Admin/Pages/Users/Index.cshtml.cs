using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MovieWebApp.Models.Admin;

namespace MovieWebApp.Areas.Admin.Pages.Users;

public class IndexModel : PageModel
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IMapper _mapper;

    public IndexModel(UserManager<IdentityUser> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }
    
    [BindProperty]
    public IList<UserModel> Users { get; set; }

    public async Task OnGetAsync()
    {
        var allUsers = await _userManager.Users.ToListAsync();
        Users = _mapper.Map<List<UserModel>>(allUsers);
    }
    
    public async Task<IActionResult> OnPostDeleteAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        
        if(user == null) return RedirectToPage();
        
        await _userManager.DeleteAsync(user);

        return RedirectToPage();
    }
}