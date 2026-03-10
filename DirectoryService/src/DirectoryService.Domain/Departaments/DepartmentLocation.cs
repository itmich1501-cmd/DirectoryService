using DirectoryService.Domain.Locations;

namespace DirectoryService.Domain.Departaments;

public class DepartmentLocation
{
    private DepartmentLocation()
    {
    }

    private DepartmentLocation(Guid id, DepartmentId departmentId, LocationId locationId)
    {
        Id = id;
        DepartmentId = departmentId;
        LocationId = locationId;
    }

    public Guid Id { get; private init; }

    public DepartmentId DepartmentId { get; private set; }

    public LocationId LocationId { get; private set; }

    public static DepartmentLocation Create(DepartmentId departmentId, LocationId locationId)
    {
        return new DepartmentLocation(Guid.NewGuid(), departmentId, locationId);
    }
}