using CSharpFunctionalExtensions;
using DirectionService.Domain.Locations;
using Shared;

namespace DirectionService.Application.Locations;

public interface ILocationRepository
{
    Task<UnitResult<Error>> Add(Location location, CancellationToken cancellationToken);
}