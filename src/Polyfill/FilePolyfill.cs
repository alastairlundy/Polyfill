// <auto-generated />


using System.Runtime.CompilerServices;

#pragma warning disable

namespace Polyfills;

using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
[DebuggerNonUserCode]
#if PolyPublic
public
#endif
static partial class FilePolyfill
{
        /// <summary>
        /// Appends the specified byte array to the end of the file at the given path.
        /// If the file doesn't exist, this method creates a new file. If the operation is canceled, the task will return in a canceled state.
        /// </summary>
        //Link: https://learn.microsoft.com/en-us/dotnet/api/system.io.file.appendallbytes#system-io-file-appendallbytes(system-string-system-byte())
        public static void AppendAllBytes(string path, byte[] bytes)
        {
#if NET9_0_OR_GREATER
            File.AppendAllBytes(path, bytes);
#else
            using var stream = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.None);
            stream.Write(bytes, 0, bytes.Length);
#endif
        }

#if FeatureMemory
        /// <summary>
        /// Appends the specified byte array to the end of the file at the given path.
        /// If the file doesn't exist, this method creates a new file. If the operation is canceled, the task will return in a canceled state.
        /// </summary>
        //Link: https://learn.microsoft.com/en-us/dotnet/api/system.io.file.appendallbytes#system-io-file-appendallbytes(system-string-system-readonlyspan((system-byte)))
        public static void AppendAllBytes(string path, ReadOnlySpan<byte> bytes)
        {
#if NET9_0_OR_GREATER
            File.AppendAllBytes(path, bytes);
#else
            using var stream = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.None);
            stream.Write(bytes.ToArray(), 0, bytes.Length);
#endif
        }
#endif

        /// <summary>
        /// Asynchronously appends the specified byte array to the end of the file at the given path.
        /// If the file doesn't exist, this method creates a new file. If the operation is canceled, the task will return in a canceled state.
        /// </summary>
        //Link: https://learn.microsoft.com/en-us/dotnet/api/system.io.file.appendallbytesasync#system-io-file-appendallbytesasync(system-string-system-byte()-system-threading-cancellationtoken)
        public static async Task AppendAllBytesAsync(string path, byte[] bytes, CancellationToken cancellationToken = default)
        {
#if NET9_0_OR_GREATER
            await File.AppendAllBytesAsync(path, bytes, cancellationToken);
#else
            using var stream = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.None);
            await stream.WriteAsync(bytes, 0, bytes.Length);
#endif
        }

#if FeatureMemory
        /// <summary>
        /// Asynchronously appends the specified byte array to the end of the file at the given path.
        /// If the file doesn't exist, this method creates a new file. If the operation is canceled, the task will return in a canceled state.
        /// </summary>
        //Link: https://learn.microsoft.com/en-us/dotnet/api/system.io.file.appendallbytesasync#system-io-file-appendallbytesasync(system-string-system-readonlymemory((system-byte))-system-threading-cancellationtoken)
        public static Task AppendAllBytesAsync(string path, ReadOnlyMemory<byte> bytes, CancellationToken cancellationToken = default)
        {
#if NET9_0_OR_GREATER
            return File.AppendAllBytesAsync(path, bytes, cancellationToken);
#else
            return AppendAllBytesAsync(path, bytes.ToArray(), cancellationToken);
#endif
        }
