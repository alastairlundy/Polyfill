// <auto-generated />

#if FeatureMemory

#pragma warning disable

namespace Polyfills;

using System;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;

static partial class Polyfill
{

#if !NET9_0_OR_GREATER

    /// <summary>
    /// Determines whether the specified value appears at the end of the span.
    /// </summary>
    /// <param name="target">The span to search.</param>
    /// <param name="value">The value to compare.</param>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.memoryextensions.endswith#system-memoryextensions-endswith-1(system-readonlyspan((-0))-0)
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool EndsWith<T>(this ReadOnlySpan<T> target, T value)
        where T : IEquatable<T>?
    {
        if (target.Length == 0)
        {
            return false;
        }

        var last = target[target.Length - 1];
        return last?.Equals(value) ?? (object?) value is null;
    }

#endif

#if NETFRAMEWORK || NETSTANDARD || NETCOREAPP2X

    /// <summary>
    /// Determines whether the end of the span matches the specified value when compared using the specified <paramref name="comparison"/> option.
    /// </summary>
    /// <param name="target">The source span.</param>
    /// <param name="other">The sequence to compare to the end of the source span.</param>
    /// <param name="comparison">An enumeration value that determines how span and value are compared.</param>
    /// <returns><c>true</c> if value matches the end of span; otherwise, <c>false</c>.</returns>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.memoryextensions.endswith#system-memoryextensions-endswith-1(system-readonlyspan((-0))-system-readonlyspan((-0)))
    public static bool EndsWith(
        this ReadOnlySpan<char> target,
        string other,
        StringComparison comparison = StringComparison.CurrentCulture) =>
        target.EndsWith(other.AsSpan(), comparison);

    /// <summary>
    /// Determines whether the specified sequence appears at the end of a span.
    /// </summary>
    /// <param name="target">The source span.</param>
    /// <param name="other">The sequence to compare to the end of the source span.</param>
    /// <returns><c>true</c> if value matches the end of span; otherwise, <c>false</c>.</returns>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.memoryextensions.endswith#system-memoryextensions-endswith-1(system-span((-0))-system-readonlyspan((-0)))
    public static bool EndsWith(
        this Span<char> target,
        string other) =>
        target.EndsWith(other.AsSpan());

#endif

}

#endif
