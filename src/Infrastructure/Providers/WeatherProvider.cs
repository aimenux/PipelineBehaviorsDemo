using PipelineBehaviorsDemo.Application.Abstractions;
using PipelineBehaviorsDemo.Domain.Models;

namespace PipelineBehaviorsDemo.Infrastructure.Providers;

public sealed class WeatherProvider : IWeatherProvider
{
    public async Task<Weather> GetWeatherByCityAsync(City city, CancellationToken cancellationToken)
    {
        var date = new Date(DateOnly.FromDateTime(DateTime.Now));
        var celsiusTemperature = new Temperature(Random.Shared.Next(-20, 60));
        var weather = Weather.Create(city, date, celsiusTemperature);
        await SimulateLatencyAsync(cancellationToken);
        return weather;
    }

    private static Task SimulateLatencyAsync(CancellationToken cancellationToken)
    {
        var delay = Random.Shared.Next(100, 1000);
        return Task.Delay(delay, cancellationToken);
    }
}
