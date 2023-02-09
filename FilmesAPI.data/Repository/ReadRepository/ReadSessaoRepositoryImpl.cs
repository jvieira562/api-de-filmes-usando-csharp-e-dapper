using Dapper;
using FilmesAPI.data.DataBaseConnection;
using FilmesAPI.Data.Repository.ReadRepository.Interfaces;
using FilmesAPI.Dtos.SessaoDtos;
using FilmesAPI.Models;

namespace FilmesAPI.Data.Repository.ReadRepository
{
    public class ReadSessaoRepositoryImpl : ReadSessaoRepository
    {
        private readonly DbSession _session;
        public ReadSessaoRepositoryImpl(DbSession session)
        {
            _session = session;
        }
        public ReadSessaoDto BuscarSessao(int cod_Sessao)
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

            var sessaoDto = _session.Connection.Query<Sessao, Cinema, Endereco, Gerente, Filme, ReadSessaoDto>(
                sql : sql,
                map : (sessao, cinema, endereco, gerente, filme) =>
                {
                    
                    return null;
                },
                param : new { Cod_Sessao = cod_Sessao },
                splitOn : "Cut").FirstOrDefault();

            return null;
        }public IEnumerable<ReadSessaoDto> BuscarSessoes(int cod_Sessao)
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

            var sessaoDto = _session.Connection.Query<ReadSessaoDto, Sessao, Cinema, Endereco, Gerente, Filme, ReadSessaoDto>(
                sql : sql,
                map : (readSessao, sessao, cinema, endereco, gerente, filme) =>
                {
                    readSessao.Filme = filme;
                    readSessao.Cinema = new SessaoCinemaDto
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
