using FluentValidation;

namespace PipelineBehaviorsDemo.Application.UseCases.GetWeatherByCity;

public class GetWeatherByCityQueryValidator : AbstractValidator<GetWeatherByCityQuery>
{
    public GetWeatherByCityQueryValidator()
    {
        RuleFor(x => x.city)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(100)
            .Must(x => x.All(char.IsLetter));
    }
}
