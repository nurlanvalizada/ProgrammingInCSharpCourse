using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieWebApp.Models.Admin;

namespace MovieWebApp.Areas.Admin.Pages.Users;

public class CreateModel : PageModel
{
    private readonly UserManager<IdentityUser> _userManager;

    public CreateModel(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    [BindProperty]
    public UserCreateModel UserCreate { get; set; }
    
    public void OnGet()
    {
        
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        if(!ModelState.IsValid || UserCreate.Password != UserCreate.ConfirmPassword)
        {
            return Page();
        }
        
        var user = new IdentityUser
        {
            UserName = UserCreate.Email,
            Email = UserCreate.Email,
        };
        var createResult = await _userManager.CreateAsync(user, UserCreate.Password);
        if(createResult.Succeeded)
        {
            return RedirectToPage("./Index");
        }

        foreach (var identityError in createResult.Errors)
        {
            ModelState.AddModelError("", identityError.Code + ": " + identityError.Description);
        }
        
        return Page();
    }
}