#endif

        /// <summary>
        /// Asynchronously appends lines to a file, and then closes the file. If the specified file does not exist, this method creates a file, writes the specified lines to the file, and then closes the file.
        /// </summary>
        //Link: https://learn.microsoft.com/en-us/dotnet/api/system.io.file.appendalllinesasync#system-io-file-appendalllinesasync(system-string-system-collections-generic-ienumerable((system-string))-system-threading-cancellationtoken)
        public static Task AppendAllLinesAsync(string path, IEnumerable<string> contents, CancellationToken cancellationToken = default)
        {
#if NETCOREAPP2_0_OR_GREATER || NETSTANDARD2_1
            return File.AppendAllLinesAsync(path, contents, cancellationToken);
#else
            return AppendAllLinesAsync(path, contents, Encoding.UTF8, cancellationToken);
#endif
        }

        /// <summary>
        /// Asynchronously appends lines to a file by using a specified encoding, and then closes the file. If the specified file does not exist, this method creates a file, writes the specified lines to the file, and then closes the file.
        /// </summary>
        //Link: https://learn.microsoft.com/en-us/dotnet/api/system.io.file.appendalllinesasync#system-io-file-appendalllinesasync(system-string-system-collections-generic-ienumerable((system-string))-system-text-encoding-system-threading-cancellationtoken)
        public static async Task AppendAllLinesAsync(string path, IEnumerable<string> contents, Encoding encoding, CancellationToken cancellationToken = default)
        {
#if NETCOREAPP2_0_OR_GREATER || NETSTANDARD2_1
            await File.AppendAllLinesAsync(path, contents, encoding, cancellationToken);
#else
            using var stream = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.None);
            using var writer = new StreamWriter(stream, encoding);

            foreach (var content in contents)
            {
                await writer.WriteLineAsync(content);
            }

            await writer.FlushAsync();
#endif
        }

#if FeatureMemory
        /// <summary>
        /// Appends the specified string to the file, creating the file if it does not already exist.
        /// </summary>
        //Link: https://learn.microsoft.com/en-us/dotnet/api/system.io.file.appendalltext#system-io-file-appendalltext(system-string-system-readonlyspan((system-char)))
        public static void AppendAllText(string path, ReadOnlySpan<char> contents) =>
#if NET9_0_OR_GREATER
            File.AppendAllText(path, contents);
#else
            File.AppendAllText(path, contents.ToString());
#endif

        /// <summary>
        /// Appends the specified string to the file, creating the file if it does not already exist.
        /// </summary>
        //Link: https://learn.microsoft.com/en-us/dotnet/api/system.io.file.appendalltext#system-io-file-appendalltext(system-string-system-readonlyspan((system-char))-system-text-encoding)
        public static void AppendAllText(string path, ReadOnlySpan<char> contents, Encoding encoding) =>
#if NET9_0_OR_GREATER
            File.AppendAllText(path, contents, encoding);
#else
            File.AppendAllText(path, contents.ToString(), encoding);
#endif
#endif

        /// <summary>
        /// Asynchronously opens a file or creates the file if it does not already exist, appends the specified string to the file using the specified encoding, and then closes the file.
        /// </summary>
        //Link: https://learn.microsoft.com/en-us/dotnet/api/system.io.file.appendalltextasync#system-io-file-appendalltextasync(system-string-system-string-system-text-encoding-system-threading-cancellationtoken)
        public static async Task AppendAllTextAsync(string path, string? contents, Encoding encoding, CancellationToken cancellationToken = default)
        {
#if NETFRAMEWORK || NETSTANDARD2_0
            using var stream = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.None);
            using var writer = new StreamWriter(stream, encoding);

            await writer.WriteAsync(contents);

            await writer.FlushAsync(cancellationToken);
#else
            await File.AppendAllTextAsync(path, contents, encoding, cancellationToken);
#endif
        }

        /// <summary>
        /// Asynchronously opens a file or creates the file if it does not already exist, appends the specified string to the file, and then closes the file.
        /// </summary>
        //Link: https://learn.microsoft.com/en-us/dotnet/api/system.io.file.appendalltextasync#system-io-file-appendalltextasync(system-string-system-string-system-threading-cancellationtoken)
        public static Task AppendAllTextAsync(string path, string? contents, CancellationToken cancellationToken = default)
        {
#if NETFRAMEWORK || NETSTANDARD2_0
            return AppendAllTextAsync(path, contents, Encoding.UTF8, cancellationToken);
#else
            return File.AppendAllTextAsync(path, contents, cancellationToken);
#endif
        }

#if FeatureMemory
        /// <summary>
        /// Asynchronously opens a file or creates the file if it does not already exist, appends the specified string to the file using the specified encoding, and then closes the file.
        /// </summary>
        //Link: https://learn.microsoft.com/en-us/dotnet/api/system.io.file.appendalltextasync#system-io-file-appendalltextasync(system-string-system-readonlymemory((system-char))-system-text-encoding-system-threading-cancellationtoken)
        public static Task AppendAllTextAsync(string path, ReadOnlyMemory<char> contents, Encoding encoding, CancellationToken cancellationToken = default) =>
