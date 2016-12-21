using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Web.Http.Metadata;
using System.Web.Http.Metadata.Providers;
using System.Web.Http.ModelBinding;
using System.Web.Http.Tracing;
using System.Web.Http.Validation;

// ReSharper disable once CheckNamespace

namespace Kingdom.MicroKernel.Registration
{
    using global::Castle.MicroKernel.Registration;
    using global::Castle.MicroKernel.SubSystems.Configuration;
    using global::Castle.Windsor;

    /// <summary>
    /// Provides a basic set of ASP.NET Web API services registered against a Castle Windsor
    /// container.
    /// </summary>
    /// <see cref="DefaultTraceManager"/>
    /// <see cref="DefaultContentNegotiator"/>
    /// <see cref="WindsorHttpControllerActivator"/>
    /// <see cref="DefaultHttpControllerSelector"/>
    /// <see cref="DefaultAssembliesResolver"/>
    /// <see cref="DefaultHttpControllerTypeResolver"/>
    /// <see cref="ApiControllerActionSelector"/>
    /// <see cref="DefaultActionValueBinder"/>
    /// <see cref="ApiControllerActionInvoker"/>
    /// <see cref="DataAnnotationsModelMetadataProvider"/>
    public class WebApiInstaller : WindsorInstallerBase
    {
        private readonly HttpConfiguration _config;

