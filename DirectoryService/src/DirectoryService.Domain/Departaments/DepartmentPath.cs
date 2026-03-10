using CSharpFunctionalExtensions;
using Shared;

namespace DirectoryService.Domain.Departaments;

public record DepartmentPath
{
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
}