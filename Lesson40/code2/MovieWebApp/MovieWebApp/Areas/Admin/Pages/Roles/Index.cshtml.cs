using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MovieWebApp.Models.Admin;

namespace MovieWebApp.Areas.Admin.Pages.Roles;

public class RoleIndexModel : PageModel
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IMapper _mapper;

    public RoleIndexModel(RoleManager<IdentityRole> roleManager, IMapper mapper)
    {
        _roleManager = roleManager;
        _mapper = mapper;
    }
    
    [BindProperty]
    public IList<RoleModel> Roles { get; set; }

    public async Task OnGetAsync()
    {
        var allRoles = await _roleManager.Roles.AsNoTracking().ToListAsync();
        Roles = _mapper.Map<List<RoleModel>>(allRoles);
    }
    
    public async Task<IActionResult> OnPostDeleteAsync(string id)
    {
        var role = await _roleManager.FindByIdAsync(id);
        if (role != null)
        {
            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return RedirectToPage();
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
        else
        {
            ModelState.AddModelError("", "Role Not Found");
        }
        return Page();
    }
}