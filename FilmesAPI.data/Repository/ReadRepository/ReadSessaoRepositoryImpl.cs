using Dapper;
using FilmesAPI.data.DataBaseConnection;
using FilmesAPI.Data.Factories.SessaoFactory;
using FilmesAPI.Data.Repository.ReadRepository.Interfaces;
using FilmesAPI.Dtos.SessaoDtos;
using FilmesAPI.Models;

namespace FilmesAPI.Data.Repository.ReadRepository
{
    public class ReadSessaoRepositoryImpl : ReadSessaoRepository
    {
        private readonly DbSession _session;
        private readonly SessaoAbstractFactory _sessaoFactory;
        public ReadSessaoRepositoryImpl(DbSession session, SessaoAbstractFactory sessaoFactory)
        {
            _session = session;
            _sessaoFactory = sessaoFactory;
        }
        public ReadSessaoDtoImpl BuscarSessao(int cod_Sessao)
        {
            string sql =
                @"SELECT s.*,
                       NULL AS Cut,
                       c.*,
                       NULL AS Cut,
                       e.*,
                       NULL AS Cut,
                       g.*,
                       NULL AS Cut,
                       f.*
                FROM [Sessao] AS s
                INNER JOIN [Cinema] AS c ON s.Cod_Cinema = c.Cod_Cinema
                INNER JOIN [Endereco] AS e ON c.Cod_Endereco = e.Cod_Endereco
                INNER JOIN [Gerente] AS g ON c.Cod_Gerente = g.Cod_Gerente
                INNER JOIN [Filme] AS f ON s.Cod_Filme = f.Cod_Filme
                WHERE s.Cod_Sessao = @Cod_Sessao;";

            var sessaoDto = _session.Connection.Query<Sessao, Cinema, Endereco, Gerente, Filme, ReadSessaoDtoImpl>(
                sql : sql,
                map : (sessao, cinema, endereco, gerente, filme) =>
                {
                    var sessaoCinema = _sessaoFactory.CreateSessaoCinemaDto(cinema, endereco, gerente);
                    var readCinemaDto = _sessaoFactory.CreateReadSessaoDto(sessao, sessaoCinema, filme);
                    return readCinemaDto;
                },
                param : new { Cod_Sessao = cod_Sessao },
                splitOn : "Cut").FirstOrDefault();

            return sessaoDto;
        }public IEnumerable<ReadSessaoDtoImpl> BuscarSessoes(int cod_Sessao)
        {
            string sql =
                @"SELECT *
                FROM [Sessao] AS s
                INNER JOIN [Cinema] AS c
                ON s.Cod_Cinema = c.Cod_Cinema
                INNER JOIN [Endereco] AS e
                ON c.Cod_Endereco = e.Cod_Endereco
                INNER JOIN [Gerente] AS g
                ON c.Cod_Gerente = g.Cod_Gerente
                INNER JOIN [Filme] AS f
                ON f.Cod_Filme = s.Cod_Filme
                WHERE Cod_Sessao = @Cod_Sessao;";

            var sessaoDto = _session.Connection.Query<ReadSessaoDtoImpl, Sessao, Cinema, Endereco, Gerente, Filme, ReadSessaoDtoImpl>(
                sql : sql,
                map : (readSessao, sessao, cinema, endereco, gerente, filme) =>
                {
                    readSessao.Filme = filme;
                    readSessao.Cinema = new SessaoCinemaDtoImpl
                    {
                        Cod_Cinema = cinema.Cod_Cinema,
                        Nome = cinema.Nome,
                        Endereco = endereco,
                        Gerente = gerente
                    };
                    readSessao.HorarioDeEncerramento = sessao.HorarioDeInicio.AddMinutes(filme.Duracao);
                    readSessao.HorarioDeInicio = sessao.HorarioDeInicio;
                    return readSessao;
                },
                param : new { Cod_Sessao = cod_Sessao },
                splitOn : "Cod_Cinema, Cod_Endereco, Cod_Gerente, Cod_Filme",
                transaction : _session.Transaction);

            return sessaoDto;
        }
    }
}
