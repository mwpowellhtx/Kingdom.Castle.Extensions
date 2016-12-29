using System.Web.Http.Dependencies;

namespace Kingdom.Web.Http.Dependencies
{
    using Castle.Windsor;

    /// <summary>
    /// Provides a Castle Windsor based <see cref="IDependencyResolver"/>.
    /// </summary>
    public class WindsorDependencyResolver : WindsorDependencyBase, IWindsorDependencyResolver
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="container"></param>
        public WindsorDependencyResolver(IWindsorContainer container)
            : base(container)
        {
        }

        /// <summary>
        /// Begins the <see cref="IDependencyScope"/> scope.
        /// </summary>
        /// <returns></returns>
        public virtual IDependencyScope BeginScope()
        {
            return new WindsorDependencyScope(Container);
        }
    }
}
