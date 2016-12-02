using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Hosting;

namespace CastleWindsor.WebApi.Console
{
    using Kingdom.MicroKernel.Registration;
    using Owin;
    using global::Castle.Windsor;

    public class ValuesController : ApiController
    {
        private readonly int[] _values = {0, 1, 2, 3};

        public IEnumerable<int> Get()
        {
            return _values;
        }

        public int Get(int value)
        {
            return _values.Contains(value) ? value : -1;
        }
    }

    // TODO: TBD: this is how to start an OWIN self hosted Web API server.
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            // TODO: TBD: provide a means of connecting the Container with the caller?
            var container = new WindsorContainer();

            container.Install(
                new ContainerInstaller()
                , new ApiServicesInstaller()
                , new WebApiInstaller(config)
                , new ApiControllerInstaller<Program>()
                , new WindsorDependencyResolverInstaller(config)
                );

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "DefaultApi", "api/{controller}/{value}",
                new {value = RouteParameter.Optional});

            app.UseWebApi(config);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            const string url = "http://localhost:9182";

            using (WebApp.Start<Startup>(url))
            {
                using (var client = new HttpClient {BaseAddress = new Uri(url)})
                {
                    var response = client.GetAsync("api/values").Result;
                    Debug.Assert(response.StatusCode == HttpStatusCode.OK);
                }
            }
        }
    }
}
