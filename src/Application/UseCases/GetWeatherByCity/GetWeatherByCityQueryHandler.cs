using MediatR;
using PipelineBehaviorsDemo.Application.Abstractions;
using PipelineBehaviorsDemo.Application.Exceptions;
using PipelineBehaviorsDemo.Domain.BusinessRules;
using PipelineBehaviorsDemo.Domain.Models;

namespace PipelineBehaviorsDemo.Application.UseCases.GetWeatherByCity;

public sealed class GetWeatherByCityQueryHandler : IRequestHandler<GetWeatherByCityQuery, GetWeatherByCityQueryResponse>
{
    private readonly IWeatherProvider _weatherProvider;

    public GetWeatherByCityQueryHandler(IWeatherProvider weatherProvider)
    {
        _weatherProvider = weatherProvider ?? throw new ArgumentNullException(nameof(weatherProvider));
    }

    public async Task<GetWeatherByCityQueryResponse> Handle(GetWeatherByCityQuery request, CancellationToken cancellationToken)
    {
        var city = new City(request.city.ToUpper());
        if (!CityBusinessRules.IsSupportedCity(city))
        {
            throw NotFoundException.CityIsNotFound(city);
        }

        var weather = await _weatherProvider.GetWeatherByCityAsync(city, cancellationToken);
        return new GetWeatherByCityQueryResponse
        {
            City = weather.City.Name,
            Date = weather.Date.Value,
            CelsiusTemperature = weather.CelsiusTemperature.Value,
            FahrenheitTemperature = weather.FahrenheitTemperature.Value
        };
    }
}
