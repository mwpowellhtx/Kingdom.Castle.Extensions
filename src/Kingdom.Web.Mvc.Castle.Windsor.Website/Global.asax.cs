using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.MicroKernel.Registration;

namespace Kingdom.Web.Mvc.Castle.Windsor.Website
{
    using Controllers;
    using global::Castle.Windsor;

    public class MvcApplication : HttpApplication
    {
        private IWindsorContainer Container { get; }

        public MvcApplication()
        {
            Container = new WindsorContainer();
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Assumes filters, routes, bundles, etc, have all been configured.
            Container.InstallMvcServices<HomeController>()
                .UseDependencyResolver()
                ;

            Container.Register(
                Component.For<IFixture>()
                    .ImplementedBy<Fixture>().LifestyleTransient()
            );
        }
    }
}
