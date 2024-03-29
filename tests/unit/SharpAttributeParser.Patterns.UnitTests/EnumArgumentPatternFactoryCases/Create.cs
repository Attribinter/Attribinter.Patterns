﻿namespace SharpAttributeParser.Patterns.EnumArgumentPatternFactoryCases;

using System;

using Xunit;

public sealed class Create
{
    private static IArgumentPattern<StringComparison> Target(IEnumArgumentPatternFactory factory) => factory.Create<StringComparison>();

    private static readonly FactoryContext Context = FactoryContext.Create();

    [Fact]
    public void NotNull()
    {
        var actual = Target(Context.Factory);

        Assert.NotNull(actual);
    }
}
