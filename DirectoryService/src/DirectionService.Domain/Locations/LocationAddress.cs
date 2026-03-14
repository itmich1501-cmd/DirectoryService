using CSharpFunctionalExtensions;
using Shared;

namespace DirectionService.Domain.Locations;

public record LocationAddress
{
    private LocationAddress(
        string country,
        string city,
        string street,
        string houseNumber,
        string postalCode)
    {
        Country = country;
        City = city;
        Street = street;
        HouseNumber = houseNumber;
        PostalCode = postalCode;
    }

    public string Country { get; }
    public string City { get; }
    public string Street { get; }
    public string HouseNumber { get; }
    public string PostalCode { get; }

    public static Result<LocationAddress, Error> Create(
        string country,
        string city,
        string street,
        string houseNumber,
        string postalCode)
    {
        return new LocationAddress(country, city, street, houseNumber, postalCode);
    }
}