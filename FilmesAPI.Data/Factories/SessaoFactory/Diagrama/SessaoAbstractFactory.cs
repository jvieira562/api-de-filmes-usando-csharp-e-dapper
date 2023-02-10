using FilmesAPI.Dtos.SessaoDtos;
using FilmesAPI.Dtos.SessaoDtos.Interfaces;
using FilmesAPI.Models;

namespace FilmesAPI.Data.Factories.SessaoFactory
{
    public interface SessaoAbstractFactory
    {
        public ReadSessaoDtoImpl CreateReadSessaoDto(Sessao sessao, SessaoCinemaDtoImpl sessaoCinemaDto, Filme filme);
        public SessaoCinemaDtoImpl CreateSessaoCinemaDto(Cinema cinema, Endereco endereco, Gerente gerente);

    }
}
