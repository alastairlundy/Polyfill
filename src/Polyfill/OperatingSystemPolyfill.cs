﻿// <auto-generated />
#pragma warning disable

namespace Polyfills;

#if FeatureRuntimeInformation

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

[ExcludeFromCodeCoverage]
[DebuggerNonUserCode]

#if PolyPublic
public
#endif
static class OperatingSystemPolyfill
{
    #if !NET5_0_OR_GREATER

    static Version GetFreeBSDVersion()
    {
        if (!IsFreeBSD())
        {
            return Environment.OSVersion.Version;
        }

        var version = Environment.OSVersion.VersionString
            .Replace("Unix", string.Empty).Replace("FreeBSD", string.Empty)
            .Replace("-release", string.Empty).Replace(" ", string.Empty);

        return Version.Parse(version);
    }

    static Version GetAndroidVersion()
    {
        if (!IsAndroid())
        {
            return Environment.OSVersion.Version;
        }

        var result = RunProcess("getprop", "ro.build.version.release")
            .Replace(" ", string.Empty);

        return Version.Parse(result);
    }

    static string RunProcess(string name, string arguments)
    {
        using var process = new Process()
        {
            StartInfo = new()
            {
                FileName = name,
                Arguments = arguments,
                RedirectStandardInput = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            }
        };
        process.Start();
        process.WaitForExit();

        return process.StandardOutput.ReadToEnd();
    }
#endif

    /// <summary>
    /// Indicates whether the current application is running on the specified platform.
    /// </summary>
    /// <param name="platform">The case-insensitive platform name. Examples: Browser, Linux, FreeBSD, Android, iOS, macOS, tvOS, watchOS, Windows.</param>
    /// <returns>true if the current application is running on the specified platform; false otherwise.</returns>
    ///Link: https://learn.microsoft.com/en-us/dotnet/api/system.operatingsystem.isosplatform
    public static bool IsOSPlatform(string platform) =>
#if NET5_0_OR_GREATER
        OperatingSystem.IsOSPlatform(platform);
#else
        RuntimeInformation.IsOSPlatform(OSPlatform.Create(platform));
#endif

    /// <summary>
    /// Checks if the operating system version is greater than or equal to the specified platform version. This method can be used to guard APIs that were added in the specified OS version.
    /// </summary>
    /// <param name="platform">The case-insensitive platform name. Examples: Browser, Linux, FreeBSD, Android, iOS, macOS, tvOS, watchOS, Windows.</param>
    /// <param name="major">The major release number.</param>
    /// <param name="minor">The minor release number (optional).</param>
    /// <param name="build">The build release number (optional).</param>
    /// <param name="revision">The revision release number (optional).</param>
    /// <returns>true if the current application is running on the specified platform and is at least in the version specified in the parameters; false otherwise.</returns>
    ///Link: https://learn.microsoft.com/en-us/dotnet/api/system.operatingsystem.isosplatformversionatleast
    public static bool IsOSPlatformVersionAtLeast(string platform, int major, int minor = 0, int build = 0, int revision = 0) =>
#if NET5_0_OR_GREATER
        OperatingSystem.IsOSPlatformVersionAtLeast(platform, major, minor, build, revision);
#else
        IsOSPlatform(platform) &&
        IsOsVersionAtLeast(major, minor, build, revision);
#endif

    /// <summary>
    /// Indicates whether the current application is running on Windows.
    /// </summary>
    /// <returns>true if the current application is running on Windows; false otherwise.</returns>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.operatingsystem.iswindows
    public static bool IsWindows() =>
#if NET5_0_OR_GREATER
        OperatingSystem.IsWindows();
#else
        RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
#endif

