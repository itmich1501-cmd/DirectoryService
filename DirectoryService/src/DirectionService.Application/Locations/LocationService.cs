using CSharpFunctionalExtensions;
using DirectionService.Contracts.Locations;
using DirectionService.Domain.Locations;

namespace DirectionService.Application.Locations;

public class LocationService
{
    private readonly ILocationRepository _locationRepository;

    public LocationService(ILocationRepository locationRepository)
    {
        _locationRepository = locationRepository;
    }

    public async Task<Result<>> Create(CreateLocationsDto request)
    {
        var location = Location.Create(
            request.Name,
            request.Country,
            request.City,
            request.Street,
            request.HouseNumber,
            request.PostalCode,
            request.Timezone);
        
        
    }
}