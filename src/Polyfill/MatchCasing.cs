#if !NETCOREAPP2_1_OR_GREATER || !NETSTANDARD2_1_OR_GREATER

namespace System.IO;

#if PolyUseEmbeddedAttribute
[global::Microsoft.CodeAnalysis.EmbeddedAttribute]
#endif
#if PolyPublic
public
#endif
/// <summary>
/// Specified the type of character casing to match
/// </summary>
enum MatchCasing
{
    PlatformDefault = 0,
    CaseSensitive = 1,
    CaseInsensitive = 2,
}
#endif