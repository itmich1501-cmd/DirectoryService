using CSharpFunctionalExtensions;
using DirectionService.Application.Locations;
using DirectionService.Domain.Locations;
using Shared;

namespace DirectionService.Infrastructure.Postgres.Repositories;

public class LocationRepository : ILocationRepository
{
    private readonly DepartmentServiceDbContext _context;

    public LocationRepository(DepartmentServiceDbContext context)
    {
        _context = context;
    }

    public async Task<UnitResult<Error>> Add(Location location, CancellationToken cancellationToken)
    {
        await _context.Locations.AddAsync(location, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return UnitResult.Success<Error>();
    }
}