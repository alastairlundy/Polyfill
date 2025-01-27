// <auto-generated />
#pragma warning disable

#if FeatureMemory

namespace Polyfills;

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System;
using System.Text;

static partial class Polyfill
{
#if !NET6_0_OR_GREATER

    /// <summary>
    /// Returns an enumeration of lines over the provided span.
    /// </summary>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.memoryextensions.enumeratelines#system-memoryextensions-enumeratelines(system-readonlyspan((system-char)))
    public static SpanLineEnumerator EnumerateLines(this ReadOnlySpan<char> target) =>
        new(target);

    /// <summary>
    /// Returns an enumeration of lines over the provided span.
    /// </summary>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.memoryextensions.enumeratelines#system-memoryextensions-enumeratelines(system-span((system-char)))
    public static SpanLineEnumerator EnumerateLines(this Span<char> target) =>
        new(target);

#endif

#if NETFRAMEWORK || NETSTANDARD || NETCOREAPP2X

    /// <summary>
    /// Removes all leading white-space characters from the span.
    /// </summary>
    /// <param name="span">The source span from which the characters are removed.</param>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.memoryextensions.trimstart#system-memoryextensions-trimstart(system-span((system-char)))
    public static Span<char> TrimStart(this Span<char> target)
        => target.Slice(ClampStart(target));

    /// <summary>
    /// Removes all trailing white-space characters from the span.
    /// </summary>
    /// <param name="span">The source span from which the characters are removed.</param>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.memoryextensions.trimend#system-memoryextensions-trimend(system-span((system-char)))
    public static Span<char> TrimEnd(this Span<char> target)
        => target.Slice(0, ClampEnd(target, 0));

    /// <summary>
    /// Delimits all leading occurrences of whitespace charecters from the span.
    /// </summary>
    /// <param name="span">The source span from which the characters are removed.</param>
    static int ClampStart(ReadOnlySpan<char> target)
    {
        int start = 0;

        for (; start < target.Length; start++)
        {
            if (!char.IsWhiteSpace(target[start]))
            {
                break;
            }
        }

        return start;
    }

    /// <summary>
    /// Delimits all trailing occurrences of whitespace charecters from the span.
    /// </summary>
    /// <param name="span">The source span from which the characters are removed.</param>
    /// <param name="start">The start index from which to being searching.</param>
    static int ClampEnd(ReadOnlySpan<char> target, int start)
    {
        int end = target.Length - 1;

        for (; end >= start; end--)
        {
            if (!char.IsWhiteSpace(target[end]))
            {
                break;
            }
        }

        return end - start + 1;
    }

    /// <summary>
    /// Indicates whether a specified value is found in a read-only span. Values are compared using IEquatable{T}.Equals(T).
    /// </summary>
    /// <param name="value">The value to search for.</param>
    /// <returns><c>true</c> if found, <c>false</c> otherwise.</returns>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.memoryextensions.contains#system-memoryextensions-contains-1(system-readonlyspan((-0))-0)
    public static bool Contains<T>(
        this ReadOnlySpan<T> target,
        T value)
        where T : IEquatable<T>
    {
        for (var index = 0; index < target.Length; index++)
        {
            if (target[index].Equals(value))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Indicates whether a specified value is found in a only span. Values are compared using IEquatable{T}.Equals(T).
    /// </summary>
    /// <param name="value">The value to search for.</param>
    /// <returns><c>true</c> if found, <c>false</c> otherwise.</returns>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.memoryextensions.contains#system-memoryextensions-contains-1(system-span((-0))-0)
    public static bool Contains<T>(
        this Span<T> target,
        T value)
        where T : IEquatable<T>
    {
        for (var index = 0; index < target.Length; index++)
        {
            if (target[index].Equals(value))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Determines whether two sequences are equal by comparing the elements using IEquatable{T}.Equals(T).
    /// </summary>
    /// <param name="target">The first sequence to compare.</param>
    /// <param name="other">The second sequence to compare.</param>
    /// <returns><c>true</c> if the two sequences are equal; otherwise, <c>false</c>.</returns>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.memoryextensions.sequenceequal#system-memoryextensions-sequenceequal-1(system-readonlyspan((-0))-system-readonlyspan((-0)))
    public static bool SequenceEqual(
        this ReadOnlySpan<char> target,
        string other) =>
        target.SequenceEqual(other.AsSpan());

    /// <summary>
    /// Determines whether two sequences are equal by comparing the elements using IEquatable{T}.Equals(T).
    /// </summary>
    /// <param name="target">The first sequence to compare.</param>
    /// <param name="other">The second sequence to compare.</param>
    /// <returns><c>true</c> if the two sequences are equal; otherwise, <c>false</c>.</returns>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.memoryextensions.sequenceequal#system-memoryextensions-sequenceequal-1(system-span((-0))-system-readonlyspan((-0)))
    public static bool SequenceEqual(
        this Span<char> target,
        string other) =>
        target.SequenceEqual(other.AsSpan());

#endif

}

#endif