#if NET9_0_OR_GREATER
            File.AppendAllTextAsync(path, contents, encoding, cancellationToken);
#else
            AppendAllTextAsync(path, contents.ToString(), encoding);
#endif

        /// <summary>
        /// Asynchronously opens a file or creates the file if it does not already exist, appends the specified string to the file, and then closes the file.
        /// </summary>
        //Link: https://learn.microsoft.com/en-us/dotnet/api/system.io.file.appendalltextasync#system-io-file-appendalltextasync(system-string-system-readonlymemory((system-char))-system-threading-cancellationtoken)
        public static Task AppendAllTextAsync(string path, ReadOnlyMemory<char> contents, CancellationToken cancellationToken = default) =>
#if NET9_0_OR_GREATER
            File.AppendAllTextAsync(path, contents, cancellationToken);
#else
            AppendAllTextAsync(path, contents.ToString());
#endif
#endif

        /// <summary>
        /// Asynchronously opens a binary file, reads the contents of the file into a byte array, and then closes the file.
        /// </summary>
        //Link: https://learn.microsoft.com/en-us/dotnet/api/system.io.file.readallbytesasync
        public static async Task<byte[]> ReadAllBytesAsync(string path, CancellationToken cancellationToken = default)
        {
#if NETFRAMEWORK || NETSTANDARD2_0
            using var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true);
            var length = (int)stream.Length;
            var bytes = new byte[length];
            var bytesRead = 0;
            while (bytesRead < length)
            {
                var read = await stream.ReadAsync(bytes, bytesRead, length - bytesRead);
                if (read == 0)
                {
                    throw new EndOfStreamException($"End of stream reached with {length - bytesRead} bytes left to read");
                }

                bytesRead += read;
            }

            return bytes;
#else
            return await File.ReadAllBytesAsync(path, cancellationToken);
#endif
        }
        /// <summary>
        /// Asynchronously opens a text file, reads all lines of the file, and then closes the file.
        /// </summary>
        //Link: https://learn.microsoft.com/en-us/dotnet/api/system.io.file.readalllinesasync#system-io-file-readalllinesasync(system-string-system-threading-cancellationtoken)
        public static Task<string[]> ReadAllLinesAsync(string path, CancellationToken cancellationToken = default) =>
#if NETFRAMEWORK || NETSTANDARD2_0
            ReadAllLinesAsync(path, Encoding.UTF8, cancellationToken);
#else
            File.ReadAllLinesAsync(path, cancellationToken);
#endif


        /// <summary>
        /// Asynchronously opens a text file, reads all lines of the file with the specified encoding, and then closes the file.
        /// </summary>
        //Link: https://learn.microsoft.com/en-us/dotnet/api/system.io.file.readalllinesasync#system-io-file-readalllinesasync(system-string-system-text-encoding-system-threading-cancellationtoken)
        public static async Task<string[]> ReadAllLinesAsync(string path, Encoding encoding, CancellationToken cancellationToken = default)
        {
    #if NETFRAMEWORK || NETSTANDARD2_0
            var lines = new List<string>();
            using var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true);
            using var reader = new StreamReader(stream);

            while (!reader.EndOfStream)
            {
                cancellationToken.ThrowIfCancellationRequested();
                var line = await reader.ReadLineAsync().ConfigureAwait(false);
                if (line != null)
                {
                    lines.Add(line);
                }
            }

            return lines.ToArray();
    #else
            return await File.ReadAllLinesAsync(path, encoding, cancellationToken);
    #endif
        }

    /// <summary>
        /// Asynchronously opens a text file, reads all the text in the file, and then closes the file.
        /// </summary>
        //Link: https://learn.microsoft.com/en-us/dotnet/api/system.io.file.readalltextasync#system-io-file-readalltextasync(system-string-system-threading-cancellationtoken)
        public static Task<string> ReadAllTextAsync(string path, CancellationToken cancellationToken = default) =>
#if NETFRAMEWORK || NETSTANDARD2_0
            ReadAllTextAsync(path, Encoding.UTF8, cancellationToken);
#else
            File.ReadAllTextAsync(path, cancellationToken);
