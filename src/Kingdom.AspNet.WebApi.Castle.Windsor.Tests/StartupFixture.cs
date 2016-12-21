using System.Web.Http;

namespace Kingdom.AspNet.WebApi.Castle.Windsor
{
    using Kingdom.Castle.Windsor.Web.Http;
    using Owin;
    using global::Castle.Windsor;

    public class StartupFixture : Startup
    {
        protected IWindsorContainer Container { get; private set; }

        public override void Configuration(IAppBuilder app)
        {
            base.Configuration(app);

            var config = Config;

            config.ConfigureApi<StartupFixture>()
                .ConfigureDependencyResolver()
                .ContinueWith(container => Container = container);

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "DefaultApi", "api/{controller}/{id}",
                new {id = RouteParameter.Optional});

            app.UseWebApi(config);
        }
    }
}
