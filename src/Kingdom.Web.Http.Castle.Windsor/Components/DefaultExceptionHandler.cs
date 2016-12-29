using System.Threading;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace

namespace System.Web.Http.ExceptionHandling
{
    /// <summary>
    /// Provides a default <see cref="IExceptionHandler"/>.
    /// </summary>
    public class NullExceptionHandler : IExceptionHandler
    {
        /// <summary>
        /// Handles the <paramref name="context"/> asynchronously.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task HandleAsync(ExceptionHandlerContext context, CancellationToken token)
        {
            return Task.Run(() => { }, token);
        }
    }
}
