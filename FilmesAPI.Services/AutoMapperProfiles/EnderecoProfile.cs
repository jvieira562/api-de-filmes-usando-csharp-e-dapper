using AutoMapper;
using FilmesAPI.Dtos.EnderecoDtos;
using FilmesAPI.Models;

namespace FilmesAPI.Services.AutoMapperProfiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<CreateEnderecoDto, Endereco>();
            CreateMap<UpdateEnderecoDto, Endereco>();
            CreateMap<Endereco, ReadEnderecoDto>();
        }
    }
}
