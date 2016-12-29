using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Validation;

namespace Kingdom.Web.Http.Dependencies
{
    using Castle.MicroKernel;
    using Castle.Windsor;
    using MicroKernel.Registration;

    /// <summary>
    /// Provides a base class for Castle Windsor based Dependency Resolution.
    /// </summary>
    public abstract class WindsorDependencyBase : Disposable
    {
        /// <summary>
        /// Gets the Container.
        /// </summary>
        public IWindsorContainer Container { get; }

        /// <summary>
        /// Protected Constructor
        /// </summary>
        /// <param name="container"></param>
        protected WindsorDependencyBase(IWindsorContainer container)
        {
            Container = container;
        }

        /// <summary>
        /// System.Web.Http.Validation.IModelValidatorCache, <see cref="IModelValidatorCache"/>.
        /// </summary>
        private const string ModelValidatorCacheTypeFullName = "System.Web.Http.Validation.IModelValidatorCache";

        /// <summary>
        /// Gets the <see cref="GlobalConfiguration.Configuration"/> for protected usage.
        /// </summary>
        protected static HttpConfiguration GlobalConfig => GlobalConfiguration.Configuration;

        /// <summary>
        /// Returns the Service corresponding with the <paramref name="serviceType"/> Type.
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public virtual object GetService(Type serviceType)
        {
            return IsBuiltin(serviceType)
                ? GlobalConfig.DependencyResolver.GetService(serviceType)
                : Container.Resolve(serviceType);
        }

        /// <summary>
        /// Returns the Services corresponding to the <paramref name="serviceType"/> Type.
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return (IsBuiltin(serviceType)
                ? GlobalConfig.DependencyResolver.GetServices(serviceType)
                : Container.ResolveAll(serviceType).Cast<object>()).ToArray();
        }

        /// <summary>
        /// Returns whether the <paramref name="serviceType"/> is a <see
        /// cref="IModelValidatorCache"/>. IModelValidatorCache is internal for some reason. I do
        /// not know why, but it poses a significant challenge when providing a custom <see
        /// cref="IDependencyResolver"/>. Otherwise, the <see cref="WebApiInstaller"/> satisfies
        /// the majority of service requirements for Web API to operate correctly.
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        /// <see cref="WebApiInstaller"/>
        protected static bool IsBuiltin(Type serviceType)
        {
            /* TODO: TBD: I think it is written in French, but the code is enlightening:
             * http://marc-chouteau.blogspot.com/2012/08/comment-utiliser-unity-avec-aspnet.html */

            // TODO: TBD: it may be better (/acceptable?) to handle "default" services being resolved from the Global Config...

            // IModelValidatorCache is internal so we need to handle it as a special case.
            return serviceType.FullName.Equals(ModelValidatorCacheTypeFullName);
        }

        /// <summary>
        /// Override to provide more specialized Dispose functionality.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (!IsDisposed && disposing)
            {
                // TODO: TBD: Dispose of the dependency resolver resources...
            }
        }
    }
}
