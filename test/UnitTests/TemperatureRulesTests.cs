using FluentAssertions;
using PipelineBehaviorsDemo.Domain.BusinessRules;
using PipelineBehaviorsDemo.Domain.Models;

namespace PipelineBehaviorsDemo.Tests.UnitTests;

public class TemperatureRulesTests
{
    [Theory]
    [InlineData(10, 49)]
    [InlineData(20, 67)]
    [InlineData(30, 85)]
    public void FromCelsiusToFahrenheit_Should_Return_Valid_Results(int celsiusValue, int expectedFahrenheitValue)
    {
        // arrange
        var celsiusTemperature = new Temperature(celsiusValue);

        // act
        var fahrenheitTemperature = TemperatureBusinessRules.FromCelsiusToFahrenheit(celsiusTemperature);

        // assert
        fahrenheitTemperature.Value.Should().Be(expectedFahrenheitValue);
    }
}
