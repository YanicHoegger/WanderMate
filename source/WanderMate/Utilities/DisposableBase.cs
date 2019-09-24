using System;

namespace Utilities
{
    public class DisposableBase : IDisposable
    {
        protected DisposableBase()
        {
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected bool Disposed { get; private set; }

        protected virtual void Dispose(bool disposing)
        {
            Disposed = true;
        }

        ~DisposableBase()
        {
            Dispose(false);
        }
    }
}
