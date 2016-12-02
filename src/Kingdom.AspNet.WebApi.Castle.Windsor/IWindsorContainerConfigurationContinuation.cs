namespace Kingdom.Castle.Windsor.Web.Http
{
    using global::Castle.Windsor;

    /// <summary>
    /// <see cref="IWindsorContainer"/> configurator.
    /// </summary>
    public interface IWindsorContainerConfigurationContinuation
    {
        /// <summary>
        /// Configures the <see cref="IWindsorContainer"/> after registration.
        /// </summary>
        /// <param name="configure"></param>
        /// <returns></returns>
        IWindsorContainerConfigurationContinuation ContinueWith(ContainerConfigurationCallback configure = null);
    }

    /// <summary>
    /// Continues the <paramref name="container"/> configuration with any other elements.
    /// </summary>
    /// <param name="container"></param>
    public delegate void ContainerConfigurationCallback(IWindsorContainer container);
}
