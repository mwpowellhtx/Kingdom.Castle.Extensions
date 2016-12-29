using System.Web.Http;
using System.Web.Http.Dependencies;

// ReSharper disable once CheckNamespace

namespace Kingdom.MicroKernel.Registration
{
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using Web.Http.Dependencies;

    /// <summary>
    /// Installs the <see cref="IWindsorDependencyResolver"/>
    /// </summary>
    public class ApiDependencyResolverInstaller : WindsorInstallerBase
    {
        private readonly HttpConfiguration _config;

        /// <summary>
        /// 
        /// </summary>
        public ApiDependencyResolverInstaller(HttpConfiguration config)
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
            var dependencyResolver = container.Resolve<IDependencyResolver>();
            _config.DependencyResolver = dependencyResolver;
        }
    }
}
