
namespace NyFund.Core.Framework.DataAccessLayer.EntityCore.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task CommitTransactionAsync(CancellationToken cancellationToken = default);
        Task RollbackTransactionAsync(CancellationToken cancellationToken = default);

        int SaveChanges();

        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
