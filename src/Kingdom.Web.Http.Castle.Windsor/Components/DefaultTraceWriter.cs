using System.Net.Http;

// ReSharper disable once CheckNamespace

namespace System.Web.Http.Tracing
{
    /// <summary>
    /// 
    /// </summary>
    public class DefaultTraceWriter : ITraceWriter
    {
        /// <summary>
        /// Provides default Trace capability.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="category"></param>
        /// <param name="level"></param>
        /// <param name="traceAction"></param>
        public void Trace(HttpRequestMessage request, string category, TraceLevel level,
            Action<TraceRecord> traceAction)
        {
            var record = new TraceRecord(request, category, level);
            (traceAction ?? delegate { })(record);

        }

        /// <summary>
        /// Writes the <paramref name="record"/> via the <see cref="Diagnostics.Trace"/> resources.
        /// </summary>
        /// <param name="record"></param>
        protected virtual void Write(TraceRecord record)
        {
            // Ah, string interpolation. What a beautiful thing.
            var message = $"{record.Operator};{record.Operation};{record.Message}";
            Diagnostics.Trace.WriteLine(message, record.Category);
        }
    }
}
