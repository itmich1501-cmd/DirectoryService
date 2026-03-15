using CSharpFunctionalExtensions;
using Shared;

namespace DirectionService.Domain.Departaments;

public record DepartmentIdentifier
{
    private DepartmentIdentifier(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<DepartmentIdentifier, Error> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return Error.Validation("department.identifier",  "Department identifier is required");
        }

        return new DepartmentIdentifier(value);
    }
}