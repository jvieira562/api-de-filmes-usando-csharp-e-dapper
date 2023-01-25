using AutoMapper;
using FilmesAPI.Dtos.CinemaDtos;
using FilmesAPI.Dtos.SessaoDtos;
using FilmesAPI.Models;

namespace FilmesAPI.Services.AutoMapperProfiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDto, Sessao>();
            CreateMap<UpdateSessaoDto, Sessao>();
            CreateMap<Sessao, ReadSessaoDto>();
            CreateMap<Sessao, CinemaSessaoDto>();
        }
    }
}
