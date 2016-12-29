using System.Web.Http;

namespace Kingdom.Web.Http
{
    using Owin;
    using global::Castle.Windsor;

    public class StartupFixture : Startup
    {
        /// <summary>
        /// Gets the Container associated with the StartupFixture.
        /// </summary>
        protected IWindsorContainer Container { get; }

        public StartupFixture()
        {
            // Make certain that we have a Container waiting for us OnConfiguration.
            Container = new WindsorContainer();
        }

        public override void Configuration(IAppBuilder app)
        {
            base.Configuration(app);

            Container.ConfigureApi<StartupFixture>(Config);

            Config.UseWindsorDependencyResolver(Container)
                .MapHttpAttributeRoutes()
                ;

            Config.Routes.MapHttpRoute(
                "DefaultApi", "api/{controller}/{id}",
                new {id = RouteParameter.Optional});

            app.UseWebApi(Config);
        }
    }
}
