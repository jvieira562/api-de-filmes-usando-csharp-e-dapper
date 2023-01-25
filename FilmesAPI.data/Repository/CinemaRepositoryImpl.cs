using Dapper;
using FilmesAPI.data.DataBaseConnection;
using FilmesAPI.data.Repository.Interfaces;
using FilmesAPI.Models;

namespace FilmesAPI.Data.Repository
{
    public class CinemaRepositoryImpl : CinemaRepository
    {
        private readonly DbSession _session;
        public CinemaRepositoryImpl(DbSession session)
        {
            _session = session;
        }
        public void AtualizarCinema(Cinema cinema)
        {
            string sql =
                @"UPDATE [Cinema]
                SET Nome = @Nome,
                    Cod_Endereco = @Cod_Endereco,
                    Cod_Gerente = @Cod_Gerente
                WHERE Cod_Cinema = @Cod_Cinema";

            _session.Connection.Execute(

                sql : sql,
                param : new 
                {
                    Nome = cinema.Nome,
                    Cod_Endereco = cinema.Cod_Endereco,
                    Cod_Gerente = cinema.Cod_Gerente,
                    Cod_Cinema = cinema.Cod_Cinema
                },
                transaction : _session.Transaction);
        }

        public Cinema BuscarCinema(int cod_Cinema)
        {
            string sql = 
                @"SELECT *
                FROM [Cinema]
                WHERE Cod_Cinema = @Cod_Cinema;";

            Cinema cinema = _session.Connection.QueryFirstOrDefault<Cinema>(
                sql : sql,
                param : new { Cod_Cinema = cod_Cinema });

            return cinema;
        }

        public IEnumerable<Cinema> BuscarCinemas()
        {
            return _session.Connection.Query<Cinema>(
                "SELECT * FROM [Cinema];");
        }

        public bool CinemaExiste(int cod_Cinema)
        {
            bool status = false;
            Cinema cinema = BuscarCinema(cod_Cinema);

            if (cinema != null) status = true;

            return status;
        }

        public void ExcluirCinema(int cod_Cinema)
        {
            string sql = 
                @"DELETE [Cinema]
                WHERE Cod_Cinema = @Cod_Cinema;";

            _session.Connection.Execute(
                sql, _session.Transaction);
        }

        public void SalvarCinema(Cinema cinema)
        {
            string sql =
                @"INSERT INTO [Cinema]
                (Nome, Cod_Endereco, Cod_Gerente)
                VALUES (@Nome, @Cod_Endereco, @Cod_Gerente);";

            _session.Connection.Execute(
                sql : sql,
                param : new
                {
                    Nome = cinema.Nome,
                    Cod_Endereco = cinema.Cod_Endereco,
                    Cod_Gerente = cinema.Cod_Gerente
                },
                transaction : _session.Transaction);            
        }
    }
}
