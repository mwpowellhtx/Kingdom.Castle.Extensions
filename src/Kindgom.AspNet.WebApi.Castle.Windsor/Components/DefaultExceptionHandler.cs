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
        public Task HandleAsync(ExceptionHandlerContext context, CancellationToken token)
        {
            return Task.Run(() => { }, token);
        }
    }
}
