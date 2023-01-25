using AutoMapper;
using FilmesAPI.Dtos.GerenteDtos;
using FilmesAPI.Models;

namespace FilmesAPI.Services.AutoMapperProfiles
{
    public class GerenteProfile : Profile
    {
        public GerenteProfile()
        {
            CreateMap<CreateGerenteDto, Gerente>();
            CreateMap<UpdateGerenteDto, Gerente>();
            CreateMap<Gerente, ReadGerenteDto>();
        }
    }
}
