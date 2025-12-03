#if !NETCOREAPP2_1_OR_GREATER || !NETSTANDARD2_1_OR_GREATER

namespace System.IO;

#if PolyUseEmbeddedAttribute
[global::Microsoft.CodeAnalysis.EmbeddedAttribute]
#endif
#if PolyPublic
public
#endif
/// <summary>
/// Specified the type of wildcard matching to use.
/// </summary>
enum MatchType
{
    Simple = 0,
    Win32 = 1,
}
#endif