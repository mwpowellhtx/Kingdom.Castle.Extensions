using System;
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
        private readonly IWindsorContainer _container;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="container"></param>
        public WindsorControllerActionInvoker(IWindsorContainer container)
        {
            _container = container;
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

            /* TODO: TBD: assuming that the filters are all of the type IMvcFilter... if not, that's a
             * problem... or we just need to identify the general type, not respective of IMvcFilter... */

            var filters = filterInfo.AuthorizationFilters.Cast<object>()
                    .Concat(filterInfo.ActionFilters)
                    .Concat(filterInfo.ResultFilters)
                    .Concat(filterInfo.ExceptionFilters)
                    .OfType<IMvcFilter>().ToList()
                ;

            Action<IMvcFilter> inject = f => _container.InjectFilter(f);

            filters.ForEach(inject);

            return filterInfo;
        }
    }
}
