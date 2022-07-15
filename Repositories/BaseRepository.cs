using System;
using Models;

namespace Repositories
{
    public abstract class BaseRepository : IDisposable
    {
        protected ApplicationDbContext Context;

        protected BaseRepository()
        {
            this.Context = new ApplicationDbContext();
        }

        protected bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}