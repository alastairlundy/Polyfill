// <auto-generated />
#pragma warning disable

namespace Polyfills;

using System;
using System.Collections.Generic;

static partial class Polyfill
{
#if !NET6_0_OR_GREATER

    /// <summary>
    /// Split the elements of a sequence into chunks of size at most <paramref name="size"/>.
    /// </summary>
    /// <param name="source">An <see cref="IEnumerable{T}"/> whose elements to chunk.</param>
    /// <param name="size">Maximum size of each chunk.</param>
    /// <typeparam name="TSource">The type of the elements of source.</typeparam>
    /// <returns>
    /// An <see cref="IEnumerable{T}"/> that contains the elements the input sequence split into chunks of size <paramref name="size"/>.
    /// </returns>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.chunk
    public static IEnumerable<TSource[]> Chunk<TSource>(this IEnumerable<TSource> source, int size)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (size < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(size), size, "Size must be greater than 0.");
        }

        return ChunkIterator(source, size);

        static IEnumerable<TSource[]> ChunkIterator(IEnumerable<TSource> source, int size)
        {
            using var enumerator = source.GetEnumerator();

            // Before allocating anything, make sure there's at least one element.
            if (enumerator.MoveNext())
            {
                // Now that we know we have at least one item, allocate an initial storage array. This is not
                // the array we'll yield.  It starts out small in order to avoid significantly overallocating
                // when the source has many fewer elements than the chunk size.
                var arraySize = Math.Min(size, 4);
                int i;
                do
                {
                    var array = new TSource[arraySize];

                    // Store the first item.
                    array[0] = enumerator.Current;
                    i = 1;

                    if (size != array.Length)
                    {
                        // This is the first chunk. As we fill the array, grow it as needed.
                        for (; i < size && enumerator.MoveNext(); i++)
                        {
                            if (i >= array.Length)
                            {
                                arraySize = (int) Math.Min((uint) size, 2 * (uint) array.Length);
                                Array.Resize(ref array, arraySize);
                            }

                            array[i] = enumerator.Current;
                        }
                    }
                    else
                    {
                        // For all but the first chunk, the array will already be correctly sized.
                        // We can just store into it until either it's full or MoveNext returns false.
                        // avoid bounds checks by using cached local (`array` is lifted to iterator object as a field)
                        var local = array;
                        for (; (uint) i < (uint) local.Length && enumerator.MoveNext(); i++)
                        {
                            local[i] = enumerator.Current;
                        }
                    }

                    if (i != array.Length)
                    {
                        Array.Resize(ref array, i);
                    }

                    yield return array;
                } while (i >= size && enumerator.MoveNext());
            }
        }
    }

#endif
}