using System.Web.Mvc;

namespace Kingdom.Web.Mvc.MicroKernel.Registration
{
    using Castle.MicroKernel;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    // Must do this to avoid type confusion with Castle.MicroKernel.IDependencyResolver, not the same thing.
    using IMvcDependencyResolver = IDependencyResolver;

    /// <summary>
    /// <see cref="IKernel"/> installer for use with <see cref="IWindsorContainer"/> specific Mvc
    /// Services.
    /// </summary>
    public class MvcServicesInstaller : IWindsorInstaller
    {
        /// <summary>
        /// Registers <typeparamref name="T"/> as a <see cref="IControllerFactory"/> using
        /// per web request lifecycle.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual IRegistration RegisterControllerFactory<T>()
            where T : class, IControllerFactory
        {
            return Component.For<IControllerFactory>()
                .ImplementedBy<T>().LifestylePerWebRequest();
        }

        /// <summary>
        /// Registers <typeparamref name="T"/> as a <see cref="IViewPageActivator"/> using
        /// per web request lifecycle.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual IRegistration RegisterViewPageActivator<T>()
            where T : class, IViewPageActivator
        {
            return Component.For<IViewPageActivator>()
                .ImplementedBy<T>().LifestylePerWebRequest();
        }

        /// <summary>
        /// Registers <typeparamref name="T"/> as a <see cref="IWindsorDependencyResolver"/> using
        /// singleton lifecycle, with a forward to <see cref="IMvcDependencyResolver"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual IRegistration RegisterDependencyResolver<T>()
            where T : class, IWindsorDependencyResolver
        {
            return Component.For<IWindsorDependencyResolver>()
                .Forward<IMvcDependencyResolver>()
                .ImplementedBy<T>().LifestyleSingleton();
        }

        /// <summary>
        /// Registers <typeparamref name="T"/> as a <see cref="IActionInvoker"/> using
        /// per web request lifecycle.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual IRegistration RegisterActionInvoker<T>()
            where T : class, IActionInvoker
        {
            return Component.For<IActionInvoker>()
                .ImplementedBy<T>().LifestylePerWebRequest();
        }

        /// <summary>
        /// Installs
        /// </summary>
        /// <param name="container"></param>
        /// <param name="store"></param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            RegisterControllerFactory<WindsorControllerFactory>();
            RegisterViewPageActivator<WindsorViewPageActivator>();
            RegisterDependencyResolver<WindsorDependencyResolver>();
            RegisterActionInvoker<WindsorControllerActionInvoker>();
        }
    }
}
