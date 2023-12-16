using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PipelineBehaviorsDemo.Application.Exceptions;

namespace PipelineBehaviorsDemo.Application.Filters;

public sealed class ApiExceptionFilter : IExceptionFilter
{
    private static readonly IDictionary<Predicate<ExceptionContext>, Action<ExceptionContext>> ExceptionHandlers =
        new Dictionary<Predicate<ExceptionContext>, Action<ExceptionContext>>
        {
            [context => context.ExceptionHandled] = { },
            [context => context.Exception is NotFoundException] = HandleNotFoundException,
            [context => context.Exception is NotValidException] = HandleNotValidException,
            [context => !context.ModelState.IsValid] = HandleInvalidModelStateException,
            [context => !context.ExceptionHandled] = HandleUnhandledException
        };

    public void OnException(ExceptionContext context)
    {
        var (_, exceptionHandler) = ExceptionHandlers.FirstOrDefault(x => x.Key.Invoke(context));
        exceptionHandler?.Invoke(context);
    }

    private static void HandleNotValidException(ExceptionContext context)
    {
        var exception = (NotValidException)context.Exception;
        var details = new ValidationProblemDetails(exception.Errors)
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"
        };

        context.Result = new BadRequestObjectResult(details);
        context.ExceptionHandled = true;
    }

    private static void HandleNotFoundException(ExceptionContext context)
    {
        var exception = (NotFoundException)context.Exception;
        var details = new ProblemDetails
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
            Title = "The specified resource was not found.",
            Detail = exception.Message
        };

        context.Result = new NotFoundObjectResult(details);
        context.ExceptionHandled = true;
    }

    private static void HandleInvalidModelStateException(ExceptionContext context)
    {
        var details = new ValidationProblemDetails(context.ModelState)
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"
        };

        context.Result = new BadRequestObjectResult(details);
        context.ExceptionHandled = true;
    }

    private static void HandleUnhandledException(ExceptionContext context)
    {
        var exception = context.Exception;
        var details = new ProblemDetails
        {
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1",
            Title = "Internal Server Error.",
            Detail = exception.Message
        };

        context.Result = new ObjectResult(details)
        {
            StatusCode = StatusCodes.Status500InternalServerError
        };
        context.ExceptionHandled = true;
    }
}
