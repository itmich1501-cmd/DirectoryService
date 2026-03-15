using CSharpFunctionalExtensions;
using Shared;

namespace DirectionService.Domain.Locations;

public record LocationName
{
    private LocationName(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public static Result<LocationName, Error> Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Error.Validation("location.name", "Location name is required");
        }

        return new LocationName(name);
    }
}