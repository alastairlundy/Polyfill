// <auto-generated />
#pragma warning disable

namespace Polyfills;
using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Link = System.ComponentModel.DescriptionAttribute;

[ExcludeFromCodeCoverage]
[DebuggerNonUserCode]
#if PolyPublic
public
#endif
static class DateTimePolyfill
{
    /// <summary>
    /// Tries to parse a string into a value.
    /// </summary>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.datetime.tryparse#system-datetime-tryparse(system-string-system-iformatprovider-system-datetime@)")]
    public static bool TryParse(string? target, IFormatProvider? provider, out DateTime result) =>
#if NET7_0_OR_GREATER
        DateTime.TryParse(target, provider, out result);
#else
        DateTime.TryParse(target, provider, DateTimeStyles.None, out result);
#endif

#if FeatureMemory

    /// <summary>
    /// Tries to parse a span of characters into a value.
    /// </summary>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.datetime.tryparse#system-datetime-tryparse(system-readonlyspan((system-char))-system-iformatprovider-system-datetime@)")]
    public static bool TryParse(ReadOnlySpan<char> target, IFormatProvider? provider, out DateTime result) =>
#if NET8_0_OR_GREATER
        DateTime.TryParse(target, provider, out result);
#else
        DateTime.TryParse(target.ToString(), provider, DateTimeStyles.None, out result);
#endif

    /// <summary>
    /// Tries to parse a span of characters into a value.
    /// </summary>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.datetime.tryparse#system-datetime-tryparse(system-readonlyspan((system-char))-system-datetime@)")]
    public static bool TryParse(ReadOnlySpan<char> target, out DateTime result) =>
#if NETSTANDARD2_1 || NETSTANDARD2_1_OR_GREATER || NET5_0_OR_GREATER
        DateTime.TryParse(target, out result);
#else
        DateTime.TryParse(target.ToString(), null, DateTimeStyles.None, out result);
#endif

    /// <summary>
    /// Tries to parse a span of characters into a value.
    /// </summary>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.datetime.tryparse#system-datetime-tryparse(system-readonlyspan((system-char))-system-iformatprovider-system-globalization-datetimestyles-system-datetime@)")]
    public static bool TryParse(ReadOnlySpan<char> target, IFormatProvider? provider, DateTimeStyles styles, out DateTime result) =>
#if NETSTANDARD2_1 || NETSTANDARD2_1_OR_GREATER || NET5_0_OR_GREATER
        DateTime.TryParse(target, provider, styles, out result);
#else
        DateTime.TryParse(target.ToString(), provider, styles, out result);
#endif

    /// <summary>
    /// Tries to parse a span of characters into a value.
    /// </summary>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.datetime.tryparseexact#system-datetime-tryparseexact(system-readonlyspan((system-char))-system-readonlyspan((system-char))-system-iformatprovider-system-globalization-datetimestyles-system-datetime@)")]
    public static bool TryParseExact(ReadOnlySpan<char> target, string format, IFormatProvider? provider, DateTimeStyles style, out DateTime result) =>
#if NETSTANDARD2_1 || NETSTANDARD2_1_OR_GREATER || NET5_0_OR_GREATER
        DateTime.TryParseExact(target, format, provider, style, out result);
#else
        DateTime.TryParseExact(target.ToString(), format, provider, style, out result);
#endif

    /// <summary>
    /// Tries to parse a span of characters into a value.
    /// </summary>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.datetime.tryparseexact#system-datetime-tryparseexact(system-readonlyspan((system-char))-system-readonlyspan((system-char))-system-iformatprovider-system-globalization-datetimestyles-system-datetime@)")]
    public static bool TryParseExact(ReadOnlySpan<char> target, ReadOnlySpan<char> format, IFormatProvider? provider, DateTimeStyles styles, out DateTime result) =>
#if NETFRAMEWORK || NETSTANDARD2_0 || NETCOREAPP2_0
        DateTime.TryParseExact(target.ToString(), format.ToString(), provider, styles, out result);
#else
        DateTime.TryParseExact(target, format, provider, styles, out result);
#endif

#endif
}