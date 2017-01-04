using System.Web;
using System.Web.Mvc;

namespace Kingdom.Web.Mvc.Castle.Windsor.Website
{
    public class FixtureAuthorizationFilterAttribute : AuthorizeAttribute, IFixtured, IUnfixtured
    {
        public IFixture Unfixtured { get; set; }

        [Inject]
        public IFixture Fixtured { get; set; }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            this.Verify();
            base.OnAuthorization(filterContext);
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            this.Verify();

            // In this case, we always authorize.
            return true;
        }
    }
}
