﻿namespace Attribinter.Patterns.AttribinterPatternsServicesCases;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Moq;

using System;

using Xunit;

public sealed class AddAttribinterPatterns
{
    private static IServiceCollection Target(IServiceCollection services) => AttribinterPatternsServices.AddAttribinterPatterns(services);

    private readonly IServiceProvider ServiceProvider;

    public AddAttribinterPatterns()
    {
        HostBuilder host = new();

        host.ConfigureServices(static (services) => Target(services));

        ServiceProvider = host.Build().Services;
    }

    [Fact]
    public void NullServiceCollection_ThrowsArgumentNullException()
    {
        var exception = Record.Exception(() => Target(null!));

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Fact]
    public void ValidServiceCollection_ReturnsSameServiceCollection()
    {
        var serviceCollection = Mock.Of<IServiceCollection>();

        var actual = Target(serviceCollection);

        Assert.Same(serviceCollection, actual);
    }

    [Fact]
    public void IArgumentPatternFactoryProvider_ServiceCanBeResolved() => ServiceCanBeResolved<IArgumentPatternFactoryProvider>();

    [Fact]
    public void IStringArgumentPatternFactoryProvider_ServiceCanBeResolved() => ServiceCanBeResolved<IStringArgumentPatternFactoryProvider>();

    [Fact]
    public void IObjectArgumentPatternFactoryProvider_ServiceCanBeResolved() => ServiceCanBeResolved<IObjectArgumentPatternFactoryProvider>();

    [Fact]
    public void ITypeArgumentPatternFactoryProvider_ServiceCanBeResolved() => ServiceCanBeResolved<ITypeArgumentPatternFactoryProvider>();

    [Fact]
    public void IArrayArgumentPatternFactoryProvider_ServiceCanBeResolved() => ServiceCanBeResolved<IArrayArgumentPatternFactoryProvider>();

    [Fact]
    public void INullableArrayArgumentPatternFactoryProvider_ServiceCanBeResolved() => ServiceCanBeResolved<INullableArrayArgumentPatternFactoryProvider>();

    [Fact]
    public void INonNullableArrayArgumentPatternFactoryProvider_ServiceCanBeResolved() => ServiceCanBeResolved<INonNullableArrayArgumentPatternFactoryProvider>();

    [Fact]
    public void IBoolArgumentPatternFactory_ServiceCanBeResolved() => ServiceCanBeResolved<IBoolArgumentPatternFactory>();

    [Fact]
    public void IByteArgumentPatternFactory_ServiceCanBeResolved() => ServiceCanBeResolved<IByteArgumentPatternFactory>();

    [Fact]
    public void ISByteArgumentPatternFactory_ServiceCanBeResolved() => ServiceCanBeResolved<ISByteArgumentPatternFactory>();

    [Fact]
    public void ICharArgumentPatternFactory_ServiceCanBeResolved() => ServiceCanBeResolved<ICharArgumentPatternFactory>();

    [Fact]
    public void IShortArgumentPatternFactory_ServiceCanBeResolved() => ServiceCanBeResolved<IShortArgumentPatternFactory>();

    [Fact]
    public void IUShortArgumentPatternFactory_ServiceCanBeResolved() => ServiceCanBeResolved<IUShortArgumentPatternFactory>();

    [Fact]
    public void IIntArgumentPatternFactory_ServiceCanBeResolved() => ServiceCanBeResolved<IIntArgumentPatternFactory>();

    [Fact]
    public void IUIntArgumentPatternFactory_ServiceCanBeResolved() => ServiceCanBeResolved<IUIntArgumentPatternFactory>();

    [Fact]
    public void ILongArgumentPatternFactory_ServiceCanBeResolved() => ServiceCanBeResolved<ILongArgumentPatternFactory>();

    [Fact]
    public void IULongArgumentPatternFactory_ServiceCanBeResolved() => ServiceCanBeResolved<IULongArgumentPatternFactory>();

    [Fact]
    public void IFloatArgumentPatternFactory_ServiceCanBeResolved() => ServiceCanBeResolved<IFloatArgumentPatternFactory>();

    [Fact]
    public void IDoubleArgumentPatternFactory_ServiceCanBeResolved() => ServiceCanBeResolved<IDoubleArgumentPatternFactory>();

    [Fact]
    public void IEnumArgumentPatternFactory_ServiceCanBeResolved() => ServiceCanBeResolved<IEnumArgumentPatternFactory>();

    [Fact]
    public void INonNullableStringArgumentPatternFactory_ServiceCanBeResolved() => ServiceCanBeResolved<INonNullableStringArgumentPatternFactory>();

    [Fact]
    public void INullableStringArgumentPatternFactory_ServiceCanBeResolved() => ServiceCanBeResolved<INullableStringArgumentPatternFactory>();

    [Fact]
    public void INonNullableObjectArgumentPatternFactory_ServiceCanBeResolved() => ServiceCanBeResolved<INonNullableObjectArgumentPatternFactory>();

    [Fact]
    public void INullableObjectArgumentPatternFactory_ServiceCanBeResolved() => ServiceCanBeResolved<INullableObjectArgumentPatternFactory>();

    [Fact]
    public void INonNullableTypeArgumentPatternFactory_ServiceCanBeResolved() => ServiceCanBeResolved<INonNullableTypeArgumentPatternFactory>();

    [Fact]
    public void INullableTypeArgumentPatternFactory_ServiceCanBeResolved() => ServiceCanBeResolved<INullableTypeArgumentPatternFactory>();

    [Fact]
    public void INullableReadWriteArrayArgumentPatternFactory_ServiceCanBeResolved() => ServiceCanBeResolved<INullableReadWriteArrayArgumentPatternFactory>();

    [Fact]
    public void INullableReadOnlyArrayArgumentPatternFactory_ServiceCanBeResolved() => ServiceCanBeResolved<INullableReadWriteArrayArgumentPatternFactory>();

    [Fact]
    public void INonNullableReadWriteArrayArgumentPatternFactory_ServiceCanBeResolved() => ServiceCanBeResolved<INonNullableReadWriteArrayArgumentPatternFactory>();

    [Fact]
    public void INonNullableReadOnlyArrayArgumentPatternFactory_ServiceCanBeResolved() => ServiceCanBeResolved<INonNullableReadOnlyArrayArgumentPatternFactory>();

    [AssertionMethod]
    private void ServiceCanBeResolved<TService>() where TService : notnull
    {
        var service = ServiceProvider.GetRequiredService<TService>();

        Assert.NotNull(service);
    }
}