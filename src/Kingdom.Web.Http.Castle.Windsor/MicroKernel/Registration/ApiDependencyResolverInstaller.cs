using System.Web.Http;
using System.Web.Http.Dependencies;
using Castle.MicroKernel.Registration;

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
        /// Registers <typeparamref name="T"/> as a <see cref="IWindsorDependencyResolver"/> using
        /// web request lifecycle, with forward to <see cref="IDependencyResolver"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected virtual IRegistration RegisterDependencyResolver<T>()
            where T : class, IWindsorDependencyResolver
        {
            return Component.For<IWindsorDependencyResolver>()
                .Forward<IDependencyResolver>()
                .LifestylePerWebRequest();
        }

        /// <summary>
        /// Installs using the <paramref name="container"/> and <paramref name="store"/>.
        /// </summary>
        /// <param name="container"></param>
        /// <param name="store"></param>
        public override void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // Actually register the Dependency Resolver, then Resolve it.
            RegisterDependencyResolver<WindsorDependencyResolver>();
            var dependencyResolver = container.Resolve<IDependencyResolver>();
            _config.DependencyResolver = dependencyResolver;
        }
    }
}
