using FilmesAPI.data.DataBaseConnection;
using FilmesAPI.Data.UnitOfWork.Interfaces;

namespace FilmesAPI.data.UnitOfWork
{
    public class UnitOfWorkImpl : Data.UnitOfWork.Interfaces.UnitOfWork
    {
        private readonly DbSession _session;

        public UnitOfWorkImpl(DbSession session)
        {
            _session = session;
        }        
        public void BeginTransaction()
        {
            _session.Transaction = _session.Connection.BeginTransaction();
        }
        public void commit()
        {
            _session.Transaction.Commit();
            Dispose();
        }
        public void rollback()
        {
            _session.Transaction.Rollback();
            Dispose();
        }
        public void Dispose()
        {
            _session.Transaction?.Dispose();
        }
    }
}
