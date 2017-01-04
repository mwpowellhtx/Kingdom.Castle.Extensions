using System.Web.Mvc;

namespace Kingdom.Web.Mvc.Castle.Windsor.Website.Controllers
{
    public class HomeController : Controller
    {
        [FixtureAuthorizationFilter]
        public ActionResult Index()
        {
            return View();
        }

        [FixtureExceptionFilter]
        public ActionResult Exceptional()
        {
            ViewBag.Message = "This action is exceptional.";

            return View();
        }

        [FixtureActionFilter]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [FixtureResultFilter]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}