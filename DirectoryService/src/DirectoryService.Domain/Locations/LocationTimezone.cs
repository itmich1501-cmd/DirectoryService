using CSharpFunctionalExtensions;
using DirectoryService.Domain.Departaments;
using Shared;

namespace DirectoryService.Domain.Locations;

public record LocationTimezone
{
    private LocationTimezone(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<LocationTimezone, Error> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return Error.Validation("location.timezone", "Location timezone is required");
        }

        return new LocationTimezone(value);
    }
}