    /// <summary>
    /// Checks if the Windows version (returned by RtlGetVersion) is greater than or equal to the specified version. This method can be used to guard APIs that were added in the specified Windows version.
    /// </summary>
    /// <param name="major">The major release number.</param>
    /// <param name="minor">The minor release number.</param>
    /// <param name="build">The build release number.</param>
    /// <param name="revision">The revision release number.</param>
    /// <returns>true if the current application is running on a Windows version that is at least what was specified in the parameters; false otherwise.</returns>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.operatingsystem.iswindowsversionatleast
    public static bool IsWindowsVersionAtLeast(int major, int minor = 0, int build = 0, int revision = 0)
    {
#if NET5_0_OR_GREATER
        return OperatingSystem.IsWindowsVersionAtLeast(major, minor, build, revision);
#else
        if (!IsWindows())
        {
            return false;
        }

        var input = RuntimeInformation.OSDescription
                .Replace("Microsoft Windows", string.Empty)
                .Replace(" ", string.Empty);
        var version = Version.Parse(input);

        return version >= new Version(major, minor, build, revision);
#endif
    }

    /// <summary>
    /// Indicates whether the current application is running on macOS.
    /// </summary>
    /// <returns>true if the current application is running on macOS; false otherwise.</returns>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.operatingsystem.ismacos
    public static bool IsMacOS() =>
#if NET5_0_OR_GREATER
        OperatingSystem.IsMacOS();
#else
        RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
#endif

    /// <summary>
    /// Indicates whether the current application is running on Mac Catalyst.
    /// </summary>
    /// <returns>true if the current application is running on Mac Catalyst; false otherwise.</returns>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.operatingsystem.ismaccatalyst
    public static bool IsMacCatalyst() =>
#if NET6_0_OR_GREATER
        OperatingSystem.IsMacCatalyst();
#else
        IsMacOS() ||
        IsIOS();
#endif

    /// <summary>
    /// Checks if the macOS version (returned by libobjc.get_operatingSystemVersion) is greater than or equal to the specified version. This method can be used to guard APIs that were added in the specified macOS version.
    /// </summary>
    /// <param name="major">The major release number.</param>
    /// <param name="minor">The minor release number.</param>
    /// <param name="build">The build release number.</param>
    /// <returns>true if the current application is running on an macOS version that is at least what was specified in the parameters; false otherwise.</returns>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.operatingsystem.ismacosversionatleast
    public static bool IsMacOSVersionAtLeast(int major, int minor = 0, int build = 0)
    {
#if NET5_0_OR_GREATER
        return OperatingSystem.IsMacOSVersionAtLeast(major, minor, build);
#else
        if (!IsMacOS())
        {
            return false;
        }

        var versionString = RunProcess("/usr/bin/sw_vers", "")
            .Replace("ProductVersion:", string.Empty)
            .Replace(" ", string.Empty);

        var version = Version.Parse(versionString.Split(Environment.NewLine.ToCharArray())[0]);

        return version >= new Version(major, minor, build);
#endif
    }

    /// <summary>
    /// Check for the Mac Catalyst version (iOS version as presented in Apple documentation) with a ≤ version comparison. Used to guard APIs that were added in the given Mac Catalyst release.
    /// </summary>
    /// <param name="major">The version major number.</param>
    /// <param name="minor">The version minor number.</param>
    /// <param name="build">The version build number.</param>
    /// <returns>true if the Mac Catalyst version is greater or equal than the specified version comparison; false otherwise.</returns>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.operatingsystem.ismaccatalystversionatleast
    public static bool IsMacCatalystVersionAtLeast(int major, int minor = 0, int build = 0) =>
#if NET6_0_OR_GREATER
        OperatingSystem.IsMacCatalystVersionAtLeast(major, minor, build);
#else
        IsMacCatalyst() &&
        IsOsVersionAtLeast(major, minor, build);
#endif

    /// <summary>
    /// Indicates whether the current application is running on Linux.
    /// </summary>
    /// <returns>true if the current application is running on Linux; false otherwise.</returns>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.operatingsystem.islinux
    public static bool IsLinux() =>
#if NET5_0_OR_GREATER
        OperatingSystem.IsLinux();
#else
        RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
#endif

