// ReSharper disable once CheckNamespace
namespace Kingdom.MicroKernel.Registration
{
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    /// <summary>
    /// Provides <see cref="IWindsorContainer"/> installer services.
    /// </summary>
    public class ContainerInstaller : WindsorInstallerBase
    {
        /// <summary>
        /// Installs using the <paramref name="container"/> and <paramref name="store"/>.
        /// </summary>
        /// <param name="container"></param>
        /// <param name="store"></param>
        public override void Install(IWindsorContainer container, IConfigurationStore store)
        {
            RegisterComponent<IWindsorContainer>(container, r => r.Instance(container));
        }
    }
}
