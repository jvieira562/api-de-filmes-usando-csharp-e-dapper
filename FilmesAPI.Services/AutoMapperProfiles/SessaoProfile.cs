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
            CreateMap<CreateSessaoDtoImpl, Sessao>();
            CreateMap<UpdateSessaoDto, Sessao>();
            CreateMap<Sessao, ReadSessaoDtoImpl>();
            CreateMap<Sessao, CinemaSessaoDto>();
        }
    }
}
