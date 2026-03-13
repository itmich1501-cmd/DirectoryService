using CSharpFunctionalExtensions;
using DirectionService.Domain.Locations;
using FluentValidation;
using Shared;
using Shared.Extensions;

namespace DirectionService.Application.Locations.Command;

public class CreateLocationCommandHandler
{
    private readonly ILocationRepository _locationRepository;
    private readonly IValidator<CreateLocationCommand> _validator;

    public CreateLocationCommandHandler(
        ILocationRepository locationRepository,
        IValidator<CreateLocationCommand> validator)
    {
        _locationRepository = locationRepository;
        _validator = validator;
    }

    public async Task<Result<Guid, Failure>> Handle(CreateLocationCommand command, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(command, cancellationToken);
        if (!validationResult.IsValid)
        {
            return validationResult.ToErrors();
        }

        var locationResult = Location.Create(
            name: command.Name,
            country: command.Country,
            city: command.City,
            street: command.Street,
            houseNumber: command.HouseNumber,
            postalCode: command.PostalCode,
            timezone: command.TimeZone);

        if (locationResult.IsFailure)
        {
            return (Failure)locationResult.Error;
        }

        var addResult = await _locationRepository.Add(locationResult.Value, cancellationToken);
        if (addResult.IsFailure)
        {
            return (Failure)addResult.Error;
        }

        return locationResult.Value.Id.Value;
    }
}