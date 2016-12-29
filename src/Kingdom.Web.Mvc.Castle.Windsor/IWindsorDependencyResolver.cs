using System.Web.Mvc;

namespace Kingdom.Web.Mvc
{
    using Castle.MicroKernel;
    // Avoid type collision with Castle.MicroKernel.IDependencyResolver, which is not the same thing.
    using IMvcDependencyResolver = IDependencyResolver;

    /// <summary>
    /// Establishes an Mvc <see cref="IMvcDependencyResolver"/> for use with an <see cref="IKernel"/>.
    /// </summary>
    public interface IWindsorDependencyResolver : IMvcDependencyResolver
    {
    }
}
