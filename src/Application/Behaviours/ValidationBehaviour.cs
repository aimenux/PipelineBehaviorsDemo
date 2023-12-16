using FluentValidation;
using MediatR;
using PipelineBehaviorsDemo.Application.Exceptions;

namespace PipelineBehaviorsDemo.Application.Behaviours;

public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);
            var tasks = _validators
                .Select(x => x.ValidateAsync(context, cancellationToken))
                .ToList();
            var validationResults = await Task.WhenAll(tasks);
            var failures = validationResults
                .Where(x => x.Errors.Any())
                .SelectMany(x => x.Errors)
                .ToList();
            if (failures.Any())
            {
                throw new NotValidException(failures);
            }
        }
        return await next();
    }
}
