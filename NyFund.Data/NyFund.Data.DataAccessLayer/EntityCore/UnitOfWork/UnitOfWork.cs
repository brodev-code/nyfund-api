using NyFund.Core.Framework.DataAccessLayer.EntityCore.UnitOfWork;
using NyFund.Data.DataAccessLayer.Database;

namespace NyFund.Data.DataAccessLayer.EntityCore.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposedValue = false; // To detect redundant calls

        private readonly DbContextBase dbContext;
        public UnitOfWork(DbContextBase dbContext)
        {
            this.dbContext = dbContext;
        }
        public int SaveChanges()
        {
            return this.dbContext.SaveChanges();
        }

        public void BeginTransaction()
        {
            this.dbContext.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            this.dbContext.Database.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            this.dbContext.Database.RollbackTransaction();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await this.dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            await this.BeginTransactionAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            await this.CommitTransactionAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
        {
            await this.RollbackTransactionAsync(cancellationToken).ConfigureAwait(false);
        }
        #region IDisposable Support

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.
                this.disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~UnitOfWork()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            this.Dispose(true);

            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
