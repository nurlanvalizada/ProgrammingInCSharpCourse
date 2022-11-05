using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieWebApp.Models.Admin;

namespace MovieWebApp.Areas.Admin.Pages.Users;

public class ManageRoles : PageModel
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public ManageRoles(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public List<UserRoleModel> UserRoles { get; set; }

    public async Task OnGetAsync(string userId)
    {
        ViewData["userId"] = userId;
        var user = await _userManager.FindByIdAsync(userId);
        if(user == null)
        {
            ViewData["ErrorMessage"] = $"User with Id = {userId} cannot be found";
            return;
        }

        ViewData["UserName"] = user.UserName;
        UserRoles = new List<UserRoleModel>();
        foreach (var role in _roleManager.Roles)
        {
            var userRolesViewModel = new UserRoleModel
            {
                RoleId = role.Id,
                RoleName = role.Name
            };
            if(await _userManager.IsInRoleAsync(user, role.Name))
            {
                userRolesViewModel.Selected = true;
            }
            else
            {
                userRolesViewModel.Selected = false;
            }

            UserRoles.Add(userRolesViewModel);
        }
    }

    public async Task<IActionResult> OnPostAsync(List<UserRoleModel> userRoles, string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if(user == null)
        {
            ViewData["ErrorMessage"] = $"User with Id = {userId} cannot be found";
            return Page();
        }

        var roles = await _userManager.GetRolesAsync(user);
        var result = await _userManager.RemoveFromRolesAsync(user, roles);
        if(!result.Succeeded)
        {
            ModelState.AddModelError("", "Cannot remove user existing roles");
            return Page();
        }

        result = await _userManager.AddToRolesAsync(user, userRoles.Where(x => x.Selected).Select(y => y.RoleName));

        if(result.Succeeded) return RedirectToPage("Index");

        ModelState.AddModelError("", "Cannot add selected roles to user");
        return Page();
    }
}