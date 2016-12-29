using System;
using System.Web.Http.Dependencies;

namespace Kingdom.Web.Http.Dependencies
{
    using Castle.MicroKernel.Lifestyle;
    using Castle.Windsor;

    /// <summary>
    /// Provides a Castle Windsor based <see cref="IDependencyScope"/>.
    /// </summary>
    public class WindsorDependencyScope : WindsorDependencyBase, IWindsorDependencyScope
    {
        private IDisposable Scope { get; }

        internal WindsorDependencyScope(IWindsorContainer container)
            : base(container)
        {
            Scope = container.BeginScope();
        }

        /// <summary>
        /// Disposes the object.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (!IsDisposed && disposing)
            {
                Scope.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
