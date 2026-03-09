using DirectionService.Domain.Locations;

namespace DirectionService.Domain.Departaments;

public record DepartmentLocationId(Guid Value);

public class DepartmentLocation
{
    private DepartmentLocation()
    {
    }

    private DepartmentLocation(DepartmentLocationId id, DepartmentId departmentId, LocationId locationId)
    {
        Id = id;
        DepartmentId = departmentId;
        LocationId = locationId;
    }

    public DepartmentLocationId Id { get; private init; }

    public DepartmentId DepartmentId { get; private set; }

    public LocationId LocationId { get; private set; }

    public static DepartmentLocation Create(DepartmentId departmentId, LocationId locationId)
    {
        return new DepartmentLocation(new DepartmentLocationId(Guid.NewGuid()), departmentId, locationId);
    }
}