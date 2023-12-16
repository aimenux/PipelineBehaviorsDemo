using PipelineBehaviorsDemo.Domain.Models;

namespace PipelineBehaviorsDemo.Domain.BusinessRules;

public static class TemperatureBusinessRules
{
    public static Temperature FromCelsiusToFahrenheit(Temperature celsiusTemperature)
    {
        checked
        {
            return new Temperature(32 + (int)(celsiusTemperature.Value / 0.5556));
        }
    }
}
