using System.ComponentModel.DataAnnotations;

namespace MovieWebApp.Models.Admin;

public class RoleCreateModel
{
    [Required]
    [MinLength(3)]
    public string Name { get; set; }
}