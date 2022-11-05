using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieWebApp.Models.Admin;

namespace MovieWebApp.Areas.Admin.Pages.Roles;

public class ManageRoleClaims : PageModel
{
    private readonly RoleManager<IdentityRole> _roleManager;

    public ManageRoleClaims(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }
    
    public List<ClaimsModel> RoleClaims { get; set; }
    
    [BindProperty]
    public ClaimsModel RoleClaim { get; set; }

    public async Task OnGetAsync(string roleId)
    {
        ViewData["roleId"] = roleId;
        var role = await _roleManager.FindByIdAsync(roleId);
       
        if(role == null)
        {
            ViewData["ErrorMessage"] = $"Role with Id = {roleId} cannot be found";
            return;
        }
        
        ViewData["roleName"] = role.Name;
        
        var claims = await _roleManager.GetClaimsAsync(role);
        RoleClaims = new List<ClaimsModel>();
        foreach (var claim in claims)
        {
            var claimModel = new ClaimsModel
            {
                Type = claim.Type,
                Value = claim.Value
            };
            
            RoleClaims.Add(claimModel);
        }
    }
    
    public async Task<IActionResult> OnPostAsync(string roleId)
    {
        var role = await _roleManager.FindByIdAsync(roleId);
        if(role == null)
        {
            ViewData["ErrorMessage"] = $"Role with Id = {roleId} cannot be found";
            return Page();
        }

        var result = await _roleManager.AddClaimAsync(role, new Claim(RoleClaim.Type, RoleClaim.Value));

        if(result.Succeeded) return RedirectToPage(new { roleId });
        
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError("", error.Description);
        }
        return Page();
    }
    
    public async Task<IActionResult> OnPostDeleteAsync(string roleId, ClaimsModel claim)
    {
        var user = await _roleManager.FindByIdAsync(roleId);
        if(user == null)
        {
            ViewData["ErrorMessage"] = $"Role with Id = {roleId} cannot be found";
            return Page();
        }

        var result = await _roleManager.RemoveClaimAsync(user, new Claim(claim.Type, claim.Value));

        if(result.Succeeded) return RedirectToPage(new { roleId });
        
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError("", error.Description);
        }
        return Page();
    }
}