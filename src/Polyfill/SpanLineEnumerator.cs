// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// <auto-generated />

#pragma warning disable

#if FeatureMemory && !NET6_0_OR_GREATER

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using Link = System.ComponentModel.DescriptionAttribute;

namespace System.Text;

/// <summary>
/// Enumerates the lines of a <see cref="ReadOnlySpan{Char}"/>.
/// </summary>
/// <remarks>
/// To get an instance of this type, use <see cref="MemoryExtensions.EnumerateLines(ReadOnlySpan{char})"/>.
/// </remarks>
[Link("https://learn.microsoft.com/en-us/dotnet/api/system.text.spanlineenumerator")]
#if PolyPublic
public
#endif
ref struct SpanLineEnumerator
{
    private ReadOnlySpan<char> _remaining;
    private ReadOnlySpan<char> _current;
    private bool _isEnumeratorActive;
    ReadOnlySpan<char> newlines = "\r\f\u0085\u2028\u2029\n".AsSpan();

    internal SpanLineEnumerator(ReadOnlySpan<char> buffer)
    {
        _remaining = buffer;
        _current = default;
        _isEnumeratorActive = true;
    }

    /// <summary>
    /// Gets the line at the current position of the enumerator.
    /// </summary>
    public ReadOnlySpan<char> Current => _current;

    /// <summary>
    /// Returns this instance as an enumerator.
    /// </summary>
    public SpanLineEnumerator GetEnumerator() => this;

    /// <summary>
    /// Advances the enumerator to the next line of the span.
    /// </summary>
    /// <returns>
    /// True if the enumerator successfully advanced to the next line; false if
    /// the enumerator has advanced past the end of the span.
    /// </returns>
    public bool MoveNext()
    {
        if (!_isEnumeratorActive)
        {
            // EOF previously reached or enumerator was never initialized
            return false;
        }

        var remaining = _remaining;
        //TODO: revisit when SearchValues is implemented
        var idx = remaining.IndexOfAny(newlines);

        if ((uint)idx < (uint)remaining.Length)
        {
            var stride = 1;

            if (remaining[idx] == '\r' && (uint)(idx + 1) < (uint)remaining.Length && remaining[idx + 1] == '\n')
            {
                stride = 2;
            }

            _current = remaining[..idx];
            _remaining = remaining[(idx + stride)..];
        }
        else
        {
            // We've reached EOF, but we still need to return 'true' for this final
            // iteration so that the caller can query the Current property once more.

            _current = remaining;
            _remaining = default;
            _isEnumeratorActive = false;
        }

        return true;
    }
}
#endif