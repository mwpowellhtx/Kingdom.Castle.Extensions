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
        /// Registers <typeparamref name="T"/> as a <see cref="IWindsorControllerFactory"/> using
        /// with forwarding to <see cref="IControllerFactory"/> and singleton lifecycle.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual IRegistration RegisterControllerFactory<T>()
            where T : class, IWindsorControllerFactory
        {
            return Component.For<IWindsorControllerFactory, IControllerFactory>()
                .ImplementedBy<T>().LifestyleSingleton();
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
            return Component.For<IWindsorDependencyResolver, IMvcDependencyResolver>()
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
                .ImplementedBy<T>().LifestyleTransient();
        }

        /// <summary>
        /// Installs
        /// </summary>
        /// <param name="container"></param>
        /// <param name="store"></param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // Remember to also apply the Registrations in Container.
            container.Register(
                RegisterControllerFactory<WindsorControllerFactory>()
                , RegisterViewPageActivator<WindsorViewPageActivator>()
                , RegisterDependencyResolver<WindsorDependencyResolver>()
                , RegisterActionInvoker<WindsorControllerActionInvoker>()
            );
        }
    }
}
