namespace DirectoryService.Domain.Departaments;

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
        Guid parentId,
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

    public Guid ParentId { get; private set; }

    public DepartmentPath Path { get; private set; }

    public short Depth { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }
}