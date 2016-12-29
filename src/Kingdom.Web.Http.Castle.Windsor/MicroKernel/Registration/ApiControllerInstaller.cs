using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;

// ReSharper disable once CheckNamespace

namespace Kingdom.MicroKernel.Registration
{
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    /// <summary>
    /// Provides <see cref="IWindsorContainer"/> registration for <see cref="ApiController"/>
    /// based, Web API controllers.
    /// </summary>
    public class ApiControllerInstaller : WindsorInstallerBase
    {
        private readonly IEnumerable<Assembly> _assemblies;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="types"></param>
        public ApiControllerInstaller(IEnumerable<Type> types)
            : this(types.Select(t => t.Assembly).Distinct().ToArray())
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="assemblies"></param>
        public ApiControllerInstaller(IEnumerable<Assembly> assemblies)
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
                RegisterClasses<ApiController>(container, assy);
            }
        }
    }

    /// <summary>
    /// Provides <see cref="IWindsorContainer"/> registration for <see cref="ApiController"/>
    /// based, Web API controllers, for the type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiControllerInstaller<T> : ApiControllerInstaller
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ApiControllerInstaller()
            : base(new[] {typeof(T)})
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="types"></param>
        public ApiControllerInstaller(IEnumerable<Type> types)
            : base(new[] {typeof(T)}.Concat(types))
        {
        }
    }
}
