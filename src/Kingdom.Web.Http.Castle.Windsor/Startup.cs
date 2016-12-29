using System.Web.Http;

namespace Kingdom.Web.Http
{
    using Owin;

    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Gets the <see cref="HttpConfiguration"/> associated with this Startup.
        /// </summary>
        protected HttpConfiguration Config { get; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Startup()
        {
            Config = new HttpConfiguration();
        }

        /// <summary>
        /// Configures Startup based on the <paramref name="app"/>.
        /// </summary>
        /// <param name="app"></param>
        public virtual void Configuration(IAppBuilder app)
        {
        }
    }
}