    /// <summary>
    /// Indicates whether the current application is running on FreeBSD.
    /// </summary>
    /// <returns>true if the current application is running on FreeBSD; false otherwise.</returns>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.operatingsystem.isfreebsd
    public static bool IsFreeBSD() =>
#if NET5_0_OR_GREATER
        OperatingSystem.IsFreeBSD();
#else
        RuntimeInformation.OSDescription.ToLower().Contains("freebsd");
#endif

    /// <summary>
    ///Checks if the FreeBSD version (returned by the Linux command uname) is greater than or equal to the specified version.
    /// This method can be used to guard APIs that were added in the specified version.
    /// </summary>
    /// <param name="major">The version major number.</param>
    /// <param name="minor">The version minor number.</param>
    /// <param name="build">The version build number.</param>
    /// <param name="revision">The version revision number.</param>
    /// <returns>true if the current application is running on a FreeBSD version that is at least what was specified in the parameters; false otherwise.</returns>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.operatingsystem.isfreebsdversionatleast
    public static bool IsFreeBSDVersionAtLeast(int major, int minor, int build = 0, int revision = 0) =>
#if NET5_0_OR_GREATER
        OperatingSystem.IsFreeBSDVersionAtLeast(major, minor, build, revision);
#else
        GetFreeBSDVersion() >= new Version(major, minor, build, revision);
#endif

    /// <summary>
    /// Indicates whether the current application is running on iOS or MacCatalyst.
    /// </summary>
    /// <returns>true if the current application is running on iOS or MacCatalyst; false otherwise.</returns>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.operatingsystem.isios
    public static bool IsIOS()
    {
#if NET5_0_OR_GREATER
        return OperatingSystem.IsIOS();
#else
        var description = RuntimeInformation.OSDescription.ToLower();
        return description.Contains("ios") ||
               description.Contains("ipados") ||
               (description.Contains("iphone") &&
                description.Contains("os"));
#endif
    }

    /// <summary>
    /// Checks if the iOS/MacCatalyst version (returned by libobjc.get_operatingSystemVersion) is greater than or equal to the specified version. This method can be used to guard APIs that were added in the specified iOS version.
    /// </summary>
    /// <param name="major">The major release number.</param>
    /// <param name="minor">The minor release number.</param>
    /// <param name="build">The build release number.</param>
    /// <returns>true if the current application is running on an iOS/MacCatalyst version that is at least what was specified in the parameters; false otherwise.</returns>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.operatingsystem.isiosversionatleast
    public static bool IsIOSVersionAtLeast(int major, int minor = 0, int build = 0) =>
#if NET5_0_OR_GREATER
        OperatingSystem.IsIOSVersionAtLeast(major, minor, build);
#else
        IsIOS() &&
        IsOsVersionAtLeast(major, minor, build);
#endif

    /// <summary>
    /// Indicates whether the current application is running on tvOS.
    /// </summary>
    /// <returns>true if the current application is running on tvOS; false otherwise.</returns>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.operatingsystem.istvos
    public static bool IsTvOS() =>
#if NET5_0_OR_GREATER
        OperatingSystem.IsTvOS();
#else
        RuntimeInformation.OSDescription.ToLower().Contains("tvos");
#endif

    /// <summary>
    /// Checks if the tvOS version (returned by libobjc.get_operatingSystemVersion) is greater than or equal to the specified version. This method can be used to guard APIs that were added in the specified tvOS version.
    /// </summary>
    /// <param name="major">The major release number.</param>
    /// <param name="minor">The minor release number.</param>
    /// <param name="build">The build release number.</param>
    /// <returns>true if the current application is running on a tvOS version that is at least what was specified in the parameters; false otherwise.</returns>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.operatingsystem.istvosversionatleast
    public static bool IsTvOSVersionAtLeast(int major, int minor = 0, int build = 0) =>
#if NET5_0_OR_GREATER
        OperatingSystem.IsTvOSVersionAtLeast(major, minor, build);
#else
        IsTvOS() &&
        IsOsVersionAtLeast(major, minor, build);
#endif

