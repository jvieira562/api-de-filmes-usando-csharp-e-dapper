namespace FilmesAPI.Data.UnitOfWork.Interfaces
{
    public interface UnitOfWork : IDisposable
    {
        void commit();
        void rollback();
        void BeginTransaction();
    }
}
