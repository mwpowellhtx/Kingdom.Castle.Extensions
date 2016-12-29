using System;
using System.Reflection;

namespace Kingdom.Web.Mvc.MicroKernel.Registration
{
    using global::Castle.MicroKernel.Registration;
    using global::Castle.MicroKernel.SubSystems.Configuration;
    using global::Castle.Windsor;

    /// <summary>
    /// <see cref="IWindsorInstaller"/> base class.
    /// </summary>
    public abstract class WindsorInstallerBase : IWindsorInstaller
    {
        /// <summary>
        /// Installs using the <paramref name="container"/> and <paramref name="store"/>.
        /// </summary>
        /// <param name="container"></param>
        /// <param name="store"></param>
        public abstract void Install(IWindsorContainer container, IConfigurationStore store);

        /// <summary>
        /// Registers the <typeparamref name="TService"/> providing a <paramref name="container"/>
        /// and the <paramref name="register"/>.
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="container"></param>
        /// <param name="register"></param>
        protected void RegisterComponent<TService>(IWindsorContainer container,
            Func<ComponentRegistration<TService>, IRegistration> register = null)
            where TService : class
        {
            register = register ?? DefaultRegister;

            container.Register(
                register(Component.For<TService>())
            );
        }

        /// <summary>
        /// Registers the <see cref="Classes"/> corresponding to the <typeparamref name="T"/>
        /// type found in the <paramref name="assembly"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="container"></param>
        /// <param name="assembly"></param>
        /// <param name="register"></param>
        protected void RegisterClasses<T>(IWindsorContainer container, Assembly assembly,
            Func<BasedOnDescriptor, IRegistration> register = null)
        {
            register = register ?? DefaultRegister;

            container.Register(
                register(Classes.FromAssembly(assembly).BasedOn<T>())
            );
        }

        private static IRegistration DefaultRegister<TService>(ComponentRegistration<TService> registration)
            where TService : class
        {
            return registration;
        }

        private static IRegistration DefaultRegister(BasedOnDescriptor descriptor)
        {
            return descriptor;
        }
    }
}
