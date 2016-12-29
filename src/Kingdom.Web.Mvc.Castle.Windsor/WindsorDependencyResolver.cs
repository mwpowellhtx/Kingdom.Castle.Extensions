using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Kingdom.Web.Mvc
{
    using Castle.MicroKernel;
    // Avoid type collision with Castle.MicroKernel.IDependencyResolver, which is not the same thing.
    using IMvcDependencyResolver = IDependencyResolver;

    /// <summary>
    /// Establishes an Mvc <see cref="IDependencyResolver"/> for use with the <see cref="IKernel"/>.
    /// </summary>
    public class WindsorDependencyResolver : WindsorServiceBase, IWindsorDependencyResolver
    {
        /// <summary>
        /// Gets the DefaultResolver to use if services were not registered through the Windsor
        /// resolver.
        /// </summary>
        private IMvcDependencyResolver DefaultResolver { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="kernel"></param>
        public WindsorDependencyResolver(IKernel kernel)
            : this(kernel, null)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="currentResolver"></param>
        public WindsorDependencyResolver(IKernel kernel, IMvcDependencyResolver currentResolver)
            : base(kernel)
        {
            DefaultResolver = currentResolver;
        }

        private object GetCurrentService(Type serviceType)
        {
            return DefaultResolver?.GetService(serviceType);
        }

        private IEnumerable<object> GetCurrentServices(Type serviceType)
        {
            return DefaultResolver?.GetServices(serviceType).ToArray();
        }

        /// <summary>
        /// Resolves the Service corresponding to the <paramref name="serviceType"/> using the
        /// <see cref="WindsorServiceBase.Kernel"/>.
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public object GetService(Type serviceType)
        {
            object result;

            return Kernel.TryResolve(serviceType, out result)
                ? result
                : GetCurrentService(serviceType);
        }

        /// <summary>
        /// Resolves the Services corresponding to the <paramref name="serviceType"/> using the
        /// <see cref="WindsorServiceBase.Kernel"/>.
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            IEnumerable<object> result;

            return Kernel.TryResolveAll(serviceType, out result)
                ? result
                : GetCurrentServices(serviceType);
        }
    }

    internal static class KernelExtensionMethods
    {
        internal static bool TryResolve(this IKernel kernel, Type serviceType, out object result)
        {
            result = null;

            if (kernel.HasComponent(serviceType))
                result = kernel.Resolve(serviceType);

            return result != null;
        }

        internal static bool TryResolveAll(this IKernel kernel, Type serviceType, out IEnumerable<object> result)
        {
            result = new object[0];

            if (kernel.HasComponent(serviceType))
                result = kernel.ResolveAll(serviceType).Cast<object>().ToArray();

            return result.Any();
        }
    }
}
