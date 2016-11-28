namespace Kingdom.Castle.Windsor.Web.Http
{
    using global::Castle.Windsor;

    /// <summary>
    /// <see cref="IWindsorContainer"/> configurator implementation.
    /// </summary>
    public class WindsorContainerConfigurator : IWindsorContainerConfigurator
    {
        private readonly IWindsorContainer _container;

        internal WindsorContainerConfigurator(IWindsorContainer container)
        {
            _container = container;
        }

        private static readonly ConfigureContainerCallback DefaultCallback = delegate { };

        public void ConfigureWindsorContainer(ConfigureContainerCallback configure = null)
        {
            configure = configure ?? DefaultCallback;
            configure(_container);
        }
    }
}
