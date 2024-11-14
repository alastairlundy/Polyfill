// <auto-generated />
#pragma warning disable

#if NETFRAMEWORK || NETSTANDARD || NETCOREAPPX || NET5_0

namespace Polyfills;

using System;
using System.Threading;
using System.Threading.Tasks;
using Link = System.ComponentModel.DescriptionAttribute;

static partial class Polyfill
{
    // Copied from .NET library const Timer.MaxSupportedTimeout
    const uint MaxSupportedTimeout = 0xfffffffe;

    /// <summary>Gets a <see cref="Task"/> that will complete when this <see cref="Task"/> completes or when the specified <see cref="CancellationToken"/> has cancellation requested.</summary>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> to monitor for a cancellation request.</param>
    /// <returns>The <see cref="Task"/> representing the asynchronous wait.  It may or may not be the same instance as the current instance.</returns>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task.waitasync#system-threading-tasks-task-waitasync(system-threading-cancellationtoken)
    public static Task WaitAsync(this Task target, CancellationToken cancellationToken) =>
        target.WaitAsync(Timeout.InfiniteTimeSpan, cancellationToken);

    /// <summary>Gets a <see cref="Task"/> that will complete when this <see cref="Task"/> completes or when the specified timeout expires.</summary>
    /// <param name="timeout">The timeout after which the <see cref="Task"/> should be faulted with a <see cref="TimeoutException"/> if it hasn't otherwise completed.</param>
    /// <returns>The <see cref="Task"/> representing the asynchronous wait.  It may or may not be the same instance as the current instance.</returns>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task.waitasync#system-threading-tasks-task-waitasync(system-timespan)
    public static Task WaitAsync(
        this Task target,
        TimeSpan timeout) =>
        target.WaitAsync(timeout, default);

    /// <summary>Gets a <see cref="Task"/> that will complete when this <see cref="Task"/> completes, when the specified timeout expires, or when the specified <see cref="CancellationToken"/> has cancellation requested.</summary>
    /// <param name="timeout">The timeout after which the <see cref="Task"/> should be faulted with a <see cref="TimeoutException"/> if it hasn't otherwise completed.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> to monitor for a cancellation request.</param>
    /// <returns>The <see cref="Task"/> representing the asynchronous wait.  It may or may not be the same instance as the current instance.</returns>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task.waitasync#system-threading-tasks-task-waitasync(system-timespan-system-threading-cancellationtoken)
    public static Task WaitAsync(
        this Task target,
        TimeSpan timeout,
        CancellationToken cancellationToken)
    {
        if (target is null)
        {
            throw new ArgumentNullException(nameof(target));
        }

        long totalMilliseconds = (long) timeout.TotalMilliseconds;
        if (totalMilliseconds < -1 || totalMilliseconds > MaxSupportedTimeout)
        {
            throw new ArgumentOutOfRangeException(nameof(timeout));
        }

        if (target.IsCompleted || (!cancellationToken.CanBeCanceled && timeout == Timeout.InfiniteTimeSpan))
        {
            return target;
        }

        if (cancellationToken.IsCancellationRequested)
        {
            return Task.FromCanceled(cancellationToken);
        }

        if (timeout == TimeSpan.Zero)
        {
            return Task.FromException(new TimeoutException());
        }

        var delayTask = Task.Delay(timeout, cancellationToken);

        Func<Task<Task>, Task> continueFunc = completedTask =>
        {
            if (cancellationToken.IsCancellationRequested)
            {
                throw new TaskCanceledException();
            }
            else if (completedTask.Result == delayTask)
            {
                throw new TimeoutException($"Execution did not complete within the time allotted {timeout.TotalMilliseconds} ms");
            }

            return target;
        };

        return Task.WhenAny(target, delayTask).ContinueWith(continueFunc, TaskContinuationOptions.OnlyOnRanToCompletion);
    }

    /// <summary>
    /// Gets a <see cref="Task"/> that will complete when this <see cref="Task"/> completes, or when the specified <see cref="CancellationToken"/> has cancellation requested.
    /// </summary>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> to monitor for a cancellation request.</param>
    /// <returns>The <see cref="Task"/> representing the asynchronous wait.  It may or may not be the same instance as the current instance.</returns>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task.waitasync#system-threading-tasks-task-waitasync(system-threading-cancellationtoken)
    public static Task<TResult> WaitAsync<TResult>(
        this Task<TResult> target,
        CancellationToken cancellationToken) =>
        target.WaitAsync<TResult>(Timeout.InfiniteTimeSpan, cancellationToken);

    /// <summary>
    /// Gets a <see cref="Task"/> that will complete when this <see cref="Task"/> completes, or when the specified timeout expires.
    /// </summary>
    /// <param name="timeout">The timeout after which the <see cref="Task"/> should be faulted with a <see cref="TimeoutException"/> if it hasn't otherwise completed.</param>
    /// <returns>The <see cref="Task"/> representing the asynchronous wait.  It may or may not be the same instance as the current instance.</returns>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1.waitasync#system-threading-tasks-task-1-waitasync(system-timespan)
    public static Task<TResult> WaitAsync<TResult>(
        this Task<TResult> target,
        TimeSpan timeout) =>
        target.WaitAsync<TResult>(timeout, default);

    /// <summary>
    /// Gets a <see cref="Task"/> that will complete when this <see cref="Task"/> completes, when the specified timeout expires, or when the specified <see cref="CancellationToken"/> has cancellation requested.
    /// </summary>
    /// <param name="timeout">The timeout after which the <see cref="Task"/> should be faulted with a <see cref="TimeoutException"/> if it hasn't otherwise completed.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> to monitor for a cancellation request.</param>
    /// <returns>The <see cref="Task"/> representing the asynchronous wait.  It may or may not be the same instance as the current instance.</returns>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1.waitasync#system-threading-tasks-task-1-waitasync(system-timespan-system-threading-cancellationtoken)
    public static async Task<TResult> WaitAsync<TResult>(
        this Task<TResult> target,
        TimeSpan timeout,
        CancellationToken cancellationToken)
    {
        await ((Task) target).WaitAsync(timeout, cancellationToken);
        return target.Result;
    }
}

#endif
