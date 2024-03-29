﻿namespace SharpAttributeParser.Patterns;

using System;

/// <summary>Handles creation of <see cref="IArgumentPattern{T}"/> matching enum arguments.</summary>
public interface IEnumArgumentPatternFactory
{
    /// <summary>Creates a pattern which ensures that arguments are of a type <typeparamref name="TEnum"/>.</summary>
    /// <typeparam name="TEnum">The type of the arguments matched by the created pattern, an enum type.</typeparam>
    /// <returns>The created pattern.</returns>
    public abstract IArgumentPattern<TEnum> Create<TEnum>() where TEnum : Enum;
}
