using System.Web.Http;

namespace Kingdom.Castle.Windsor.Web.Http
{
    using Owin;
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
        /// <param name="app"></param>
        /// <param name="config"></param>
        /// <param name="getContainer"></param>
        /// <returns></returns>
        public static IWindsorContainerRegistrar UseCastleWindsor(this IAppBuilder app,
            HttpConfiguration config, WindsorContainerFactory getContainer = null)
        {
            getContainer = getContainer ?? GetDefaultWindsorContainer;
            return new WindsorContainerRegistrar(config, getContainer(config));
        }
    }

    /// <summary>
    /// <see cref="IWindsorContainer"/> factory based on the <paramref name="config"/>.
    /// </summary>
    /// <param name="config"></param>
    /// <returns></returns>
    public delegate IWindsorContainer WindsorContainerFactory(HttpConfiguration config);
}
