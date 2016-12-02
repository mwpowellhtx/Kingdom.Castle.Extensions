using System;
using System.Linq;
using System.Reflection;
using System.Web.Http;

namespace Kingdom.Castle.Windsor.Web.Http
{
    using MicroKernel.Registration;
    using global::Castle.Windsor;

    /// <summary>
    /// Provides the hooks for <see cref="IWindsorContainer"/> integration with ASP.NET Web API.
    /// </summary>
    public static class WindsorExtensionMethods
    {
        private static IWindsorContainer GetDefaultWindsorContainer(HttpConfiguration config)
        {
            return new WindsorContainer();
        }

        /// <summary>
        /// Uses <see cref="IWindsorContainer"/> with the <paramref name="config"/>.
        /// </summary>
        /// <typeparam name="T">Type for which <see cref="Assembly"/> will be scanned for
        /// <see cref="ApiController"/> registration.</typeparam>
        /// <param name="config"></param>
        /// <param name="getContainer"></param>
        /// <param name="otherTypes"></param>
        /// <returns></returns>
        public static IWindsorContainerRegistrar ConfigureApi<T>(this HttpConfiguration config,
            WindsorContainerFactory getContainer = null, params Type[] otherTypes)
        {
            getContainer = getContainer ?? GetDefaultWindsorContainer;

            var container = getContainer(config);

            container.Install(
                new ContainerInstaller()
                , new ApiServicesInstaller()
                , new WebApiInstaller(config)
                , new ApiControllerInstaller<T>(otherTypes)
                );

            return new WindsorContainerRegistrar(config, container);
        }

        /// <summary>
        /// Uses <see cref="IWindsorContainer"/> with the <paramref name="config"/>.
        /// </summary>
        /// <param name="config"></param>
        /// <param name="rootType"><see cref="Type"/> for which <see cref="Assembly"/> will be
        /// scanned for <see cref="ApiController"/> registration.</param>
        /// <param name="getContainer"></param>
        /// <param name="otherTypes"></param>
        /// <returns></returns>
        public static IWindsorContainerRegistrar ConfigureApi(this HttpConfiguration config,
            Type rootType, WindsorContainerFactory getContainer = null, params Type[] otherTypes)
        {
            getContainer = getContainer ?? GetDefaultWindsorContainer;

            var container = getContainer(config);

            var types = new[] {rootType}.Concat(otherTypes);

            container.Install(
                new ContainerInstaller()
                , new ApiServicesInstaller()
                , new WebApiInstaller(config)
                , new ApiControllerInstaller(types)
                );

            return new WindsorContainerRegistrar(config, container);
        }
    }

    /// <summary>
    /// <see cref="IWindsorContainer"/> factory based on the <paramref name="config"/>.
    /// </summary>
    /// <param name="config"></param>
    /// <returns></returns>
    public delegate IWindsorContainer WindsorContainerFactory(HttpConfiguration config);
}
