using FluentAssertions;
using PipelineBehaviorsDemo.Domain.BusinessRules;
using PipelineBehaviorsDemo.Domain.Models;

namespace PipelineBehaviorsDemo.Tests.UnitTests;

public class CityBusinessRulesTests
{
    [Theory]
    [InlineData("rome")]
    [InlineData("carthage")]
    public void IsSupportedCity_Should_Be_True(string cityName)
    {
        // arrange
        var city = new City(cityName);

        // act
        var isSupported = CityBusinessRules.IsSupportedCity(city);

        // assert
        isSupported.Should().BeTrue();
    }

    [Theory]
    [InlineData("xyz")]
    [InlineData("abc")]
    public void IsSupportedCity_Should_Be_False(string cityName)
    {
        // arrange
        var city = new City(cityName);

        // act
        var isSupported = CityBusinessRules.IsSupportedCity(city);

        // assert
        isSupported.Should().BeFalse();
    }
}
