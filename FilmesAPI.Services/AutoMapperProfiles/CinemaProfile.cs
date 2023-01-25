using AutoMapper;
using FilmesAPI.Dtos.CinemaDtos;
using FilmesAPI.Models;

namespace FilmesAPI.Services.AutoMapperProfiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<CreateCinemaDto, Cinema>();
            CreateMap<UpdateCinemaDto, Cinema>();
            CreateMap<Cinema, ReadCinemaDto>();
        }
    }
}
