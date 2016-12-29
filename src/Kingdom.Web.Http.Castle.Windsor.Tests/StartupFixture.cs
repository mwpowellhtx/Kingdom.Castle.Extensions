using System.Web.Http;

namespace Kingdom.Web.Http
{
    using Owin;
    using global::Castle.Windsor;

    public class StartupFixture : Startup
    {
        protected IWindsorContainer Container { get; private set; }

        public override void Configuration(IAppBuilder app)
        {
            base.Configuration(app);

            Container = new WindsorContainer();

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
