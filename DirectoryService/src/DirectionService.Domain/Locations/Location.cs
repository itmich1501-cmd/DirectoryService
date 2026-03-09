using System.Net.NetworkInformation;
using CSharpFunctionalExtensions;
using Shared;

namespace DirectionService.Domain.Locations;

public record LocationId(Guid Value);

public class Location
{
    private Location()
    {
    }

    public Location(LocationId id, LocationName name, LocationAddress address, LocationTimezone timezone)
    {
        Id = id;
        Name = name;
        Address = address;
        Timezone = timezone;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
    }

    public LocationId Id { get; private set; }

    public LocationName Name { get; private set; }

    public LocationAddress Address { get; private set; }

    public LocationTimezone Timezone { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    public static Result<Location, Error> Create(
        string name,
        string country,
        string city,
        string street,
        string houseNumber,
        string postalCode,
        string timezone,
        LocationId? locationId = null)
    {
        var locationName = LocationName.Create(name);
        if (locationName.IsFailure)
        {
            return locationName.Error;
        }

        var locationAddress = LocationAddress.Create(
            country,
            city,
            street,
            houseNumber,
            postalCode);

        if (locationAddress.IsFailure)
        {
            return locationAddress.Error;
        }

        var locationTimezone = LocationTimezone.Create(timezone);
        if (locationTimezone.IsFailure)
        {
            return locationTimezone.Error;
        }

        return new Location(
            locationId ?? new LocationId(Guid.NewGuid()),
            locationName.Value,
            locationAddress.Value,
            locationTimezone.Value);
    }
}