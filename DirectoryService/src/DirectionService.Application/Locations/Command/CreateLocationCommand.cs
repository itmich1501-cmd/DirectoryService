using DirectionService.Contracts.Locations.Requests;
using Shared.Abstractions;

namespace DirectionService.Application.Locations.Command;

public record CreateLocationCommand(
    CreateLocationRequest Location
) : ICommand;