using System.Web.Http;

namespace Kingdom.Castle.Windsor.Web.Http
{
    using Owin;

    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        // TODO: TBD: may need/want to replace the Config downstream from here...
        private readonly HttpConfiguration _config;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Startup()
        {
            _config = new HttpConfiguration();
        }

        /// <summary>
        /// Gets the <see cref="HttpConfiguration"/> associated with this Startup.
        /// </summary>
        protected HttpConfiguration Config
        {
            get { return _config; }
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
