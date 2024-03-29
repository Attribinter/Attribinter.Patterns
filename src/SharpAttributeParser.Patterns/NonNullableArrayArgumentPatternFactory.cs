﻿namespace SharpAttributeParser.Patterns;

using System;

/// <inheritdoc cref="INonNullableArrayArgumentPatternFactory"/>
public sealed class NonNullableArrayArgumentPatternFactory : INonNullableArrayArgumentPatternFactory
{
    /// <summary>Instantiates a <see cref="NonNullableArrayArgumentPatternFactory"/>, handling creation of <see cref="IArgumentPattern{T}"/> matching non-nullable array-valued arguments.</summary>
    public NonNullableArrayArgumentPatternFactory() { }

    IArgumentPattern<TElement[]> INonNullableArrayArgumentPatternFactory.Create<TElement>(IArgumentPattern<TElement> elementPattern)
    {
        if (elementPattern is null)
        {
            throw new ArgumentNullException(nameof(elementPattern));
        }

        return new NonNullableArrayArgumentPattern<TElement>(elementPattern);
    }
}
