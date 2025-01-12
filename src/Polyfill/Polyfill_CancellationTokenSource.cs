// <auto-generated />
#pragma warning disable

#if !NET8_0_OR_GREATER

namespace Polyfills;

using System;
using System.Threading;
using System.Threading.Tasks;

static partial class Polyfill
{
    /// <summary>Communicates a request for cancellation asynchronously.</summary>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtokensource.cancelasync
    public static Task CancelAsync(this CancellationTokenSource target)
    {
        if (target.IsCancellationRequested)
        {
            // If cancellation has already been requested then we can just return immediately
            return Task.CompletedTask;
        }
        else
        {
            // Run sync Cancel call in Task to avoid possible deadlock.
            // As an example, the CancellationTokenSource_CancelAsync_CallbacksInvokedAsynchronously test
            // will hit a deadlock if we try to just call Cancel directly without it being run in a task
            Task task = Task.Run(() => target.Cancel());

            while (!target.IsCancellationRequested)
            {
                // Don't return until we know that the cancellation request has started, to match the
                // state that the real implemenation for CancelAsync would be in after being called
            }

            return task;
        }
    }
}
#endif