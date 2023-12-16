namespace PipelineBehaviorsDemo.Presentation.Controllers.V1.GetWeatherByCity;

public class GetWeatherByCityApiResponse
{
    public string City { get; init; } = default!;
    public DateOnly Date { get; init; }
    public int CelsiusTemperature { get; init; }
    public int FahrenheitTemperature { get; init; }
}
