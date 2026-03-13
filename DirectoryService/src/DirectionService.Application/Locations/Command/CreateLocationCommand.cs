using Shared.Abstractions;

namespace DirectionService.Application.Locations.Command;

public record CreateLocationCommand(
    string Name,
    string Country,
    string City,
    string Street,
    string HouseNumber,
    string PostalCode,
    string TimeZone
) : ICommand;