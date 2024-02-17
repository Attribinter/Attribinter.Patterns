﻿namespace SharpAttributeParser.Patterns;

using System.Collections.Generic;

internal sealed class NonNullableReadOnlyArrayArgumentPattern<TElement> : IArgumentPattern<IReadOnlyList<TElement>>
{
    private readonly IArgumentPattern<TElement> ElementPattern;

    public NonNullableReadOnlyArrayArgumentPattern(IArgumentPattern<TElement> elementPattern)
    {
        ElementPattern = elementPattern;
    }

    PatternMatchResult<IReadOnlyList<TElement>> IArgumentPattern<IReadOnlyList<TElement>>.TryMatch(object? argument)
    {
        if (argument is null)
        {
            return new();
        }

        if (argument is TElement[] elementArrayArgument)
        {
            return MatchElementArray(elementArrayArgument);
        }

        if (argument is object[] objectArrayArgument)
        {
            return MatchObjectArray(objectArrayArgument);
        }

        return new();
    }

    private PatternMatchResult<IReadOnlyList<TElement>> MatchElementArray(IReadOnlyList<TElement> elementArrayArgument)
    {
        var convertedArguments = new TElement[elementArrayArgument.Count];

        for (var i = 0; i < convertedArguments.Length; i++)
        {
            var elementResult = ElementPattern.TryMatch(elementArrayArgument[i]);

            if (elementResult.WasSuccessful is false)
            {
                return new();
            }

            convertedArguments[i] = elementResult.GetMatchedArgument();
        }

        return new(convertedArguments);
    }

    private PatternMatchResult<IReadOnlyList<TElement>> MatchObjectArray(IReadOnlyList<object> objectArrayArgument)
    {
        var convertedArguments = new TElement[objectArrayArgument.Count];

        for (var i = 0; i < convertedArguments.Length; i++)
        {
            var elementResult = ElementPattern.TryMatch(objectArrayArgument[i]);

            if (elementResult.WasSuccessful is false)
            {
                return new();
            }

            convertedArguments[i] = elementResult.GetMatchedArgument();
        }

        return new(convertedArguments);
    }
}
