using System.Web.Http;

namespace Kingdom.AspNet.WebApi.Castle.Windsor
{
    using Kingdom.Castle.Windsor.Web.Http;
    using Owin;
    using OwinStartupAttribute = Microsoft.Owin.OwinStartupAttribute;

#pragma warning disable 657
    [assembly: OwinStartup(typeof(StartupFixture))]
#pragma warning restore 657
   
    public class StartupFixture : Startup
    {
        public override void Configuration(IAppBuilder app)
        {
            base.Configuration(app);

            var config = Config;

            config.ConfigureApi<StartupFixture>()
                .ConfigureDependencyResolver();

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "DefaultApi", "api/{controller}/{id}",
                new {id = RouteParameter.Optional});

            app.UseWebApi(config);
        }
    }
}
