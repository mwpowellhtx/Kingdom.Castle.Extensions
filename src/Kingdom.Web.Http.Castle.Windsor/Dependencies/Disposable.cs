using System;

namespace Kingdom.Web.Http.Dependencies
{
    /// <summary>
    /// 
    /// </summary>
    public class Disposable : IDisposable
    {
        /// <summary>
        /// Gets whether IsDisposed.
        /// </summary>
        protected bool IsDisposed { get; private set; }

        /// <summary>
        /// Override to Dispose of the object.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
        }

        /// <summary>
        /// Disposes the object.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);

            if (!IsDisposed)
            {
                IsDisposed = true;
            }
        }
    }
}
