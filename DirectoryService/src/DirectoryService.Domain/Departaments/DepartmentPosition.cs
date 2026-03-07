using DirectoryService.Domain.Locations;
using DirectoryService.Domain.Positions;

namespace DirectoryService.Domain.Departaments;

public class DepartmentPosition
{
    private DepartmentPosition()
    {
    }

    private DepartmentPosition(Guid id, DepartmentId departmentId, PositionId positionId)
    {
        Id = id;
        DepartmentId = departmentId;
        PositionId = positionId;
    }

    public Guid Id { get; private init; }

    public DepartmentId DepartmentId { get; private set; }

    public PositionId PositionId { get; private set; }

    public static DepartmentPosition Create(DepartmentId departmentId, PositionId positionId)
    {
        return new DepartmentPosition(Guid.NewGuid(), departmentId, positionId);
    }
}