using System.Web.Mvc;

namespace Kingdom.Web.Mvc.Castle.Windsor.Website
{
    public class FixtureExceptionFilterAttribute : HandleErrorAttribute, IFixtured, IUnfixtured
    {
        public IFixture Unfixtured { get; set; }

        [Inject]
        public IFixture Fixtured { get; set; }

        public override void OnException(ExceptionContext filterContext)
        {
            this.Verify();
            base.OnException(filterContext);
        }
    }
}
