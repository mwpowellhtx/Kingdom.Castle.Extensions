using System.Web.Http.ExceptionHandling;
using System.Web.Http.Hosting;
using System.Web.Http.Owin;

// ReSharper disable once CheckNamespace
namespace Kingdom.MicroKernel.Registration
{
    using global::Castle.MicroKernel.Registration;
    using global::Castle.MicroKernel.SubSystems.Configuration;
    using global::Castle.Windsor;

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
        protected virtual IRegistration RegisterHostBufferPolicySelector(ComponentRegistration<IHostBufferPolicySelector> registration)
        {
            return registration.ImplementedBy<OwinBufferPolicySelector>().LifestyleSingleton();
        }

        public override void Install(IWindsorContainer container, IConfigurationStore store)
        {
            RegisterComponent<IExceptionHandler>(container, RegisterExceptionHandler);
            RegisterComponent<IHostBufferPolicySelector>(container, RegisterHostBufferPolicySelector);
        }
    }
}
