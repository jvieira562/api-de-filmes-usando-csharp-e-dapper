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
            Connection = new SqlConnection("Data Source=JV0001; Initial Catalog=FilmesAPI; Integrated Security=True;");
            Connection.Open();
        }
        public void Dispose()
        {
            Connection.Dispose();
        }

    }
}
