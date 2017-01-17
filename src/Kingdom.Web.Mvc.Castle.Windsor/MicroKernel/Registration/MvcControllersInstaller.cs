using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace Kingdom.Web.Mvc.MicroKernel.Registration
{
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    /// <summary>
    /// Provides <see cref="IWindsorContainer"/> registration for <see cref="IController"/>
    /// based, MVC controllers.
    /// </summary>
    public class MvcControllerInstaller : WindsorInstallerBase
    {
        private readonly IEnumerable<Assembly> _assemblies;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="types"></param>
        public MvcControllerInstaller(IEnumerable<Type> types)
            : this(types.Select(t => t.Assembly).Distinct().ToArray())
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="assemblies"></param>
        public MvcControllerInstaller(IEnumerable<Assembly> assemblies)
        {
            _assemblies = assemblies;
        }

        /// <summary>
        /// Installs using the <paramref name="container"/> and <paramref name="store"/>.
        /// </summary>
        /// <param name="container"></param>
        /// <param name="store"></param>
        public override void Install(IWindsorContainer container, IConfigurationStore store)
        {
            foreach (var assy in _assemblies)
            {
                RegisterClasses<IController>(container, assy,
                    r => r.Configure(configurer => configurer.Named(configurer.Implementation.Name))
                        .LifestylePerWebRequest()
                );
            }
        }
    }

    /// <summary>
    /// Provides <see cref="IWindsorContainer"/> registration for <see cref="IController"/>
    /// based, MVC controllers, for the type <typeparamref name="TController"/>.
    /// </summary>
    /// <typeparam name="TController"></typeparam>
    public class MvcControllerInstaller<TController> : MvcControllerInstaller
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MvcControllerInstaller()
            : base(new[] {typeof(TController)})
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="types"></param>
        public MvcControllerInstaller(IEnumerable<Type> types)
            : base(new[] {typeof(TController)}.Concat(types))
        {
        }
    }
}