        /// <summary>
        /// Configuration Constructor
        /// </summary>
        /// <param name="config"></param>
        public WebApiInstaller(HttpConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        /// Registers the <see cref="ITraceManager"/> as a <see cref="DefaultTraceManager"/>.
        /// Override to specialize the registration.
        /// </summary>
        /// <param name="registration"></param>
        /// <returns></returns>
        protected virtual IRegistration RegisterTraceManager(
            ComponentRegistration<ITraceManager> registration)
        {
            return registration.ImplementedBy<DefaultTraceManager>().LifestyleSingleton();
        }

        /// <summary>
        /// Registers the <see cref="ITraceWriter"/> as a <see cref="DefaultTraceWriter"/>.
        /// Override to specialize the registration.
        /// </summary>
        /// <param name="registration"></param>
        /// <returns></returns>
        protected virtual IRegistration RegisterTraceWriter(
            ComponentRegistration<ITraceWriter> registration)
        {
            return registration.ImplementedBy<DefaultTraceWriter>().LifestyleSingleton();
        }

        /// <summary>
        /// Registers the <see cref="IContentNegotiator"/> as a
        /// <see cref="DefaultContentNegotiator"/>. Override to specialize the registration.
        /// </summary>
        /// <param name="registration"></param>
        /// <returns></returns>
        protected virtual IRegistration RegisterContentNegotiator(
            ComponentRegistration<IContentNegotiator> registration)
        {
            return registration.ImplementedBy<DefaultContentNegotiator>().LifestyleSingleton();
        }

        /// <summary>
        /// Registers the <see cref="IHttpControllerActivator"/> as a
        /// <see cref="WindsorHttpControllerActivator"/>. Override to specialize the registration.
        /// </summary>
        /// <param name="registration"></param>
        /// <returns></returns>
        protected virtual IRegistration RegisterHttpControllerActivator(
            ComponentRegistration<IHttpControllerActivator> registration)
        {
            return registration.ImplementedBy<WindsorHttpControllerActivator>().LifestyleSingleton();
        }

        /// <summary>
        /// Registers the <see cref="IHttpControllerSelector"/> as a
        /// <see cref="DefaultHttpControllerSelector"/>. Override to specialize the registration.
        /// </summary>
        /// <param name="registration"></param>
        /// <returns></returns>
        protected virtual IRegistration RegisterHttpControllerSelector(
            ComponentRegistration<IHttpControllerSelector> registration)
        {
            return registration.ImplementedBy<DefaultHttpControllerSelector>().LifestyleSingleton();
        }

        /// <summary>
        /// Registers the <see cref="IAssembliesResolver"/> as a
        /// <see cref="DefaultAssembliesResolver"/>. Override to specialize the registration.
        /// </summary>
        /// <param name="registration"></param>
        /// <returns></returns>
        protected virtual IRegistration RegisterAssembliesResolver(
            ComponentRegistration<IAssembliesResolver> registration)
        {
            return registration.ImplementedBy<DefaultAssembliesResolver>().LifestyleSingleton();
        }

        /// <summary>
        /// Registers the <see cref="IHttpControllerTypeResolver"/> as a <see
        /// cref="DefaultHttpControllerTypeResolver"/>. Override to specialize the registration.
        /// </summary>
        /// <param name="registration"></param>
        /// <returns></returns>
        protected virtual IRegistration RegisterHttpControllerTypeResolver(
            ComponentRegistration<IHttpControllerTypeResolver> registration)
        {
            return registration.ImplementedBy<DefaultHttpControllerTypeResolver>().LifestyleSingleton();
        }

        /// <summary>
        /// Registers the <see cref="IHttpActionSelector"/> as a <see
        /// cref="ApiControllerActionSelector"/>. Override to specialize the registration.
        /// </summary>
        /// <param name="registration"></param>
        /// <returns></returns>
        protected virtual IRegistration RegisterHttpActionSelector(
            ComponentRegistration<IHttpActionSelector> registration)
        {
            return registration.ImplementedBy<ApiControllerActionSelector>().LifestyleSingleton();
        }

        /// <summary>
        /// Registers the <see cref="IActionValueBinder"/> as a <see
        /// cref="DefaultActionValueBinder"/>. Override to specialize the registration.
        /// </summary>
        /// <param name="registration"></param>
        /// <returns></returns>
        protected virtual IRegistration RegisterActionValueBinder(
            ComponentRegistration<IActionValueBinder> registration)
        {
            return registration.ImplementedBy<DefaultActionValueBinder>().LifestyleSingleton();
        }

        /// <summary>
        /// Registers the <see cref="IBodyModelValidator"/> as a <see
        /// cref="DefaultBodyModelValidator"/>. Override to specialize the registration.
        /// </summary>
        /// <param name="registration"></param>
        /// <returns></returns>
        protected virtual IRegistration RegisterBodyModelValidator(
            ComponentRegistration<IBodyModelValidator> registration)
        {
            return registration.ImplementedBy<DefaultBodyModelValidator>().LifestyleSingleton();
        }

        /// <summary>
        /// Registers the <see cref="IHttpActionInvoker"/> as a <see
        /// cref="ApiControllerActionInvoker"/>. Override to specialize the registration.
        /// </summary>
        /// <param name="registration"></param>
        /// <returns></returns>
        protected virtual IRegistration RegisterHttpActionInvoker(
            ComponentRegistration<IHttpActionInvoker> registration)
        {
            return registration.ImplementedBy<ApiControllerActionInvoker>().LifestyleSingleton();
        }

        /// <summary>
        /// Registers the <see cref="ModelMetadataProvider"/> as a
        /// <see cref="DataAnnotationsModelMetadataProvider"/>. Override to specialize the
        /// registration.
        /// </summary>
        /// <param name="registration"></param>
        /// <returns></returns>
        protected virtual IRegistration RegisterModelMetadataProvider(
            ComponentRegistration<ModelMetadataProvider> registration)
        {
            return registration.ImplementedBy<DataAnnotationsModelMetadataProvider>().LifestyleSingleton();
        }

        /// <summary>
        /// Installs using the <paramref name="container"/> and <paramref name="store"/>.
        /// </summary>
        /// <param name="container"></param>
        /// <param name="store"></param>
        public override void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var c = container;

            // Required for configuring the components.
            RegisterComponent<HttpConfiguration>(c, r => r.Instance(_config));

            // TODO: TBD: if may be better/acceptable to provide "default" services from the resolver / global config instead...

            // Notice the progression of the Web API lifecycle. This is the natural progression.
            RegisterComponent<ITraceWriter>(c, RegisterTraceWriter);
            RegisterComponent<ITraceManager>(c, RegisterTraceManager);
            RegisterComponent<IContentNegotiator>(c, RegisterContentNegotiator);
            RegisterComponent<IHttpControllerActivator>(c, RegisterHttpControllerActivator);
            RegisterComponent<IHttpControllerSelector>(c, RegisterHttpControllerSelector);
            RegisterComponent<IAssembliesResolver>(c, RegisterAssembliesResolver);
            RegisterComponent<IHttpControllerTypeResolver>(c, RegisterHttpControllerTypeResolver);
            RegisterComponent<IHttpActionSelector>(c, RegisterHttpActionSelector);
            RegisterComponent<IActionValueBinder>(c, RegisterActionValueBinder);
            RegisterComponent<IBodyModelValidator>(c, RegisterBodyModelValidator);
            RegisterComponent<IHttpActionInvoker>(c, RegisterHttpActionInvoker);
            RegisterComponent<ModelMetadataProvider>(c, RegisterModelMetadataProvider);

            _config.Services.Replace(typeof(ITraceWriter), c.Resolve<ITraceWriter>());
            _config.Services.Replace(typeof(IHttpControllerSelector), c.Resolve<IHttpControllerSelector>());
            _config.Services.Replace(typeof(IAssembliesResolver), c.Resolve<IAssembliesResolver>());
            _config.Services.Replace(typeof(IHttpControllerTypeResolver), c.Resolve<IHttpControllerTypeResolver>());
            _config.Services.Replace(typeof(IHttpActionSelector), c.Resolve<IHttpActionSelector>());
            _config.Services.Replace(typeof(IActionValueBinder), c.Resolve<IActionValueBinder>());
            _config.Services.Replace(typeof(IBodyModelValidator), c.Resolve<IBodyModelValidator>());
            _config.Services.Replace(typeof(IHttpActionInvoker), c.Resolve<IHttpActionInvoker>());
        }
    }
}
