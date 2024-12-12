#pragma warning disable

namespace Polyfills;

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
[DebuggerNonUserCode]
#if PolyPublic
public
#endif
static class GuidPolyfill
{
    /// <summary>
    /// Tries to parse a string into a value.
    /// </summary>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.guid.tryparse#system-guid-tryparse(system-string-system-iformatprovider-system-guid@)
    public static bool TryParse(string? target, IFormatProvider? provider, out Guid result) =>
#if NET7_0_OR_GREATER
        Guid.TryParse(target, provider, out result);
#else
        Guid.TryParse(target, out result);
#endif

    public static Guid CreateVersion7() => CreateVersion7(DateTimeOffset.UtcNow);

    public static Guid CreateVersion7(DateTimeOffset timestamp)
    {
#if NET9_0_OR_GREATER
        return Guid.CreateVersion7();
#elif NET8_0_OR_GREATER
        var uuidBytes = new byte[16];

        var unixTimeMilliseconds = timestamp.ToUnixTimeMilliseconds();

        var timeBytes = BitConverter.GetBytes(unixTimeMilliseconds);

        if (BitConverter.IsLittleEndian)
        {
            Array.Reverse(timeBytes);
        }

        timeBytes[2..8].CopyTo(uuidBytes, 0);

        var randomBytes = uuidBytes.AsSpan().Slice(6);

        System.Security.Cryptography.RandomNumberGenerator.Fill(randomBytes);

        uuidBytes[6] &= 0x0F;
        uuidBytes[6] += 0x70;

        return new(uuidBytes, true);
#else
        var unixTimeMilliseconds = timestamp.ToUnixTimeMilliseconds();

        var timeBytes = BitConverter.GetBytes(unixTimeMilliseconds);

        if (BitConverter.IsLittleEndian)
        {
            Array.Reverse(timeBytes);
        }

        var randomBytes = new byte[10];

        using (var randomNumberGenerator = System.Security.Cryptography.RandomNumberGenerator.Create())
        {
            randomNumberGenerator.GetBytes(randomBytes);
        }

        var uuidBytes = new byte[16];
        Array.Copy(timeBytes, 2, uuidBytes, 0, 6);
        Array.Copy(randomBytes, 0, uuidBytes, 6, 10);

        uuidBytes[6] = (byte)((uuidBytes[6] & 0x0F) | 0x70);

        uuidBytes[8] = (byte)((uuidBytes[8] & 0x3F) | 0x80);

        return new(uuidBytes);
#endif
    }

#if FeatureMemory

    /// <summary>
    /// Converts span of characters representing the GUID to the equivalent Guid structure, provided that the string is in the specified format.
    /// </summary>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.guid.tryparseexact#system-guid-tryparseexact(system-readonlyspan((system-char))-system-readonlyspan((system-char))-system-guid@)
    public static bool TryParseExact(ReadOnlySpan<char> target, ReadOnlySpan<char> format, out Guid result) =>
#if NETFRAMEWORK || NETCOREAPP2_0 || NETSTANDARD2_0
        Guid.TryParseExact(target.ToString(), format.ToString(), out result);
#else
        Guid.TryParseExact(target, format, out result);
#endif

    /// <summary>
    /// Tries to parse a span of UTF-8 characters into a value.
    /// </summary>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.guid.tryparse#system-guid-tryparse(system-readonlyspan((system-char))-system-iformatprovider-system-guid@)
    public static bool TryParse(ReadOnlySpan<char> target, IFormatProvider? provider, out Guid result) =>
#if NET7_0_OR_GREATER
        Guid.TryParse(target, provider, out result);
#else
        Guid.TryParse(target.ToString(), out result);
#endif

    /// <summary>
    /// Tries to parse a span of UTF-8 characters into a value.
    /// </summary>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.guid.tryparse#system-guid-tryparse(system-readonlyspan((system-char))-system-guid@)
    public static bool TryParse(ReadOnlySpan<char> target, out Guid result) =>
#if NETSTANDARD2_1 || NETSTANDARD2_1_OR_GREATER || NET5_0_OR_GREATER
        Guid.TryParse(target, out result);
#else
        Guid.TryParse(target.ToString(), out result);
#endif

#endif
}