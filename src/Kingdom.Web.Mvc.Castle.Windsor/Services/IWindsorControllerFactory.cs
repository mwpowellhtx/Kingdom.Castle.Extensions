using System.Web.Mvc;

namespace Kingdom.Web.Mvc
{
    using Castle.MicroKernel;

    /// <summary>
    /// <see cref="IControllerFactory"/> for use with <see cref="IKernel"/>.
    /// </summary>
    public interface IWindsorControllerFactory : IControllerFactory
    {
    }
}
