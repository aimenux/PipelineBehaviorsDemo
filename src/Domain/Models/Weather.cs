using PipelineBehaviorsDemo.Domain.BusinessRules;

namespace PipelineBehaviorsDemo.Domain.Models;

public sealed record Weather
{
    public City City { get; private init; } = default!;
    public Date Date { get; private init; } = default!;
    public Temperature CelsiusTemperature { get; private init; } = default!;
    public Temperature FahrenheitTemperature { get; private init; } = default!;

    public static Weather Create(City city, Date date, Temperature celsiusTemperature)
    {
        var fahrenheitTemperature = TemperatureBusinessRules.FromCelsiusToFahrenheit(celsiusTemperature);
        return new Weather
        {
            City = city,
            Date = date,
            CelsiusTemperature = celsiusTemperature,
            FahrenheitTemperature = fahrenheitTemperature
        };
    }
}
