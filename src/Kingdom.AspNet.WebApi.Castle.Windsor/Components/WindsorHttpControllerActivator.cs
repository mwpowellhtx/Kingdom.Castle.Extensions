using System.Net.Http;
using System.Web.Http.Controllers;

// ReSharper disable once CheckNamespace
namespace System.Web.Http.Dispatcher
{
    // ReSharper disable once RedundantNameQualifier
    using global::Castle.Windsor;

    /// <summary>
    /// Castle Windsor <see cref="IHttpControllerActivator"/>.
    /// </summary>
    public class WindsorHttpControllerActivator : IHttpControllerActivator
    {
        private class ControllerReleaseAgent : IDisposable
        {
            private readonly IWindsorContainer _container;

            private readonly IHttpController _ctrl;

            internal ControllerReleaseAgent(IWindsorContainer container, IHttpController ctrl)
            {
                _container = container;
                _ctrl = ctrl;
            }

            public void Dispose()
            {
                _container.Release(_ctrl);
            }
        }

        private readonly IWindsorContainer _container;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="container"></param>
        public WindsorHttpControllerActivator(IWindsorContainer container)
        {
            _container = container;
        }

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor ctrlDescriptor, Type ctrlType)
        {
            var ctrl = (IHttpController) _container.Resolve(ctrlType);

            request.RegisterForDispose(
                new ControllerReleaseAgent(_container, ctrl)
                );

            return ctrl;
        }
    }
}
