using System;
using System.Web.Http;
using Castle.Windsor;

namespace Kingdom.Castle.Windsor.Web.Http
{
    using Dependencies;

    /// <summary>
    /// Provides some Bootstrapping for purposes of integrating Castle Windsor into the ASP.NET
    /// WebApi2 stack.
    /// </summary>
    public static class WindsorBootstrapper
    {
        private static IWindsorContainer CreateContainer()
        {
            return new WindsorContainer();
        }

        private static IWindsorDependencyResolver CreateDependencyResolver(IWindsorContainer container)
        {
            return new WindsorDependencyResolver(container);
        }

        /// <summary>
        /// Registers an <see cref="IWindsorContainer"/> with the <paramref name="config"/> via
        /// <see cref="WindsorDependencyResolver"/>.
        /// </summary>
        /// <param name="config"></param>
        /// <param name="getContainer">You may provide your own <see cref="IWindsorContainer"/>.
        /// The default will be the default <see cref="WindsorContainer"/> via parameterless
        /// constructor.</param>
        /// <param name="getDependencyResolver">You may provide your own specialization of the
        /// <see cref="IWindsorDependencyResolver"/>. The default will be
        /// <see cref="WindsorDependencyResolver"/>.</param>
        /// <returns></returns>
        public static IWindsorContainer Register(HttpConfiguration config,
            Func<IWindsorContainer> getContainer = null,
            Func<IWindsorContainer, IWindsorDependencyResolver> getDependencyResolver = null)
        {
            getContainer = getContainer ?? CreateContainer;
            getDependencyResolver = getDependencyResolver ?? CreateDependencyResolver;

            var container = getContainer();

            // This is all there is to it.
            config.DependencyResolver = getDependencyResolver(container);

            return container;
        }
    }
}
