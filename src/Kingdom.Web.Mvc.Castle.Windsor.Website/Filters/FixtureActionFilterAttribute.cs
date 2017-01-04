using System.Web.Mvc;

namespace Kingdom.Web.Mvc.Castle.Windsor.Website
{
    public class FixtureActionFilterAttribute : ActionFilterAttribute, IFixtured, IUnfixtured
    {
        public IFixture Unfixtured { get; set; }

        [Inject]
        public IFixture Fixtured { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            this.Verify();
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            this.Verify();
            base.OnActionExecuted(filterContext);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            this.Verify();
            base.OnResultExecuting(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            this.Verify();
            base.OnResultExecuted(filterContext);
        }
    }
}
