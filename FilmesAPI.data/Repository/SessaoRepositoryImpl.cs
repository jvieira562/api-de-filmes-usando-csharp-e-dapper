using Dapper;
using FilmesAPI.data.DataBaseConnection;
using FilmesAPI.Data.Repository.Interfaces;
using FilmesAPI.Models;

namespace FilmesAPI.Data.Repository
{
    public class SessaoRepositoryImpl : SessaoRepository
    {
        private readonly DbSession _session;

        public SessaoRepositoryImpl(DbSession session)
        {
            _session = session;
        }

        public void AtualizarSessao(Sessao sessao)
        {
            string sql =
                @"UPDATE [Sessao]
                SET Cod_Filme = @Cod_Filme,
                    Cod_Cinema = @Cod_Cinema,
                    HorarioDeEncerramento = @HorarioDeEncerramento
                WHERE Cod_Sessao = @Cod_Sessao;";

            _session.Connection.Execute(
                sql: sql,
                param: new
                {
                    Cod_Filme = sessao.Cod_Filme,
                    Cod_Cinema = sessao.Cod_Cinema,
                    HorarioDeEncerramento = sessao.HorarioDeInicio,
                    Cod_Sessao = sessao.Cod_Sessao,
                },
                transaction: _session.Transaction);
        }

        public Sessao BuscarSessao(int cod_Sessao)
        {
            string sql =
                @"SELECT * FROM [Sessao]
                WHERE Cod_Sessao = @Cod_Sessao;";

            Sessao sessao = _session.Connection.QueryFirstOrDefault(
                sql : sql,
                param : new { Cod_Sessao = cod_Sessao });

            return sessao;
        }

        public IEnumerable<Sessao> BuscarSessoes()
        {
            return _session.Connection.Query<Sessao>(
                "SELECT * FROM Sessao;");
        }
        public IEnumerable<Sessao> BuscarSessoesNoCinema(int cod_Cinema)
        {
            string sql =
                @"SELECT *
                FROM [Sessao]
                WHERE Cod_Cinema = @Cod_Cinema;";

            IEnumerable<Sessao> sessoes = _session.Connection.Query<Sessao>(
                sql : sql,
                param : new { Cod_Cinema = cod_Cinema });

            return sessoes;
        }

        public void SalvarSessao(Sessao sessao)
        {
            string sql =
                @"INSERT INTO [Sessao] (Cod_Filme, Cod_Cinema, HorarioDeInicio)
                VALUES (@Cod_Filme, @Cod_Cinema, @HorarioDeInicio);";
            
            _session.Connection.Execute(

                sql : sql,
                param : new
                {
                    Cod_Filme = sessao.Cod_Filme,
                    Cod_Cinema = sessao.Cod_Cinema,
                    HorarioDeInicio = sessao.HorarioDeInicio
                },
                transaction : _session.Transaction);
        }

        public void ExcluirSessao(int cod_Sessao)
        {
            string sql =
                @"SELETE [Sessao]
                WHERE Cod_Sessao = @Cod_Sessao;";

            _session.Connection.Execute(
                
                sql : sql,
                param : new { Cod_Sessao = cod_Sessao },
                transaction : _session.Transaction);
        }

        public bool SessaoExiste(int cod_Sessao)
        {
            bool status = false;
            Sessao sessao = BuscarSessao(cod_Sessao);
            if (sessao != null) status = true;

            return status;
        }
    }
}
