using CSharpFunctionalExtensions;
using Shared;

namespace DirectoryService.Domain.Positions;

public record PositionId(Guid Value);

public class Position
{
    public Position(PositionId id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
    }

    public PositionId Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public static Result<Position, Error> Create(
        string name,
        string description,
        PositionId? positionId = null)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Error.Validation("position.name", "Position name is required");
        }

        if (string.IsNullOrWhiteSpace(description))
        {
            return Error.Validation("position.description", "Position description is required");
        }

        return new Position(positionId ?? new PositionId(Guid.NewGuid()), name, description);
    }
}