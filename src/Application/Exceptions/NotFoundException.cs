using PipelineBehaviorsDemo.Domain.Models;

namespace PipelineBehaviorsDemo.Application.Exceptions;

public sealed class NotFoundException : Exception
{
    private NotFoundException()
    {
    }

    private NotFoundException(string message) : base(message)
    {
    }

    private NotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public static NotFoundException CityIsNotFound(City city)
    {
        return new NotFoundException($"City ({city.Name}) is not found.");
    }
}
