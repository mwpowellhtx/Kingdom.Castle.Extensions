using System.Web.Http;

namespace Kingdom.Castle.Windsor.Web.Http
{
    using Dependencies;
    using global::Castle.Windsor;

    /// <summary>
    /// <see cref="IWindsorContainer"/> registrar interface.
    /// </summary>
    public interface IWindsorContainerRegistrar
    {
        /// <summary>
        /// Configures the <see cref="HttpConfiguration.DependencyResolver"/> to use the
        /// <see cref="IWindsorDependencyResolver"/>.
        /// </summary>
        /// <param name="getDependencyResolver"></param>
        void ConfigureDependencyResolver(WindsorDependencyResolverFactory getDependencyResolver = null);
    }

    /// <summary>
    /// <see cref="IWindsorDependencyResolver"/> factory based on the <paramref name="container"/>.
    /// </summary>
    /// <param name="container"></param>
    /// <returns></returns>
    public delegate IWindsorDependencyResolver WindsorDependencyResolverFactory(IWindsorContainer container);
}
