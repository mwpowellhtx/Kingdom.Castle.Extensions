using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Windsor;

namespace Kingdom.Castle.Windsor.Web.Http.Dependencies
{
    /// <summary>
    /// Provides a base class for Castle Windsor based Dependency Resolution.
    /// </summary>
    public abstract class WindsorDependencyBase : IDisposable
    {
        /// <summary>
        /// Gets the Container.
        /// </summary>
        protected IWindsorContainer Container { get; private set; }

        /// <summary>
        /// Protected Constructor
        /// </summary>
        /// <param name="container"></param>
        protected WindsorDependencyBase(IWindsorContainer container)
        {
            Container = container;
        }

        /// <summary>
        /// Returns the Service corresponding with the <paramref name="serviceType"/> Type.
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public virtual object GetService(Type serviceType)
        {
            return Container.Resolve(serviceType);
        }

        /// <summary>
        /// Returns the Services corresponding to the <paramref name="serviceType"/> Type.
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Container.ResolveAll(serviceType).Cast<object>();
        }

        /// <summary>
        /// Gets whether IsDisposed.
        /// </summary>
        protected bool IsDisposed { get; private set; }

        /// <summary>
        /// Override to provide more specialized Dispose functionality.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
        }

        public void Dispose()
        {
            Dispose(IsDisposed);
            IsDisposed = true;
        }
    }
}
