// <auto-generated />
#pragma warning disable

#if (NETFRAMEWORK || NETSTANDARD2_0 || NETCOREAPP2X) && FeatureValueTask

namespace Polyfills;

using System;
using System.IO;
using System.Threading.Tasks;
using Link = System.ComponentModel.DescriptionAttribute;

static partial class Polyfill
{
    //https://github.com/dotnet/runtime/blob/main/src/libraries/System.Private.CoreLib/src/System/IO/Stream.cs#L174
    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources asynchronously.
    /// </summary>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.io.stream.disposeasync
    public static ValueTask DisposeAsync(this Stream target)
    {
        try
        {
            target.Dispose();
            return default;
        }
        catch (Exception exception)
        {
            return new ValueTask(Task.FromException(exception));
        }
    }
}
#endif