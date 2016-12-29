using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace Kingdom.Web.Mvc
{
    using Castle.Windsor;
    using MicroKernel.Registration;

    /// <summary>
    /// Provides the hooks for <see cref="IWindsorContainer"/> integration with ASP.NET MVC.
    /// </summary>
    public static class PublicExtensionMethods
    {
        /// <summary>
        /// Configures the <paramref name="container"/> for use with ASP.NET MVC.
        /// </summary>
        /// <typeparam name="T">Type for which <see cref="Assembly"/> will be scanned for
        /// <see cref="IController"/> registration.</typeparam>
        /// <param name="container"></param>
        /// <param name="otherTypes"></param>
        /// <returns></returns>
        public static IWindsorContainer ConfigureMvc<T>(this IWindsorContainer container,
            params Type[] otherTypes)
        {
            // TODO: TBD: may want a view installer as well...
            container.Install(
                new WindsorContainerInstaller()
                , new MvcServicesInstaller()
                , new MvcControllerInstaller<T>(otherTypes)
            );

            return container;
        }

        /// <summary>
        /// Configures the <paramref name="container"/> for use with ASP.NET MVC.
        /// </summary>
        /// <param name="container"></param>
        /// <param name="rootType"><see cref="Type"/> for which <see cref="Assembly"/> will be
        /// scanned for <see cref="IController"/> registration.</param>
        /// <param name="otherTypes"></param>
        /// <returns></returns>
        public static IWindsorContainer ConfigureMvc(this IWindsorContainer container,
            Type rootType, params Type[] otherTypes)
        {
            var types = new[] {rootType}.Concat(otherTypes);

            container.Install(
                new WindsorContainerInstaller()
                , new MvcServicesInstaller()
                , new MvcControllerInstaller(types)
            );

            return container;
        }

        /// <summary>
        /// Uses the <see cref="IDependencyResolver"/> configured via the <paramref name="container"/>.
        /// </summary>
        /// <param name="container"></param>
        /// <returns></returns>
        public static IWindsorContainer UseDependencyResolver(this IWindsorContainer container)
        {
            {
                var args = new Dictionary<string, object> {{"currentResolver", DependencyResolver.Current}};
                var dependencyResolver = container.Resolve<IWindsorDependencyResolver>(args);
                DependencyResolver.SetResolver(dependencyResolver);
            }
            return container;
        }

        /// <summary>
        /// Uses the <see cref="IControllerFactory"/> configured via the <paramref name="container"/>.
        /// </summary>
        /// <param name="container"></param>
        /// <returns></returns>
        public static IWindsorContainer UseControllerFactory(this IWindsorContainer container)
        {
            {
                var ctrlFactory = container.Resolve<IControllerFactory>();
                ControllerBuilder.Current.SetControllerFactory(ctrlFactory);
            }
            return container;
        }
    }
}
