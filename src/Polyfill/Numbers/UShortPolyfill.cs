// <auto-generated />
#pragma warning disable

namespace Polyfills;

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;

[ExcludeFromCodeCoverage]
[DebuggerNonUserCode]
#if PolyPublic
public
#endif
static class UShortPolyfill
{
    /// <summary>
    /// Tries to parse a string into a value.
    /// </summary>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.uint16.tryparse#system-uint16-tryparse(system-string-system-iformatprovider-system-uint16@)
    public static bool TryParse(string? target, IFormatProvider? provider, out ushort result) =>
#if !NET7_0_OR_GREATER
        ushort.TryParse(target, NumberStyles.Integer, provider, out result);
#else
        ushort.TryParse(target, provider, out result);
#endif

#if FeatureMemory
    /// <summary>
    /// Tries to parse a span of UTF-8 characters into a value.
    /// </summary>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.uint16.tryparse#system-uint16-tryparse(system-readonlyspan((system-byte))-system-iformatprovider-system-uint16@)
    public static bool TryParse(ReadOnlySpan<byte> target, IFormatProvider? provider, out ushort result) =>
#if NET8_0_OR_GREATER
        ushort.TryParse(target, provider, out result);
#elif FeatureMemory && AllowUnsafeBlocks || NETCOREAPP2_1_OR_GREATER
        ushort.TryParse(Encoding.UTF8.GetString(target), NumberStyles.Integer, provider, out result);
#else
        ushort.TryParse(Encoding.UTF8.GetString(target.ToArray()), NumberStyles.Integer, provider, out result);
#endif

    /// <summary>
    /// Converts the span representation of a number in a specified style and culture-specific format to its ushort equivalent. A return value indicates whether the conversion succeeded.
    /// </summary>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.uint16.tryparse#system-uint16-tryparse(system-readonlyspan((system-char))-system-uint16@)
    public static bool TryParse(ReadOnlySpan<char> target, out ushort result) =>
#if NETCOREAPP2_0 || NETFRAMEWORK || NETSTANDARD2_0
        ushort.TryParse(target.ToString(), out result);
#else
        ushort.TryParse(target, out result);
#endif

    /// <summary>
    /// Tries to parse a span of characters into a value.
    /// </summary>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.uint16.tryparse#system-uint16-tryparse(system-readonlyspan((system-char))-system-iformatprovider-system-uint16@)
    public static bool TryParse(ReadOnlySpan<char> target, IFormatProvider? provider, out ushort result) =>
#if NET7_0_OR_GREATER
        ushort.TryParse(target, provider, out result);
#else
        ushort.TryParse(target.ToString(), NumberStyles.Integer, provider, out result);
#endif

    /// <summary>
    /// Tries to parse a span of UTF-8 characters into a value.
    /// </summary>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.uint16.tryparse#system-uint16-tryparse(system-readonlyspan((system-byte))-system-globalization-numberstyles-system-iformatprovider-system-uint16@)
    public static bool TryParse(ReadOnlySpan<byte> target, NumberStyles style, IFormatProvider? provider, out ushort result) =>
#if NET8_0_OR_GREATER
        ushort.TryParse(target, style, provider, out result);
#elif FeatureMemory && AllowUnsafeBlocks || NETCOREAPP2_1_OR_GREATER
        ushort.TryParse(Encoding.UTF8.GetString(target), style, provider, out result);
#else
        ushort.TryParse(Encoding.UTF8.GetString(target.ToArray()), style, provider, out result);
#endif

    /// <summary>
    /// Tries to convert a UTF-8 character span containing the string representation of a number to its ushort equivalent.
    /// </summary>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.uint16.tryparse#system-uint16-tryparse(system-readonlyspan((system-char))-system-globalization-numberstyles-system-iformatprovider-system-uint16@)
    public static bool TryParse(ReadOnlySpan<byte> target, out ushort result) =>
#if NET8_0_OR_GREATER
        ushort.TryParse(target, out result);
#elif FeatureMemory && AllowUnsafeBlocks || NETCOREAPP2_1_OR_GREATER
        ushort.TryParse(Encoding.UTF8.GetString(target), NumberStyles.Integer, null, out result);
#else
        ushort.TryParse(Encoding.UTF8.GetString(target.ToArray()), NumberStyles.Integer, null, out result);
#endif

    /// <summary>
    /// Converts the span representation of a number in a specified style and culture-specific format to its ushort equivalent. A return value indicates whether the conversion succeeded.
    /// </summary>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.uint16.tryparse#system-uint16-tryparse(system-readonlyspan((system-char))-system-globalization-numberstyles-system-iformatprovider-system-uint16@)
    public static bool TryParse(ReadOnlySpan<char> target, NumberStyles style, IFormatProvider? provider, out ushort result) =>
#if NETCOREAPP2_0 || NETSTANDARD2_0 || NETFRAMEWORK
        ushort.TryParse(target.ToString(), style, provider, out result);
#else
        ushort.TryParse(target, style, provider, out result);
#endif
#endif
}