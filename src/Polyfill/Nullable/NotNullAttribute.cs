// <auto-generated />
#pragma warning disable

#if NETSTANDARD2_0 || NETFRAMEWORK || NETCOREAPP2X

namespace System.Diagnostics.CodeAnalysis;

using Targets = AttributeTargets;

/// <summary>
///   Specifies that an output is not <see langword="null"/> even if the
///   corresponding type allows it.
/// </summary>
[ExcludeFromCodeCoverage]
[DebuggerNonUserCode]
[AttributeUsage(
    validOn: Targets.Field |
             Targets.Parameter |
             Targets.Property |
             Targets.ReturnValue)]
#if PolyPublic
public
#endif
sealed class NotNullAttribute :
    Attribute;
#else
using System.Runtime.CompilerServices;
[assembly: TypeForwardedTo(typeof(System.Diagnostics.CodeAnalysis.NotNullAttribute))]
#endif