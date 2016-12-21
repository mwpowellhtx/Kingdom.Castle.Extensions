using System.Web.Http;

// ReSharper disable once CheckNamespace

namespace Kingdom.MicroKernel.Registration
{
    using Castle.Windsor.Web.Http.Dependencies;
    using global::Castle.MicroKernel.SubSystems.Configuration;
    using global::Castle.Windsor;

    /// <summary>
    /// 
    /// </summary>
    public class WindsorDependencyResolverInstaller : WindsorInstallerBase
    {
        private readonly HttpConfiguration _config;

        /// <summary>
        /// 
        /// </summary>
        public WindsorDependencyResolverInstaller(HttpConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        /// Installs using the <paramref name="container"/> and <paramref name="store"/>.
        /// </summary>
        /// <param name="container"></param>
        /// <param name="store"></param>
        public override void Install(IWindsorContainer container, IConfigurationStore store)
        {
            _config.DependencyResolver = new WindsorDependencyResolver(container);
        }
    }
}
