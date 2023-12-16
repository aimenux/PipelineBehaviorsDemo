using PipelineBehaviorsDemo.Domain.Models;

namespace PipelineBehaviorsDemo.Domain.BusinessRules;

public static class CityBusinessRules
{
    private static HashSet<string> SupportedCities = new(StringComparer.OrdinalIgnoreCase)
    {
        "Rome",
        "Athens",
        "Babylon",
        "Carthage",
        "Jerusalem",
        "Alexandria",
        "Constantinople"
    };

    public static bool IsSupportedCity(City city) => SupportedCities.Contains(city.Name);
}
