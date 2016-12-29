using System.Web.Mvc;

namespace Kingdom.Web.Mvc
{
    using Castle.Windsor;

    /// <summary>
    /// <see cref="IActionInvoker"/> for use with <see cref="IWindsorContainer"/>.
    /// </summary>
    public interface IWindsorActionInvoker : IActionInvoker
    {
    }
}
