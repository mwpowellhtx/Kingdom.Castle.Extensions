using System.Web.Http.Dependencies;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Hosting;
using System.Web.Http.Owin;

// ReSharper disable once CheckNamespace

namespace Kingdom.MicroKernel.Registration
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using Web.Http.Dependencies;

    /// <summary>
    /// Installs global Web API services with the <see cref="IWindsorContainer"/>.
    /// </summary>
    public class ApiServicesInstaller : WindsorInstallerBase
    {
        /// <summary>
        /// Registers the <see cref="IExceptionHandler"/> with a
        /// <see cref="NullExceptionHandler"/>. Override to specialize the registration.
        /// </summary>
        /// <param name="registration"></param>
        /// <returns></returns>
        protected virtual IRegistration RegisterExceptionHandler(ComponentRegistration<IExceptionHandler> registration)
        {
            return registration.ImplementedBy<NullExceptionHandler>().LifestyleSingleton();
        }

        /// <summary>
        /// Registers the <see cref="IHostBufferPolicySelector"/> as an
        /// <see cref="OwinBufferPolicySelector"/>. Override to specialize the registration.
        /// </summary>
        /// <param name="registration"></param>
        /// <returns></returns>
        protected virtual IRegistration RegisterHostBufferPolicySelector(
            ComponentRegistration<IHostBufferPolicySelector> registration)
        {
            return registration.ImplementedBy<OwinBufferPolicySelector>().LifestyleSingleton();
        }

        /// <summary>
        /// Registers the <see cref="IDependencyResolver"/> as a
        /// <see cref="WindsorDependencyResolver"/>. Override to specialize the registration.
        /// </summary>
        /// <param name="registration"></param>
        /// <returns></returns>
        protected virtual IRegistration RegisterDependencyResolver(
            ComponentRegistration<IDependencyResolver> registration)
        {
            return registration.ImplementedBy<WindsorDependencyResolver>().LifestyleSingleton();
        }

        /// <summary>
        /// Installs using the <paramref name="container"/> and <paramref name="store"/>.
        /// </summary>
        /// <param name="container"></param>
        /// <param name="store"></param>
        public override void Install(IWindsorContainer container, IConfigurationStore store)
        {
            RegisterComponent<IExceptionHandler>(container, RegisterExceptionHandler);
            RegisterComponent<IHostBufferPolicySelector>(container, RegisterHostBufferPolicySelector);
            RegisterComponent<IDependencyResolver>(container, RegisterDependencyResolver);
        }
    }
}
