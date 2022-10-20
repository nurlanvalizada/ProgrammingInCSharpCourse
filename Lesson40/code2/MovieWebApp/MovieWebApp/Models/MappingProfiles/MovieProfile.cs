using AutoMapper;
using MovieWebApp.Models.Dtos;

namespace MovieWebApp.Models.MappingProfiles;

public class MovieProfile : Profile
{
    public MovieProfile()
    {
        CreateMap<MovieModel, Movie>()
            .ForMember(dest => dest.ImageUrl, opt => opt.Ignore());
        
        CreateMap<Movie, MovieModel>()
            .ForMember(dest => dest.Image, opt => opt.Ignore());
    }
}