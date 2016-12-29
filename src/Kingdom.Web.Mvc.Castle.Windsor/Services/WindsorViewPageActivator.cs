using System;
using System.Web.Mvc;

namespace Kingdom.Web.Mvc
{
    using Castle.MicroKernel;

    /// <summary>
    /// <see cref="IViewPageActivator"/> for use with <see cref="IKernel"/>.
    /// </summary>
    public class WindsorViewPageActivator : WindsorServiceBase, IWindsorViewPageActivator
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="kernel"></param>
        public WindsorViewPageActivator(IKernel kernel)
            : base(kernel)
        {
        }

        /// <summary>
        /// Returns the view resolved by the <see cref="IKernel"/>.
        /// </summary>
        /// <param name="controllerContext"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public object Create(ControllerContext controllerContext, Type type)
        {
            return Kernel.Resolve(type);
        }
    }
}
