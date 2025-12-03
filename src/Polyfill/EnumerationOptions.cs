#if !NETCOREAPP2_1_OR_GREATER || !NETSTANDARD2_1_OR_GREATER
using System.Security;

namespace System.IO;

#if PolyUseEmbeddedAttribute
[global::Microsoft.CodeAnalysis.EmbeddedAttribute]
#endif
#if PolyPublic
public
#endif
class EnumerationOptions
{
    // ReSharper disable once ConvertConstructorToMemberInitializers
    public EnumerationOptions()
    {
        //Set default values in the constructor allegedly like .NET BCL does.
        AttributesToSkip = FileAttributes.Hidden | FileAttributes.System;
        BufferSize = 0;
        IgnoreAccessible = true;
        MaxRecursionDepth = int.MaxValue;
        RecurseSubdirectories = false;
        ReturnSpecialDirectories = false;
        MatchType = MatchType.Simple;
        MatchCasing = MatchCasing.PlatformDefault;
    }

    /// <summary>
    /// The attributes to skip. The default is <code>FileAttributes.Hidden | FileAttributes.System</code>
    /// </summary>
    public FileAttributes AttributesToSkip { get; set; }

    /// <summary>
    /// Gets or sets the suggested buffer size in bytes.
    /// </summary>
    public int BufferSize { get; set; }

    /// <summary>
    /// Gets or sets a value that indicates the maximum directory depth to recurse while enumerating, when RecurseSubdirectories is set to true.
    /// </summary>
    public int MaxRecursionDepth { get; set; }

    /// <summary>
    /// Gets or sets a value that indicates whether to skip files or directories when access is denied (for example, <see cref="UnauthorizedAccessException"/> or <see cref="SecurityException"/>).
    /// </summary>
    public bool IgnoreAccessible { get; set; }

    /// <summary>
    /// Gets or sets a value that indicates whether to recurse into subdirectories while enumerating.
    /// </summary>
    public bool RecurseSubdirectories { get; set; }

    /// <summary>
    /// Gets or sets a value that indicates whether to return the special directory entries "." and "..".
    /// </summary>
    public bool ReturnSpecialDirectories { get; set; }

    /// <summary>
    /// Gets or sets the match type.
    /// </summary>
    public MatchType MatchType { get; set; }

    /// <summary>
    /// Gets or sets the case-matching behavior.
    /// </summary>
    public MatchCasing MatchCasing { get; set; }
}
#endif