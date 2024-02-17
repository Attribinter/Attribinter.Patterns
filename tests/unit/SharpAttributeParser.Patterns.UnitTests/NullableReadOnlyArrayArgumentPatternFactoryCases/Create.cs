﻿namespace SharpAttributeParser.Patterns.NullableReadOnlyArrayArgumentPatternFactoryCases;

using Moq;

using System;
using System.Collections.Generic;

using Xunit;

public sealed class Create
{
    private static IArgumentPattern<IReadOnlyList<TElement>?> Target<TElement>(INullableReadOnlyArrayArgumentPatternFactory factory, IArgumentPattern<TElement> elementPattern) => factory.Create(elementPattern);

    private static readonly FactoryContext Context = FactoryContext.Create();

    [Fact]
    public void NullElementPattern_ArgumentNullException()
    {
        var exception = Record.Exception(() => Target<object>(Context.Factory, null!));

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Fact]
    public void NotNull()
    {
        var actual = Target(Context.Factory, Mock.Of<IArgumentPattern<object>>());

        Assert.NotNull(actual);
    }
}
