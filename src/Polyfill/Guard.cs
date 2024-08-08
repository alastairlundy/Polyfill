// <auto-generated />

namespace Polyfills;

using System.Runtime.CompilerServices;

#pragma warning disable

#if PolyGuard

using System;
using System.IO;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
[DebuggerNonUserCode]
#if PolyPublic
public
#endif
static partial class Guard
{
    public static void FileExists(string path, [CallerArgumentExpression("path")] string argumentName = "")
    {
        NotNullOrEmpty(path, argumentName);
        if (!File.Exists(path))
        {
            throw new ArgumentException($"File not found. Path: {path}", argumentName);
        }
    }

    public static void DirectoryExists(string path, [CallerArgumentExpression("path")] string argumentName = "")
    {
        NotNullOrEmpty(path, argumentName);
        if (!Directory.Exists(path))
        {
            throw new ArgumentException($"Directory not found. Path: {path}", argumentName);
        }
    }
}
#endif