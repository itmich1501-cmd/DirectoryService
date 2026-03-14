using CSharpFunctionalExtensions;
using Shared;

namespace DirectoryService.Domain.Locations;

public record LocationAddress
{
    private LocationAddress(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public static Result<LocationAddress, Error> Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Error.Validation("location.address", "Location address is required");
        }

        return new LocationAddress(name);
    }
}