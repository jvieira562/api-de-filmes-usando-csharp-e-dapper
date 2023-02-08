using FilmesAPI.Data.DataBaseConnection;
using System.Data;
using System.Data.SqlClient;

namespace FilmesAPI.data.DataBaseConnection
{
    public sealed class DbSession : IDisposable
    {
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }

        public DbSession()
        {
            Connection = new SqlConnection(ConnectionStringDB.EnderecoDaBase);
            Connection.Open();
        }
        public void Dispose()
        {
            Connection.Dispose();
        }

    }
}
