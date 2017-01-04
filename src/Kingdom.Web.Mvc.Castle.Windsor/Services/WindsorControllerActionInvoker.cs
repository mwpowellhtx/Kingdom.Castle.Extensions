using System.Linq;
using System.Web.Mvc;

namespace Kingdom.Web.Mvc
{
    using Castle.Windsor;

    /// <summary>
    /// <see cref="ControllerActionInvoker"/> for use with <see cref="IWindsorContainer"/>.
    /// </summary>
    public class WindsorControllerActionInvoker : ControllerActionInvoker, IWindsorActionInvoker
    {
        private IWindsorContainer Container { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="container"></param>
        public WindsorControllerActionInvoker(IWindsorContainer container)
        {
            Container = container;
        }

        private void InjectFilter<T>(T obj)
        {
            Container.InjectObject(obj);
        }

        /// <summary>
        /// Returns the <see cref="FilterInfo"/> corresponding to the
        /// <paramref name="controllerContext"/> or <paramref name="actionDescriptor"/>.
        /// </summary>
        /// <param name="controllerContext"></param>
        /// <param name="actionDescriptor"></param>
        /// <returns></returns>
        protected override FilterInfo GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            var filterInfo = base.GetFilters(controllerContext, actionDescriptor);

            // We must treat each of the Filter types individually.
            filterInfo.AuthorizationFilters.ToList().ForEach(InjectFilter);
            filterInfo.ActionFilters.ToList().ForEach(InjectFilter);
            filterInfo.ResultFilters.ToList().ForEach(InjectFilter);
            filterInfo.ExceptionFilters.ToList().ForEach(InjectFilter);

            return filterInfo;
        }
    }
}
