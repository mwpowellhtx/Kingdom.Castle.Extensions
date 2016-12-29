using System.Web.Http.Dependencies;

namespace Kingdom.Web.Http.Dependencies
{
    using Castle.Windsor;

    /// <summary>
    /// Provides a Castle Windsor based <see cref="IDependencyResolver"/>.
    /// </summary>
    public interface IWindsorDependencyResolver : IDependencyResolver
    {
        /// <summary>
        /// Gets the Container associated with the <see cref="IDependencyResolver"/>.
        /// </summary>
        IWindsorContainer Container { get; }
    }
}
