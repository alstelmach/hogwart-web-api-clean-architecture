using Hogwart.Application.Contracts;
using Hogwart.Domain.Aggregates.House.Entities;
using Hogwart.Domain.Repositories;
using Hogwart.Domain.Services;
using MediatR;

namespace Hogwart.Application.Services;

public sealed class HouseCommandHandler : IRequestHandler<AssignStudentToHouseCommand>
{
    private readonly ISortingDomainService _sortingDomainService;
    private readonly IHouseRepository _houseRepository;

    public HouseCommandHandler(
        ISortingDomainService sortingDomainService,
        IHouseRepository houseRepository)
    {
        _sortingDomainService = sortingDomainService;
        _houseRepository = houseRepository;
    }
    
    public async Task Handle(
        AssignStudentToHouseCommand command, 
        CancellationToken cancellationToken)
    {
        var student = new Student(
            command.FirstName,
            command.LastName,
            command.Age,
            command.DoesSpeakParseltongue,
            command.IsAmbitious,
            command.DoesPlayQuidditch,
            command.HeightInCentimeters,
            command.Nationality);

        var house = await _sortingDomainService.DetermineHouseAsync(student, cancellationToken);

        house.AssignStudent(student);

        await _houseRepository.UpdateAsync(house, cancellationToken);
    }
}