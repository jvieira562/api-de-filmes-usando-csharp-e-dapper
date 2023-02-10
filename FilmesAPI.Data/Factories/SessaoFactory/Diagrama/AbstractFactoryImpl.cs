using FilmesAPI.Dtos.SessaoDtos;
using FilmesAPI.Models;

namespace FilmesAPI.Data.Factories.SessaoFactory
{
    public class SessaoAbstractFactoryImpl : SessaoAbstractFactory
    {
        public ReadSessaoDtoImpl CreateReadSessaoDto(Sessao sessao, SessaoCinemaDtoImpl sessaoCinemaDto, Filme filme)
        {

            var readSesao = new ReadSessaoDtoImpl
            {
                Cod_Sessao = sessao.Cod_Sessao,
                Cinema = sessaoCinemaDto,
                Filme = filme,
                HorarioDeInicio = sessao.HorarioDeInicio,
                HorarioDeEncerramento = sessao.HorarioDeInicio.AddMinutes(filme.Duracao)
            };
            return readSesao;
        }

        public SessaoCinemaDtoImpl CreateSessaoCinemaDto(Cinema cinema, Endereco endereco, Gerente gerente)
        {
            return new SessaoCinemaDtoImpl
            {
                Cod_Cinema = cinema.Cod_Cinema,
                Nome = cinema.Nome,
                Endereco = endereco,
                Gerente = gerente
            };
        }
    }
}
