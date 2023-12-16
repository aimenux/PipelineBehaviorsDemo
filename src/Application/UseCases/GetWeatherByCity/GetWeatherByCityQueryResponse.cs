namespace PipelineBehaviorsDemo.Application.UseCases.GetWeatherByCity;

public sealed record GetWeatherByCityQueryResponse
{
    public string City { get; init; } = default!;
    public DateOnly Date { get; init; }
    public int CelsiusTemperature { get; init; }
    public int FahrenheitTemperature { get; init; }
}
