using System.Web.Mvc;

namespace Kingdom.Web.Mvc
{
    using Castle.MicroKernel;

    /// <summary>
    /// <see cref="IViewPageActivator"/> for use with <see cref="IKernel"/>
    /// </summary>
    public interface IWindsorViewPageActivator : IViewPageActivator
    {
    }
}
