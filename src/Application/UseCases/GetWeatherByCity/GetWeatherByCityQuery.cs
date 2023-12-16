using MediatR;

namespace PipelineBehaviorsDemo.Application.UseCases.GetWeatherByCity;

public sealed record GetWeatherByCityQuery(string city) : IRequest<GetWeatherByCityQueryResponse>;
