using System.Web.Http.Dependencies;

namespace Kingdom.Castle.Windsor.Web.Http.Dependencies
{
    using global::Castle.Windsor;

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
