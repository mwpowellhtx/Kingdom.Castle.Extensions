namespace Kingdom.Castle.Windsor.Web.Http.Dependencies
{
    using System.Web.Http.Dependencies;
    using global::Castle.Windsor;

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
