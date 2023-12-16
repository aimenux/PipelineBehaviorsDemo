using PipelineBehaviorsDemo.Domain.Models;

namespace PipelineBehaviorsDemo.Application.Abstractions;

public interface IWeatherProvider
{
    Task<Weather> GetWeatherByCityAsync(City city, CancellationToken cancellationToken);
}
