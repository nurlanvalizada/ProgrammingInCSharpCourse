using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieWebApp.Models.Admin;

namespace MovieWebApp.Areas.Admin.Pages.Users;

public class ManageClaims : PageModel
{
    private readonly UserManager<IdentityUser> _userManager;

    public ManageClaims(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }
    
    public List<ClaimsModel> UserClaims { get; set; }
    
    [BindProperty]
    public ClaimsModel UserClaim { get; set; }

    public async Task OnGetAsync(string userId)
    {
        ViewData["userId"] = userId;
        var user = await _userManager.FindByIdAsync(userId);
       
        if(user == null)
        {
            ViewData["ErrorMessage"] = $"User with Id = {userId} cannot be found";
            return;
        }
        
        ViewData["userName"] = user.UserName;
        
        var claims = await _userManager.GetClaimsAsync(user);
        UserClaims = new List<ClaimsModel>();
        foreach (var claim in claims)
        {
            var claimModel = new ClaimsModel
            {
                Type = claim.Type,
                Value = claim.Value
            };
            
            UserClaims.Add(claimModel);
        }
    }
    
    public async Task<IActionResult> OnPostAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if(user == null)
        {
            ViewData["ErrorMessage"] = $"User with Id = {userId} cannot be found";
            return Page();
        }

        var result = await _userManager.AddClaimAsync(user, new Claim(UserClaim.Type, UserClaim.Value));

        if(result.Succeeded) return RedirectToPage(new { userId });
        
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError("", error.Description);
        }
        return Page();
    }  
    
    public async Task<IActionResult> OnPostDeleteAsync(string userId, ClaimsModel claim)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if(user == null)
        {
            ViewData["ErrorMessage"] = $"User with Id = {userId} cannot be found";
            return Page();
        }

        var result = await _userManager.RemoveClaimAsync(user, new Claim(claim.Type, claim.Value));

        if(result.Succeeded) return RedirectToPage(new { userId });
        
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError("", error.Description);
        }
        return Page();
    }
}