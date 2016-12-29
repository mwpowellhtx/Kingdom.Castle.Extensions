namespace Kingdom.Web.Mvc
{
    using Castle.MicroKernel;

    /// <summary>
    /// Represents the basic Windsor Service.
    /// </summary>
    public abstract class WindsorServiceBase
    {
        /// <summary>
        /// Gets the Kernel.
        /// </summary>
        protected IKernel Kernel { get; }

        /// <summary>
        /// Protected Constructor
        /// </summary>
        /// <param name="kernel"></param>
        protected WindsorServiceBase(IKernel kernel)
        {
            Kernel = kernel;
        }
    }
}
