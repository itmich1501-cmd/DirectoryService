using DirectionService.Domain.Positions;
using DirectionService.Domain.Locations;

namespace DirectionService.Domain.Departaments;

public record DepartmentPositionId(Guid Value);

public class DepartmentPosition
{
    private DepartmentPosition()
    {
    }

    private DepartmentPosition(DepartmentPositionId id, DepartmentId departmentId, PositionId positionId)
    {
        Id = id;
        DepartmentId = departmentId;
        PositionId = positionId;
    }

    public DepartmentPositionId Id { get; private init; }

    public DepartmentId DepartmentId { get; private set; }

    public PositionId PositionId { get; private set; }

    public static DepartmentPosition Create(DepartmentId departmentId, PositionId positionId)
    {
        return new DepartmentPosition(new DepartmentPositionId(Guid.NewGuid()), departmentId, positionId);
    }
}