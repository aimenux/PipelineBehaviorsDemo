using PipelineBehaviorsDemo.Application.Abstractions;
using PipelineBehaviorsDemo.Infrastructure.Providers;

namespace PipelineBehaviorsDemo.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IWeatherProvider, WeatherProvider>();
        return services;
    }
}