#endif

    /// <summary>
    /// Asynchronously opens a text file, reads all text in the file with the specified encoding, and then closes the file.
    /// </summary>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.io.file.readalltextasync#system-io-file-readalltextasync(system-string-system-text-encoding-system-threading-cancellationtoken)
    public static async Task<string> ReadAllTextAsync(string path, Encoding encoding, CancellationToken cancellationToken = default)
    {
#if NETFRAMEWORK || NETSTANDARD2_0
        using var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true);
        using var reader = new StreamReader(stream, encoding);
        return await reader.ReadToEndAsync().ConfigureAwait(false);
#else
        return await File.ReadAllTextAsync(path, encoding, cancellationToken);
#endif
    }

    //TODO: re add NETSTANDARD via https://www.nuget.org/packages/Microsoft.Bcl.AsyncInterfaces#dependencies-body-tab
#if NETCOREAPP3_0_OR_GREATER// || NETSTANDARD
    /// <summary>
    /// Asynchronously reads the lines of a file.
    /// </summary>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.io.file.readlinesasync#system-io-file-readalllinesasync(system-string-system-threading-cancellationtoken)
    public static IAsyncEnumerable<string> ReadLinesAsync(string path, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
#if NET7_0_OR_GREATER
        return File.ReadLinesAsync(path, cancellationToken);
#else
        return ReadLinesAsync(path, Encoding.UTF8, cancellationToken);
#endif
    }

    /// <summary>
    /// Asynchronously reads the lines of a file that has a specified encoding.
    /// </summary>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.io.file.readlinesasync#system-io-file-readalllinesasync(system-string-system-text-encoding-system-threading-cancellationtoken)
    public static async IAsyncEnumerable<string> ReadLinesAsync(string path, Encoding encoding, CancellationToken cancellationToken = default)
    {
#if NET7_0_OR_GREATER
        await foreach (var line in File.ReadLinesAsync(path, encoding, cancellationToken))
        {
            yield return line;
        }
#else
        using var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true);
        using var reader = new StreamReader(stream, encoding);
        while (!reader.EndOfStream)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var line = await reader.ReadLineAsync();
            if (line != null)
            {
                yield return line;
            }
        }
#endif
    }
#endif

    /// <summary>
    /// Asynchronously creates a new file, writes the specified byte array to the file, and then closes the file. If the target file already exists, it is truncated and overwritten.
    /// </summary>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.io.file.writeallbytesasync#system-io-file-writeallbytesasync(system-string-system-byte()-system-threading-cancellationtoken)
    public static async Task WriteAllBytesAsync (string path, byte[] bytes, CancellationToken cancellationToken = default)
    {
#if NETCOREAPP2_0_OR_GREATER || NETSTANDARD2_1
        await File.WriteAllBytesAsync (path, bytes, cancellationToken);
#else
        using var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: 4096, useAsync: true);
        await stream.WriteAsync(bytes, 0, bytes.Length, cancellationToken).ConfigureAwait(false);
#endif
    }

#if FeatureMemory
    /// <summary>
    /// Asynchronously creates a new file, writes the specified byte array to the file, and then closes the file. If the target file already exists, it is truncated and overwritten.
    /// </summary>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.io.file.appendallbytesasync#system-io-file-appendallbytesasync(system-string-system-readonlymemory((system-byte))-system-threading-cancellationtoken)
    public static Task WriteAllBytesAsync (string path, ReadOnlyMemory<byte> bytes, CancellationToken cancellationToken = default)
    {
#if NET9_0_OR_GREATER
        return File.WriteAllBytesAsync (path, bytes, cancellationToken);
#else
        return WriteAllBytesAsync(path, bytes.ToArray(), cancellationToken);
#endif
    }
