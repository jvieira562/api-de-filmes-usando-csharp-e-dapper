using Dapper;
using FilmesAPI.data.DataBaseConnection;
using FilmesAPI.data.Repository.Interfaces;
using FilmesAPI.Models;

namespace FilmesAPI.Data.Repository
{
    public class GerenteRepositoryImpl : GerenteRepository
    {
        private readonly DbSession _session;
        public GerenteRepositoryImpl(DbSession session)
        {
            _session = session;
        }

        public void AtualizarGerente(Gerente gerente)
        {
            string sql =
                @"UPDATE [Gerente]
                SET Nome = @Nome
                WHERE Cod_Gerente = @Cod_Gerente";

            _session.Connection.Execute(
                sql : sql,
                param : new
                {
                    Nome = gerente.Nome,
                    Cod_Gerente = gerente.Cod_Gerente,
                },
                transaction : _session.Transaction);
        }

        public Gerente BuscarGerente(int cod_Gerente)
        {
            string sql =
                @"SELECT *
                FROM [Gerente]
                WHERE Cod_Gerente = @Cod_Gerente;";

           Gerente gerente = _session.Connection
                .QueryFirstOrDefault<Gerente>(
                sql : sql,
                param : new { Cod_Gerente = cod_Gerente});
            
            return gerente;
        }

        public IEnumerable<Gerente> BuscarGerentes()
        {
            return _session.Connection.Query<Gerente>(
                "SELECT * FROM [Gerente];");
        }

        public void ExcluirGerente(int cod_Gerente)
        {
            string sql =
                @"DELETE [Gerente]
                WHERE Cod_Gerente = @Cod_Gerente;";

            _session.Connection.Execute(
                sql: sql,
                param: new
                { Cod_Gerente = cod_Gerente },
                transaction: _session.Transaction);
        }

        public bool GerenteExiste(int cod_Gerente)
        {
            bool status = false;
            Gerente gerente = BuscarGerente(cod_Gerente);
            if (gerente != null) status = true;

            return status;
        }

        public void SalvarGerente(Gerente gerente)
        {
            string sql =
                @"INSERT INTO [Gerente] (Nome)
                VALUES (@Nome);";

            _session.Connection.Execute(
                sql : sql,
                param : new { Nome = gerente.Nome },
                transaction : _session.Transaction);
        }
    }
}
