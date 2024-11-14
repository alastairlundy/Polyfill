// <auto-generated />
#pragma warning disable
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Polyfills;

using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using Link = System.ComponentModel.DescriptionAttribute;

static partial class Polyfill
{
#if !NET6_0_OR_GREATER

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static bool IsEmptyArray<TSource>(IEnumerable<TSource> source) =>
        source is TSource[] { Length: 0 };

    static IEnumerable<TSource> TakeRangeFromEndIterator<TSource>(IEnumerable<TSource> source, bool isStartIndexFromEnd, int startIndex, bool isEndIndexFromEnd, int endIndex)
    {
        // Attempt to extract the count of the source enumerator,
        // in order to convert fromEnd indices to regular indices.
        // Enumerable counts can change over time, so it is very
        // important that this check happens at enumeration time;
        // do not move it outside of the iterator method.
        if (source.TryGetNonEnumeratedCount(out int count))
        {
            startIndex = CalculateStartIndex(isStartIndexFromEnd, startIndex, count);
            endIndex = CalculateEndIndex(isEndIndexFromEnd, endIndex, count);

            if (startIndex < endIndex)
            {
                foreach (TSource element in TakeRangeIterator(source, startIndex, endIndex))
                {
                    yield return element;
                }
            }

            yield break;
        }

        Queue<TSource> queue;

        if (isStartIndexFromEnd)
        {
            // TakeLast compat: enumerator should be disposed before yielding the first element.
            using (IEnumerator<TSource> e = source.GetEnumerator())
            {
                if (!e.MoveNext())
                {
                    yield break;
                }

                queue = new Queue<TSource>();
                queue.Enqueue(e.Current);
                count = 1;

                while (e.MoveNext())
                {
                    if (count < startIndex)
                    {
                        queue.Enqueue(e.Current);
                        ++count;
                    }
                    else
                    {
                        do
                        {
                            queue.Dequeue();
                            queue.Enqueue(e.Current);
                            checked
                            {
                                ++count;
                            }
                        } while (e.MoveNext());

                        break;
                    }
                }
            }

            startIndex = CalculateStartIndex(isStartIndexFromEnd: true, startIndex, count);
            endIndex = CalculateEndIndex(isEndIndexFromEnd, endIndex, count);

            for (int rangeIndex = startIndex; rangeIndex < endIndex; rangeIndex++)
            {
                yield return queue.Dequeue();
            }
        }
        else
        {
            // SkipLast compat: the enumerator should be disposed at the end of the enumeration.
            using IEnumerator<TSource> e = source.GetEnumerator();

            count = 0;
            while (count < startIndex && e.MoveNext())
            {
                ++count;
            }

            if (count == startIndex)
            {
                queue = new Queue<TSource>();
                while (e.MoveNext())
                {
                    if (queue.Count == endIndex)
                    {
                        do
                        {
                            queue.Enqueue(e.Current);
                            yield return queue.Dequeue();
                        } while (e.MoveNext());

                        break;
                    }
                    else
                    {
                        queue.Enqueue(e.Current);
                    }
                }
            }
        }

        static int CalculateStartIndex(bool isStartIndexFromEnd, int startIndex, int count) =>
            Math.Max(0, isStartIndexFromEnd ? count - startIndex : startIndex);

        static int CalculateEndIndex(bool isEndIndexFromEnd, int endIndex, int count) =>
            Math.Min(count, isEndIndexFromEnd ? count - endIndex : endIndex);
    }

    static IEnumerable<TSource> TakeRangeIterator<TSource>(IEnumerable<TSource> source, int startIndex, int endIndex)
    {
        using IEnumerator<TSource> e = source.GetEnumerator();

        int index = 0;
        while (index < startIndex && e.MoveNext())
        {
            ++index;
        }

        if (index < startIndex)
        {
            yield break;
        }

        while (index < endIndex && e.MoveNext())
        {
            yield return e.Current;
            ++index;
        }
    }

#if FeatureValueTuple

    //https://github.com/dotnet/runtime/blob/main/src/libraries/System.Linq/src/System/Linq/Take.cs
    /// <summary>Returns a specified range of contiguous elements from a sequence.</summary>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
    /// <param name="source">The sequence to return elements from.</param>
    /// <param name="range">The range of elements to return, which has start and end indexes either from the start or the end.</param>
    /// <exception cref="ArgumentNullException"><paramref name="source" /> is <see langword="null" />.</exception>
    /// <returns>An <see cref="IEnumerable{T}" /> that contains the specified <paramref name="range" /> of elements from the <paramref name="source" /> sequence.</returns>
    /// <remarks>
    /// <para>This method is implemented by using deferred execution. The immediate return value is an object that stores all the information that is required to perform the action. The query represented by this method is not executed until the object is enumerated either by calling its `GetEnumerator` method directly or by using `foreach` in Visual C# or `For Each` in Visual Basic.</para>
    /// <para><see cref="O:Enumerable.Take" /> enumerates <paramref name="source" /> and yields elements whose indices belong to the specified <paramref name="range"/>.</para>
    /// </remarks>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.take?view=net-8.0#system-linq-enumerable-take-1(system-collections-generic-ienumerable((-0))-system-range)
    public static IEnumerable<TSource> Take<TSource>(
        this IEnumerable<TSource> target,
        Range range)
    {
        if (IsEmptyArray(target))
        {
            return [];
        }

        Index start = range.Start;
        Index end = range.End;
        bool isStartIndexFromEnd = start.IsFromEnd;
        bool isEndIndexFromEnd = end.IsFromEnd;
        int startIndex = start.Value;
        int endIndex = end.Value;

        if (isStartIndexFromEnd)
        {
            if (startIndex == 0 || (isEndIndexFromEnd && endIndex >= startIndex))
            {
                return [];
            }
        }
        else if (!isEndIndexFromEnd)
        {
            return startIndex >= endIndex ? [] : TakeRangeIterator(target, startIndex, endIndex);
        }

        return TakeRangeFromEndIterator(target, isStartIndexFromEnd, startIndex, isEndIndexFromEnd, endIndex);
    }

    static IEnumerable<TSource> TakeIterator<TSource>(IEnumerable<TSource> source, int count)
    {
        foreach (TSource element in source)
        {
            yield return element;
            if (--count == 0) break;
        }
    }

#endif
#endif

}