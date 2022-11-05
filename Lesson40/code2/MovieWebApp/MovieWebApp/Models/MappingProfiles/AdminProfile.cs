using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MovieWebApp.Models.Admin;

namespace MovieWebApp.Models.MappingProfiles;

public class AdminProfile : Profile
{
    public AdminProfile()
    {
        CreateMap<IdentityUser, UserModel>();
        
        CreateMap<IdentityRole, RoleModel>();
    }
}