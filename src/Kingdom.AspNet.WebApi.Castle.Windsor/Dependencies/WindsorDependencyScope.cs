using System;
using System.Web.Http.Dependencies;

namespace Kingdom.Castle.Windsor.Web.Http.Dependencies
{
    using global::Castle.MicroKernel.Lifestyle;
    using global::Castle.Windsor;

    /// <summary>
    /// Provides a Castle Windsor based <see cref="IDependencyScope"/>.
    /// </summary>
    public class WindsorDependencyScope : WindsorDependencyBase, IWindsorDependencyScope
    {
        private readonly IDisposable _scope;

        internal WindsorDependencyScope(IWindsorContainer container)
            : base(container)
        {
            _scope = container.BeginScope();
        }

        /// <summary>
        /// Disposes the object.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (!IsDisposed && disposing)
            {
                _scope.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
