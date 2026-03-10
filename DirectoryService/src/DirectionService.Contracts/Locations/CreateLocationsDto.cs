namespace DirectionService.Contracts.Locations;

public record CreateLocationsDto(
    string Name,
    string Country,
    string City,
    string Street,
    string HouseNumber,
    string PostalCode,
    string Timezone);