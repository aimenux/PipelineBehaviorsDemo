using MediatR;
using Microsoft.AspNetCore.Mvc;
using PipelineBehaviorsDemo.Application.UseCases.GetWeatherByCity;
using Swashbuckle.AspNetCore.Annotations;

namespace PipelineBehaviorsDemo.Presentation.Controllers.V1.GetWeatherByCity;

public class GetWeatherByCityApiController : WeathersController
{
    public GetWeatherByCityApiController(ISender sender, ILogger<WeathersController> logger) : base(sender, logger)
    {
    }

    [HttpGet("{city}")]
    [SwaggerOperation("GetWeatherByCity")]
    [SwaggerResponse(statusCode: 200, type: typeof(GetWeatherByCityApiResponse))]
    [SwaggerResponse(statusCode: 400, type: typeof(ValidationProblemDetails))]
    [SwaggerResponse(statusCode: 500, type: typeof(ProblemDetails))]
    public async Task<IActionResult> GetWeatherByCityAsync(string city, CancellationToken cancellationToken)
    {
        var request = new GetWeatherByCityQuery(city);
        var response = await Sender.Send(request, cancellationToken);
        var apiResponse = new GetWeatherByCityApiResponse
        {
            City = response.City,
            Date = response.Date,
            CelsiusTemperature = response.CelsiusTemperature,
            FahrenheitTemperature = response.FahrenheitTemperature
        };
        return Ok(apiResponse);
    }
}