#endif

    /// <summary>
    /// Asynchronously creates a new file, writes the specified lines to the file, and then closes the file.
    /// </summary>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.io.file.writealllinesasync#system-io-file-writealllinesasync(system-string-system-collections-generic-ienumerable((system-string))-system-threading-cancellationtoken)
    public static Task WriteAllLinesAsync (string path, IEnumerable<string> contents, CancellationToken cancellationToken = default)
    {
#if NETCOREAPP2_0_OR_GREATER || NETSTANDARD2_1
        return File.WriteAllLinesAsync(path, contents, cancellationToken);
#else
        return WriteAllLinesAsync(path, contents, Encoding.UTF8, cancellationToken);
#endif
    }

    /// <summary>
    /// Asynchronously creates a new file, write the specified lines to the file by using the specified encoding, and then closes the file.
    /// </summary>
    //Link: https://learn.microsoft.com/en-us/dotnet/api/system.io.file.writealllinesasync#system-io-file-writealllinesasync(system-string-system-collections-generic-ienumerable((system-string))-system-text-encoding-system-threading-cancellationtoken)
    public static async Task WriteAllLinesAsync(string path, IEnumerable<string> contents, Encoding encoding, CancellationToken cancellationToken = default)
    {
#if NETCOREAPP2_0_OR_GREATER || NETSTANDARD2_1
        await File.WriteAllLinesAsync(path, contents, encoding, cancellationToken);
#else
        using var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: 4096, useAsync: true);
        using var writer = new StreamWriter(stream, encoding);

        foreach (var line in contents)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await writer.WriteLineAsync(line).ConfigureAwait(false);
        }

        await writer.FlushAsync().ConfigureAwait(false);
#endif
    }

#if FeatureMemory
        /// <summary>
        /// Creates a new file, writes the specified string to the file, and then closes the file.
        /// If the target file already exists, it is truncated and overwritten.
        /// </summary>
        //Link: https://learn.microsoft.com/en-us/dotnet/api/system.io.file.writealltext#system-io-file-writealltext(system-string-system-readonlyspan((system-char)))
        public static void WriteAllText(string path, ReadOnlySpan<char> contents) =>
#if NET9_0_OR_GREATER
            File.WriteAllText(path, contents);
#else
            File.WriteAllText(path, contents.ToString());
#endif

        /// <summary>
        /// Creates a new file, writes the specified string to the file using the specified encoding, and then closes the file.
        /// If the target file already exists, it is truncated and overwritten.
        /// </summary>
        //Link: https://learn.microsoft.com/en-us/dotnet/api/system.io.file.writealltext#system-io-file-writealltext(system-string-system-readonlyspan((system-char))-system-text-encoding)
        public static void WriteAllText(string path, ReadOnlySpan<char> contents, Encoding encoding) =>
#if NET9_0_OR_GREATER
            File.WriteAllText(path, contents, encoding);
#else
            File.WriteAllText(path, contents.ToString(), encoding);
#endif
#endif

        /// <summary>
        /// Asynchronously creates a new file, writes the specified string to the file using the specified encoding, and then closes the file. If the target file already exists, it is truncated and overwritten.
        /// </summary>
        //Link: https://learn.microsoft.com/en-us/dotnet/api/system.io.file.writealltextasync#system-io-file-writealltextasync(system-string-system-string-system-text-encoding-system-threading-cancellationtoken)
        public static async Task WriteAllTextAsync(string path, string? contents, Encoding encoding, CancellationToken cancellationToken = default)
        {
#if NETFRAMEWORK || NETSTANDARD2_0
            using var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: 4096, useAsync: true);
            using var writer = new StreamWriter(stream, encoding);

            if (contents != null)
            {
                await writer.WriteAsync(contents).ConfigureAwait(false);
            }

            await writer.FlushAsync().ConfigureAwait(false);
#else
            await File.WriteAllTextAsync(path, contents, encoding, cancellationToken);
#endif
        }

        /// <summary>
        /// Asynchronously creates a new file, writes the specified string to the file using the specified encoding, and then closes the file. If the target file already exists, it is truncated and overwritten.
        /// </summary>
        //Link: https://learn.microsoft.com/en-us/dotnet/api/system.io.file.writealltextasync#system-io-file-writealltextasync(system-string-system-string-system-text-encoding-system-threading-cancellationtoken)
        public static Task WriteAllTextAsync(string path, string? contents, CancellationToken cancellationToken = default)
        {
#if NETFRAMEWORK || NETSTANDARD2_0
            return WriteAllTextAsync(path, contents, Encoding.UTF8, cancellationToken);
#else
            return File.WriteAllTextAsync(path, contents, cancellationToken);
#endif
        }
}