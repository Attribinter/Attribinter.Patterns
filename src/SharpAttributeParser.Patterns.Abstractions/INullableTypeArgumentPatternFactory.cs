﻿namespace SharpAttributeParser.Patterns;

using Microsoft.CodeAnalysis;

using System;

/// <summary>Handles creation of <see cref="IArgumentPattern{T}"/> matching nullable <see cref="ITypeSymbol"/> arguments.</summary>
/// <remarks>Attribute arguments of type <see cref="Type"/> will match the created patterns, as Roslyn uses <see cref="ITypeSymbol"/> to represent <see cref="Type"/>.</remarks>
public interface INullableTypeArgumentPatternFactory
{
    /// <summary>Creates a pattern which ensures that arguments are either <see langword="null"/> or of type <see cref="ITypeSymbol"/>.</summary>
    /// <remarks>Attribute arguments of type <see cref="Type"/> will match the created pattern, as Roslyn uses <see cref="ITypeSymbol"/> to represent <see cref="Type"/>.</remarks>
    /// <returns>The created pattern.</returns>
    public abstract IArgumentPattern<ITypeSymbol?> Create();
}
