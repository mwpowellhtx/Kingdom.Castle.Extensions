using System.Web.Http.Dependencies;
using Castle.Windsor;

namespace Kingdom.Castle.Windsor.Web.Http.Dependencies
{
    /// <summary>
    /// Provides a Castle Windsor based <see cref="IDependencyScope"/>.
    /// </summary>
    public class WindsorDependencyScope : WindsorDependencyBase, IWindsorDependencyScope
    {
        internal WindsorDependencyScope(IWindsorContainer container)
            : base(container)
        {
        }
    }
}
