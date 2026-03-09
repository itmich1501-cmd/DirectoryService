using CSharpFunctionalExtensions;
using Shared;

namespace DirectionService.Domain.Departaments;

public record DepartmentPath
{
    private DepartmentPath()
    {
    }

    private DepartmentPath(string path)
    {
        Path = path;
    }

    public string Path { get; }

    public static Result<DepartmentPath, Error> Create(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            return Error.Validation("department.path", "Department path is required");
        }

        return new DepartmentPath(path);
    }
    
    public static DepartmentPath FromDatabase(string value)
    {
        return new DepartmentPath(value);
    }
}