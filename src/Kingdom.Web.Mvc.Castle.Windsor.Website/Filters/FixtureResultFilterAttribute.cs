using System.Web.Mvc;

namespace Kingdom.Web.Mvc.Castle.Windsor.Website
{
    public class FixtureResultFilterAttribute : ActionFilterAttribute, IFixtured, IUnfixtured
    {
        public IFixture Unfixtured { get; set; }

        [Inject]
        public IFixture Fixtured { get; set; }

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
