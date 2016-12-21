namespace Kingdom.Castle.Windsor.Web.Http
{
    using global::Castle.Windsor;

    /// <summary>
    /// <see cref="IWindsorContainer"/> configurator implementation.
    /// </summary>
    public class WindsorContainerConfigurationContinuation : IWindsorContainerConfigurationContinuation
    {
        private readonly IWindsorContainer _container;

        internal WindsorContainerConfigurationContinuation(IWindsorContainer container)
        {
            _container = container;

            //// Must register the Container with itself.
            //_container.Register(
            //    Component.For<IWindsorContainer>().Instance(_container)
            //    );
        }

        private static readonly ContainerConfigurationCallback DefaultCallback = delegate { };

        /// <summary>
        /// Continues the configuration with the <paramref name="configure"/> callback.
        /// </summary>
        /// <param name="configure"></param>
        /// <returns></returns>
        public IWindsorContainerConfigurationContinuation ContinueWith(ContainerConfigurationCallback configure = null)
        {
            configure = configure ?? DefaultCallback;
            configure(_container);
            return this;
        }
    }
}
