using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using PipelineBehaviorsDemo.Application.Filters;

namespace PipelineBehaviorsDemo.Presentation;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers(options =>
        {
            options.Filters.Add<ApiExceptionFilter>();
        });
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddApiVersioning();
        return services;
    }

    private static IServiceCollection AddApiVersioning(this IServiceCollection services)
    {
        const string name = "x-api-version";
        services.AddApiVersioning(config =>
        {
            config.ReportApiVersions = true;
            config.AssumeDefaultVersionWhenUnspecified = true;
            config.DefaultApiVersion = new ApiVersion(1, 0);
            config.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
                new HeaderApiVersionReader(name),
                new MediaTypeApiVersionReader(name));
        });
        return services;
    }
}
