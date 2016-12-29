using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

/* TODO: TBD: also includes a reference to System.Web... may be important for packaging purposes,
 * such as into projects that were not necessary Web oriented before adding the package reference... */

namespace Kingdom.Web.Mvc
{
    using Castle.MicroKernel;

    /// <summary>
    /// <see cref="IControllerFactory"/> for use with <see cref="IKernel"/>.
    /// </summary>
    public class WindsorControllerFactory : DefaultControllerFactory, IWindsorControllerFactory
    {
        private readonly IKernel _kernel;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="kernel"></param>
        public WindsorControllerFactory(IKernel kernel)
        {
            _kernel = kernel;
        }

        /// <summary>
        /// Releases the <paramref name="controller"/>.
        /// </summary>
        /// <param name="controller"></param>
        public override void ReleaseController(IController controller)
        {
            _kernel.ReleaseComponent(controller);
        }

        /// <summary>
        /// Returns the <see cref="IController"/> instance corresponding to the <paramref name="controllerType"/>.
        /// </summary>
        /// <param name="requestContext"></param>
        /// <param name="controllerType"></param>
        /// <returns></returns>
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType != null)
            {
                return (IController) _kernel.Resolve(controllerType);
            }

            var message = $"The controller for path '{requestContext.HttpContext.Request.Path}' could not be found.";
            throw new HttpException(404, message);
        }
    }
}
