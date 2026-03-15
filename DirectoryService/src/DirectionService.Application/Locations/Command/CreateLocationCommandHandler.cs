using CSharpFunctionalExtensions;
using DirectionService.Domain.Locations;
using FluentValidation;
using Shared;
using Shared.Abstractions;
using Shared.Extensions;

namespace DirectionService.Application.Locations.Command;

public class CreateLocationCommandHandler : ICommandHandler<Guid, CreateLocationCommand>
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
            name: command.Location.Name,
            country: command.Location.Address.Country,
            city: command.Location.Address.City,
            street: command.Location.Address.Street,
            houseNumber: command.Location.Address.HouseNumber,
            postalCode: command.Location.Address.PostalCode,
            timezone: command.Location.TimeZone);

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