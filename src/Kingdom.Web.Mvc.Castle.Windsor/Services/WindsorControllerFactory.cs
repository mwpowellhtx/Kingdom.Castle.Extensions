using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Kingdom.Web.Mvc
{
    using Castle.MicroKernel;

    /// <summary>
    /// <see cref="IControllerFactory"/> for use with <see cref="IKernel"/>.
    /// </summary>
    public class WindsorControllerFactory : DefaultControllerFactory, IWindsorControllerFactory
    {
        private IKernel Kernel { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="kernel"></param>
        public WindsorControllerFactory(IKernel kernel)
        {
            Kernel = kernel;
        }

        private void ReleaseController(IDisposable disposable)
        {
            disposable?.Dispose();
            Kernel.ReleaseComponent(disposable);
        }

        /// <summary>
        /// Releases the <paramref name="controller"/>.
        /// </summary>
        /// <param name="controller"></param>
        public override void ReleaseController(IController controller)
        {
            ReleaseController((IDisposable) controller);
        }

        /// <summary>
        /// Returns the <see cref="IController"/> instance corresponding to the <paramref name="controllerType"/>.
        /// </summary>
        /// <param name="requestContext"></param>
        /// <param name="controllerType"></param>
        /// <returns></returns>
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            const int notFound = 404;

            if (controllerType == null)
            {
                throw new HttpException(notFound,
                    $"The controller for path '{requestContext.HttpContext.Request.Path}'"
                    + " could not be found.");
            }

            if (Kernel.HasComponent(controllerType))
            {
                return (IController) Kernel.Resolve(controllerType);
            }

            throw new HttpException(notFound,
                $"The controller '{controllerType.FullName}' for path"
                + $" '{requestContext.HttpContext.Request.Path}' could not be found.");
        }
    }
}
