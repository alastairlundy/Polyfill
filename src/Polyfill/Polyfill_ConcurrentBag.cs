// <auto-generated />
#pragma warning disable

#if NETFRAMEWORK || NETSTANDARD2_0

namespace Polyfills;

using System;
using System.Collections.Concurrent;

static partial class Polyfill
{
    /// <summary>
    /// Removes all values from the <see cref="ConcurrentBag{T}"/>.
    /// </summary>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.collections.concurrent.concurrentbag-1.clear
    public static void Clear<T>(this ConcurrentBag<T> target)
    {
        while (!target.IsEmpty)
        {
            target.TryTake(out _);
        }
    }
}
#endif