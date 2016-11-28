using System.Web.Http;

namespace Kingdom.Castle.Windsor.Web.Http
{
    using Dependencies;
    using global::Castle.Windsor;

    /// <summary>
    /// Provides Registrar services pertaining to the <see cref="IWindsorContainer"/>.
    /// </summary>
    public class WindsorContainerRegistrar : IWindsorContainerRegistrar
    {
        private readonly HttpConfiguration _config;

        private readonly IWindsorContainer _container;

        internal WindsorContainerRegistrar(HttpConfiguration config, IWindsorContainer container)
        {
            _config = config;
            _container = container;
        }

        /// <summary>
        /// Returns a Default <see cref="IWindsorDependencyResolver"/> based on the
        /// <paramref name="container"/>.
        /// </summary>
        /// <param name="container"></param>
        /// <returns></returns>
        private static IWindsorDependencyResolver GetDefaultDependencyResolver(IWindsorContainer container)
        {
            return new WindsorDependencyResolver(container);
        }

        /// <summary>
        /// Configures the <see cref="HttpConfiguration.DependencyResolver"/> using the
        /// <see cref="IWindsorDependencyResolver"/>.
        /// </summary>
        /// <param name="getDependencyResolver"></param>
        public IWindsorContainerConfigurator ConfigureDependencyResolver(
            WindsorDependencyResolverFactory getDependencyResolver = null)
        {
            getDependencyResolver = getDependencyResolver ?? GetDefaultDependencyResolver;
            var dependencyResolver = getDependencyResolver(_container);
            _config.DependencyResolver = dependencyResolver;
            return new WindsorContainerConfigurator(_container);
        }
    }
}
