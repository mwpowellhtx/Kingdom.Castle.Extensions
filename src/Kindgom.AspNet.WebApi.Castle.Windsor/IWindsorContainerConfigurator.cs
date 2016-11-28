namespace Kingdom.Castle.Windsor.Web.Http
{
    using global::Castle.Windsor;

    /// <summary>
    /// <see cref="IWindsorContainer"/> configurator.
    /// </summary>
    public interface IWindsorContainerConfigurator
    {
        /// <summary>
        /// Configures the <see cref="IWindsorContainer"/> after registration.
        /// </summary>
        /// <param name="configure"></param>
        void ConfigureWindsorContainer(ConfigureContainerCallback configure = null);
    }

    /// <summary>
    /// Configures the <paramref name="container"/>.
    /// </summary>
    /// <param name="container"></param>
    public delegate void ConfigureContainerCallback(IWindsorContainer container);
}
