using System.Net.NetworkInformation;
using CSharpFunctionalExtensions;
using Shared;

namespace DirectionService.Domain.Departaments;

public record DepartmentId(Guid Value);

public class Departament
{
    private List<DepartmentPosition> _positions = [];
    private List<DepartmentLocation> _locations = [];

    private Departament()
    {
    }

    public Departament(
        DepartmentId id,
        DepartmentName name,
        string identifier,
        DepartmentId? parentId,
        DepartmentPath path,
        short depth)
    {
        Id = id;
        Name = name;
        Identifier = identifier;
        ParentId = parentId;
        Path = path;
        Depth = depth;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
    }

    public DepartmentId Id { get; private set; }

    public DepartmentName Name { get; private set; }

    public string Identifier { get; private set; }

    public DepartmentId? ParentId { get; private set; }

    public DepartmentPath Path { get; private set; }

    public short Depth { get; private set; }

    public bool IsActive { get; private set; }

    public IReadOnlyList<DepartmentPosition> Positions => _positions;
    public IReadOnlyList<DepartmentLocation> Locations => _locations;

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    public static Result<Departament, Error> Create(
        string name,
        string identifier,
        DepartmentId? parentId,
        DepartmentPath path,
        short depth,
        DepartmentId? departmentId = null)
    {
        var departmentName = DepartmentName.Create(name);
        if (departmentName.IsFailure)
        {
            return departmentName.Error;
        }

        return new Departament(
            departmentId ?? new DepartmentId(Guid.NewGuid()),
            departmentName.Value,
            identifier,
            parentId,
            path,
            depth);
    }

    public UnitResult<Error> AddPosition(DepartmentPosition position)
    {
        _positions.Add(position);

        return UnitResult.Success<Error>();
    }

    public UnitResult<Error> AddLocation(DepartmentLocation location)
    {
        _locations.Add(location);

        return UnitResult.Success<Error>();
    }
}