    /// <summary>
    /// Indicates whether the current application is running on Android.
    /// </summary>
    /// <returns>true if the current application is running on Android; false otherwise.</returns>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.operatingsystem.isandroid
    public static bool IsAndroid()
    {
#if NET5_0_OR_GREATER
        return OperatingSystem.IsAndroid();
#else
        try
        {
            return RunProcess("uname", "-o")
                .Replace(" ", string.Empty)
                .ToLower()
                .Equals("android");
        }
        catch
        {
            return false;
        }
#endif
    }

    /// <summary>
    /// Checks if the Android version (returned by the Linux command uname) is greater than or equal to the specified version. This method can be used to guard APIs that were added in the specified version.
    /// </summary>
    /// <param name="major">The major release number.</param>
    /// <param name="minor">The minor release number.</param>
    /// <param name="build">The build release number.</param>
    /// <param name="revision">The revision release number.</param>
    /// <returns>true if the current application is running on an Android version that is at least what was specified in the parameters; false otherwise.</returns>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.operatingsystem.isandroidversionatleast
    public static bool IsAndroidVersionAtLeast(int major, int minor = 0, int build = 0, int revision = 0) =>
#if NET5_0_OR_GREATER
        OperatingSystem.IsAndroidVersionAtLeast(major, minor, build, revision);
#else
        IsAndroid() &&
        GetAndroidVersion() >= new Version(major, minor, build, revision);
#endif

    /// <summary>
    /// Indicates whether the current application is running on watchOS.
    /// </summary>
    /// <returns>true if the current application is running on watchOS; false otherwise.</returns>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.operatingsystem.iswatchos
    public static bool IsWatchOS() =>
#if NET5_0_OR_GREATER
        OperatingSystem.IsWatchOS();
#else
        IsIOS() ||
        RuntimeInformation.OSDescription.ToLower().Contains("watchos");
#endif

    /// <summary>
    /// Checks if the watchOS version (returned by libobjc.get_operatingSystemVersion) is greater than or equal to the specified version. This method can be used to guard APIs that were added in the specified watchOS version.
    /// </summary>
    /// <param name="major">The major release number.</param>
    /// <param name="minor">The minor release number.</param>
    /// <param name="build">The build release number.</param>
    /// <returns>true if the current application is running on a watchOS version that is at least what was specified in the parameters; false otherwise.</returns>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.operatingsystem.iswatchosversionatleast
    public static bool IsWatchOSVersionAtLeast(int major, int minor = 0, int build = 0) =>
#if NET5_0_OR_GREATER
        OperatingSystem.IsWatchOSVersionAtLeast(major, minor, build);
#else
        IsWatchOS() &&
        IsOsVersionAtLeast(major, minor, build);
#endif

    /// <summary>
    /// Indicates whether the current application is running as WASI.
    /// </summary>
    /// <returns>true if running as WASI; false otherwise.</returns>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.operatingsystem.iswasi
    public static bool IsWasi() =>
#if NET8_0_OR_GREATER
        OperatingSystem.IsWasi();
#else
        RuntimeInformation.FrameworkDescription.ToLower().Contains("wasi");
#endif

    /// <summary>
    /// Indicates whether the current application is running as WASM in a browser.
    /// </summary>
    /// <returns>true if running as WASM; false otherwise.</returns>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.operatingsystem.isbrowser
    public static bool IsBrowser() =>
#if NET5_0_OR_GREATER
        OperatingSystem.IsBrowser();
#else
        RuntimeInformation.FrameworkDescription.Contains(".NET WebAssembly");
#endif

    static bool IsOsVersionAtLeast(int major, int minor = 0, int build = 0, int revision = 0) =>
        Environment.OSVersion.Version >= new Version(major, minor, build, revision);
}

#endif