using DirectionService.Domain.Locations;

namespace DirectionService.Application.Locations;

public class ILocationRepository
{
    Task<Guid> AddAsync(Location location, CancellationToken cancellationToken);
}