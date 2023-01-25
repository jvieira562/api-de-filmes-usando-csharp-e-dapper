using Dapper;
using FilmesAPI.data.DataBaseConnection;
using FilmesAPI.data.Repository.Interfaces;
using FilmesAPI.Models;

namespace FilmesAPI.Data.Repository
{
    public class EnderecoRepositoryImpl : EnderecoRepository
    {
        private readonly DbSession _session;

        public EnderecoRepositoryImpl(DbSession session)
        {   
            _session = session;
        }
        public void AtualizarEndereco(Endereco endereco)
        {
            string sql =
                @"UPDATE [Endereco]
                SET (Logradouro = @Logradouro,
                    Bairro = @Bairro,
                    Numero = @Numero)
                WHERE Cod_Endereco = @Cod_Endereco;";
            
            _session.Connection.Execute(
                sql: sql,
                param: new
                {
                    Logradouro = endereco.Logradouro,
                    Bairro = endereco.Bairro,
                    Numero = endereco.Numero,
                    Cod_Endereco = endereco.Cod_Endereco
                },
                transaction : _session.Transaction);
        }

        public Endereco BuscarEndereco(int cod_Endereco)
        {
            string sql =
                @"SELECT 
                * FROM [Endereco]
                WHERE Cod_Endereco = @Cod_Endereco;";

            Endereco endereco = _session.Connection.QueryFirstOrDefault<Endereco>(
                sql : sql,
                param : new { Cod_Endereco = cod_Endereco });
            
            return endereco;        
        }

        public IEnumerable<Endereco> BuscarEnderecos()
        {
            return _session.Connection.Query<Endereco>(
                "SELECT * FROM [Endereco];");
        }

        public bool EnderecoExiste(int cod_Endereco)
        {
            bool status = false;
            Endereco endereco = BuscarEndereco(cod_Endereco);
            if (endereco != null) status = true;

            return status;
        }

        public void ExcluirEndereco(int cod_Endereco)
        {
            string sql =
                @"DELETE [Endereco]
                WHERE Cod_Endereco = @Cod_Endereco;";

            _session.Connection.Execute(
                sql: sql,
                param : new { Cod_Endereco = cod_Endereco },
                transaction : _session.Transaction);
        }

        public void SalvarEndereco(Endereco endereco)
        {
            string sql =
                @"INSERT INTO [Endereco] (Logradouro, Bairro, Numero, Cep, Cidade)
                VALUES (@Logradouro, @Bairro, @Numero, @Cep, @Cidade);";

            _session.Connection.Execute(
                sql: sql,
                param: new
                {
                    Logradouro = endereco.Logradouro,
                    Bairro = endereco.Bairro,
                    Numero = endereco.Numero,
                    Cep = endereco.Cep,
                    Cidade = endereco.Cidade
                },
                transaction : _session.Transaction);
        }
    }
}
