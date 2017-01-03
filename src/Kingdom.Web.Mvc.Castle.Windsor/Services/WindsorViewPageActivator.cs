using System;
using System.Web.Mvc;

namespace Kingdom.Web.Mvc
{
    using Castle.MicroKernel;
    using IDependencyResolver = IDependencyResolver;

    /// <summary>
    /// <see cref="IViewPageActivator"/> for use with <see cref="IKernel"/>.
    /// </summary>
    public class WindsorViewPageActivator : WindsorServiceBase, IWindsorViewPageActivator
    {
        private IDependencyResolver CurrentResolver { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="currentResolver"></param>
        public WindsorViewPageActivator(IKernel kernel, IDependencyResolver currentResolver)
            : base(kernel)
        {
            CurrentResolver = currentResolver;
        }

        private object CreateCurrent(ControllerContext controllerContext, Type type)
        {
            return CurrentResolver?.GetService(type);
        }

        /// <summary>
        /// Returns the view resolved by the <see cref="IKernel"/>.
        /// </summary>
        /// <param name="controllerContext"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public object Create(ControllerContext controllerContext, Type type)
        {
            /* TODO: TBD: should the type be registered with the Kernel? I saw that in one
             * example, but it does not seem like a great idea... Furthermore, falling back to the
             * DefaultDependencyResolver seems to work just fine. */

            if (Kernel.HasComponent(type))
            {
                return Kernel.Resolve(type) ?? CreateCurrent(controllerContext, type);
            }

            return CreateCurrent(controllerContext, type);
        }

        /// <summary>
        /// Returns whether <paramref name="viewType"/> IsSupportedView.
        /// </summary>
        /// <param name="viewType"></param>
        /// <returns></returns>
        private static bool IsSupportedView(Type viewType)
        {
            return viewType.IsAssignableTo<WebViewPage>()
                || viewType.IsAssignableTo<ViewPage>()
                || viewType.IsAssignableTo<ViewMasterPage>()
                || viewType.IsAssignableTo<ViewUserControl>()
                ;
        }
    }
}
