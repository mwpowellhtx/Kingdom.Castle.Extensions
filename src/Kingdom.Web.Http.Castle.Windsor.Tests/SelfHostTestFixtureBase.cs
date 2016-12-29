using System;
using System.Net.Http;

namespace Kingdom.Web.Http
{
    using Microsoft.Owin.Hosting;
    using Xunit;

    public abstract class SelfHostTestFixtureBase<TStartup> : TestFixtureBase
        where TStartup : Startup, new()
    {
        private readonly IDisposable _webApp;

        private readonly string _url;

        protected SelfHostTestFixtureBase(string url)
        {
            _url = url;

            _webApp = WebApp.Start<TStartup>(_url);

            Assert.NotNull(_webApp);
        }

        protected delegate HttpResponseMessage RunRequestCallback(HttpClient client);

        protected delegate TResult ProcessResponseCallback<out TResult>(HttpResponseMessage response);

        protected TResult MakeRequest<TResult>(RunRequestCallback requestCallback, ProcessResponseCallback<TResult> responseCallback)
        {
            Assert.NotNull(requestCallback);

            // TODO: TBD: need message handlers?
            using (var client = new HttpClient {BaseAddress = new Uri(_url)})
            {
                var response = requestCallback(client);
                Assert.NotNull(response);
                return responseCallback(response);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (!IsDisposed && disposing)
            {
                _webApp.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}