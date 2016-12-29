namespace Kingdom.Web.Mvc.MicroKernel.Registration
{
    using Castle.MicroKernel;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    /// <summary>
    /// Provides Container level resolution for <see cref="IWindsorContainer"/> and
    /// <see cref="IKernel"/>.
    /// </summary>
    public class WindsorContainerInstaller : IWindsorInstaller
    {
        /// <summary>
        /// Installs
        /// </summary>
        /// <param name="container"></param>
        /// <param name="store"></param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IWindsorContainer>().Instance(container)
                , Component.For<IKernel>().Instance(container.Kernel)
            );
        }
    }
}
