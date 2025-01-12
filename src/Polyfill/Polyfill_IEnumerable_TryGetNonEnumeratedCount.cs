// <auto-generated />
#pragma warning disable

#if !NET6_0_OR_GREATER

namespace Polyfills;

using System.Collections;
using System.Collections.Generic;
using System.Linq;

static partial class Polyfill
{
    /// <summary>
    ///   Attempts to determine the number of elements in a sequence without forcing an enumeration.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
    /// <param name="source">A sequence that contains elements to be counted.</param>
    /// <param name="count">
    ///     When this method returns, contains the count of <paramref name="source" /> if successful,
    ///     or zero if the method failed to determine the count.</param>
    /// <returns>
    ///   <see langword="true" /> if the count of <paramref name="source"/> can be determined without enumeration;
    ///   otherwise, <see langword="false" />.
    /// </returns>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.trygetnonenumeratedcount
    public static bool TryGetNonEnumeratedCount<TSource>(this IEnumerable<TSource> target, out int count)
    {
        if (target is ICollection<TSource> genericCollection)
        {
            count = genericCollection.Count;
            return true;
        }

        if (target is ICollection collection)
        {
            count = collection.Count;
            return true;
        }

        count = 0;
        return false;
    }
}
#endif