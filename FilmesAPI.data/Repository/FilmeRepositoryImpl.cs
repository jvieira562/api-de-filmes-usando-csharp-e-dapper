using Dapper;
using FilmesAPI.data.DataBaseConnection;
using FilmesAPI.data.Repository.Interfaces;
using FilmesAPI.Models;

namespace FilmesAPI.data.Repository
{
    public class FilmeRepositoryImpl : FilmeRepository
    {
        private readonly DbSession _session;
        public FilmeRepositoryImpl(DbSession session)
        {
                _session = session;
        }

        public Filme BuscarFilme(int cod_Filme)
        {
            string sql =
                @"SELECT * FROM [Filme]
                WHERE Cod_Filme = @cod_Filme;";

            Filme filme = _session.Connection.QueryFirstOrDefault<Filme>(
                sql : sql,
                param : new { Cod_Filme = cod_Filme });
            
            return filme;
        }

        public IEnumerable<Filme> BuscarFilmes()
        {
            return _session.Connection.Query<Filme>(
                @"SELECT * FROM [Filme];");
        }

        public void SalvarFilme(Filme filme)
        {
            string sql =
            @"INSERT INTO [Filme] (Titulo, Diretor, Genero, Duracao, FaixaEtaria)
            VALUES (@Titulo, @Diretor, @Genero, @Duracao, @FaixaEtaria)";

            _session.Connection.Execute(
                sql : sql,
                param : new
                {
                    Titulo = filme.Titulo,
                    Diretor = filme.Diretor,
                    Genero = filme.Genero,
                    Duracao = filme.Duracao,
                    FaixaEtaria = filme.FaixaEtaria
                },
                transaction : _session.Transaction);
        }

        public void ExcluirFilme(int cod_Filme)
        {
            string sql =
                @"DELETE
                FROM [Filme]
                WHERE Cod_Filme = @cod_Filme;";

            _session.Connection.Execute(
                sql : sql,
                param : new { Cod_Filme = cod_Filme },
                transaction : _session.Transaction);
        }
    
        public void AtualizarFilme(Filme filme)
        {
            string sql =
                @"UPDATE [Filme]
                SET Titulo = @Titulo,
                    Diretor = @Diretor,
                    Genero = @Genero,
                    Duracao = @Duracao,
                    FaixaEtaria = @FaixaEtaria
                WHERE Cod_Filme = @Cod_Filme;";
            
            _session.Connection.Execute(
                sql : sql,               
                param : new
                {
                    Cod_Filme = filme.Cod_Filme,
                    Titulo = filme.Titulo,
                    Diretor = filme.Diretor,
                    Genero = filme.Genero,
                    Duracao = filme.Duracao,
                    FaixaEtaria = filme.FaixaEtaria
                },
                transaction : _session.Transaction);
        }

        public bool FilmeExiste(int cod_Filme)
        {
            bool status = false;
            Filme filme = BuscarFilme(cod_Filme);
            if (filme != null) status = true;

            return status;
        }
    }
}
