using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;

namespace Kingdom.Web.Http
{
    using Castle.Windsor;
    using Dependencies;
    using MicroKernel.Registration;

    /// <summary>
    /// Provides the hooks for <see cref="IWindsorContainer"/> integration with ASP.NET Web API.
    /// </summary>
    public static class PublicExtensionMethods
    {
        /// <summary>
        /// Installs services for use with <see cref="IWindsorContainer"/> and
        /// <see cref="HttpConfiguration"/> <paramref name="config"/>.
        /// </summary>
        /// <typeparam name="T">Type for which <see cref="Assembly"/> will be scanned for
        /// <see cref="ApiController"/> registration.</typeparam>
        /// <param name="container"></param>
        /// <param name="config"></param>
        /// <param name="otherTypes"></param>
        /// <returns></returns>
        public static IWindsorContainer InstallApiServices<T>(this IWindsorContainer container,
            HttpConfiguration config, params Type[] otherTypes)
        {
            container.Install(
                new ContainerInstaller()
                , new ApiDependencyResolverInstaller(config)
                , new ApiServicesInstaller()
                , new WebApiInstaller(config)
                , new ApiControllerInstaller<T>(otherTypes)
            );

            return container;
        }

        /// <summary>
        /// Installs services for use with <see cref="IWindsorContainer"/> and
        /// <see cref="HttpConfiguration"/> <paramref name="config"/>.
        /// </summary>
        /// <param name="container"></param>
        /// <param name="config"></param>
        /// <param name="rootType"><see cref="Type"/> for which <see cref="Assembly"/> will be
        /// scanned for <see cref="ApiController"/> registration.</param>
        /// <param name="otherTypes"></param>
        /// <returns></returns>
        public static IWindsorContainer InstallApiServices(this IWindsorContainer container,
            HttpConfiguration config, Type rootType, params Type[] otherTypes)
        {
            var types = new[] {rootType}.Concat(otherTypes);

            container.Install(
                new ContainerInstaller()
                , new ApiServicesInstaller()
                , new WebApiInstaller(config)
                , new ApiControllerInstaller(types)
            );

            return container;
        }

        /// <summary>
        /// Sets the <see cref="HttpConfiguration.DependencyResolver"/> with the
        /// <see cref="IWindsorDependencyResolver"/>.
        /// </summary>
        /// <param name="config"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        public static HttpConfiguration UseWindsorDependencyResolver(this HttpConfiguration config,
            IWindsorContainer container)
        {
            config.DependencyResolver = container.Resolve<IWindsorDependencyResolver>();
            return config;
        }
    }
}
