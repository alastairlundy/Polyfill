// <auto-generated />
#pragma warning disable

namespace Polyfills;

using System;
using System.Runtime.CompilerServices;
using System.Text;
using Link = System.ComponentModel.DescriptionAttribute;

static partial class Polyfill
{
#if FeatureMemory && (!NETSTANDARD2_1_OR_GREATER && !NETCOREAPP2_1_OR_GREATER)

    /// <summary>
    /// Appends the string representation of a specified read-only character span to this instance.
    /// </summary>
    /// <param name="value">The read-only character span to append.</param>
    /// <returns>A reference to this instance after the append operation is completed.</returns>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder.append#system-text-stringbuilder-append(system-readonlyspan((system-char)))
    public static StringBuilder Append(this StringBuilder target, ReadOnlySpan<char> value)
    {
        if (value.Length <= 0)
        {
            return target;
        }

#if AllowUnsafeBlocks
        unsafe
        {
            fixed (char* valueChars = value)
            {
                target.Append(valueChars, value.Length);
            }
        }
#else
        target.Append(value.ToString());
#endif
        return target;
    }

#endif

#if FeatureMemory && !NET6_0_OR_GREATER
    /// <summary>Appends the specified interpolated string to this instance.</summary>
    /// <param name="handler">The interpolated string to append.</param>
    /// <returns>A reference to this instance after the append operation has completed.</returns>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder.append#system-text-stringbuilder-append(system-text-stringbuilder-appendinterpolatedstringhandler@)
    public static StringBuilder Append(
        StringBuilder target,
        [InterpolatedStringHandlerArgument(nameof(target))]
        ref AppendInterpolatedStringHandler handler) => target;

    /// <summary>Appends the specified interpolated string to this instance.</summary>
    /// <param name="provider">An object that supplies culture-specific formatting information.</param>
    /// <param name="handler">The interpolated string to append.</param>
    /// <returns>A reference to this instance after the append operation has completed.</returns>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder.append#system-text-stringbuilder-append(system-iformatprovider-system-text-stringbuilder-appendinterpolatedstringhandler@)
    public static StringBuilder Append(
        StringBuilder target,
        IFormatProvider? provider,
        [InterpolatedStringHandlerArgument(nameof(target), nameof(provider))]
        ref AppendInterpolatedStringHandler handler) => target;

    /// <summary>Appends the specified interpolated string followed by the default line terminator to the end of the current StringBuilder object.</summary>
    /// <param name="handler">The interpolated string to append.</param>
    /// <returns>A reference to this instance after the append operation has completed.</returns>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder.appendline#system-text-stringbuilder-appendline(system-text-stringbuilder-appendinterpolatedstringhandler@)
    public static StringBuilder AppendLine(
        StringBuilder target,
        [InterpolatedStringHandlerArgument(nameof(target))]
        ref AppendInterpolatedStringHandler handler) =>
        target.AppendLine();

    /// <summary>Appends the specified interpolated string followed by the default line terminator to the end of the current StringBuilder object.</summary>
    /// <param name="provider">An object that supplies culture-specific formatting information.</param>
    /// <param name="handler">The interpolated string to append.</param>
    /// <returns>A reference to this instance after the append operation has completed.</returns>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder.appendline#system-text-stringbuilder-appendline(system-iformatprovider-system-text-stringbuilder-appendinterpolatedstringhandler@)
    public static StringBuilder AppendLine(
        StringBuilder target,
        IFormatProvider? provider,
        [InterpolatedStringHandlerArgument(nameof(target), nameof(provider))]
        ref AppendInterpolatedStringHandler handler) =>
        target.AppendLine();

#elif NET6_0_OR_GREATER

    /// <summary>Appends the specified interpolated string to this instance.</summary>
    /// <param name="handler">The interpolated string to append.</param>
    /// <returns>A reference to this instance after the append operation has completed.</returns>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder.append#system-text-stringbuilder-append(system-text-stringbuilder-appendinterpolatedstringhandler@)
    public static StringBuilder Append(
        StringBuilder target,
        [InterpolatedStringHandlerArgument(nameof(target))] ref StringBuilder.AppendInterpolatedStringHandler handler) =>
        target.Append(ref handler);

    /// <summary>Appends the specified interpolated string to this instance.</summary>
    /// <param name="provider">An object that supplies culture-specific formatting information.</param>
    /// <param name="handler">The interpolated string to append.</param>
    /// <returns>A reference to this instance after the append operation has completed.</returns>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder.append#system-text-stringbuilder-append(system-iformatprovider-system-text-stringbuilder-appendinterpolatedstringhandler@)
    public static StringBuilder Append(
        StringBuilder target,
        IFormatProvider? provider,
        [InterpolatedStringHandlerArgument(nameof(target), nameof(provider))] ref StringBuilder.AppendInterpolatedStringHandler handler) =>
        target.Append(provider, ref handler);

    /// <summary>Appends the specified interpolated string followed by the default line terminator to the end of the current StringBuilder object.</summary>
    /// <param name="handler">The interpolated string to append.</param>
    /// <returns>A reference to this instance after the append operation has completed.</returns>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder.appendline#system-text-stringbuilder-appendline(system-text-stringbuilder-appendinterpolatedstringhandler@)
    public static StringBuilder AppendLine(
        StringBuilder target,
        [InterpolatedStringHandlerArgument(nameof(target))] ref StringBuilder.AppendInterpolatedStringHandler handler) =>
        target.AppendLine(ref handler);

    /// <summary>Appends the specified interpolated string followed by the default line terminator to the end of the current StringBuilder object.</summary>
    /// <param name="provider">An object that supplies culture-specific formatting information.</param>
    /// <param name="handler">The interpolated string to append.</param>
    /// <returns>A reference to this instance after the append operation has completed.</returns>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder.appendline#system-text-stringbuilder-appendline(system-iformatprovider-system-text-stringbuilder-appendinterpolatedstringhandler@)
    public static StringBuilder AppendLine(
        StringBuilder target,
        IFormatProvider? provider,
        [InterpolatedStringHandlerArgument(nameof(target), nameof(provider))] ref StringBuilder.AppendInterpolatedStringHandler handler) =>
        target.AppendLine(provider, ref handler);
#endif

}