using CSharpFunctionalExtensions;
using Shared;

namespace DirectionService.Domain.Departaments;

public record DepartmentName
{
    private DepartmentName(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public static Result<DepartmentName, Error> Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Error.Validation("department.name", "Department name is required");
        }

        return new DepartmentName(name);
    }

    public static DepartmentName FromDatabase(string value)
    {
        return new DepartmentName(value);
    }
}