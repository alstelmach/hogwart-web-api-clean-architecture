using Hogwart.Application.Contracts;
using Hogwart.Domain.Aggregates.House.Entities;
using Hogwart.Domain.Repositories;
using Hogwart.Domain.Services;
using MediatR;

namespace Hogwart.Application.Services;

public sealed class HouseCommandHandler : IRequestHandler<AssignStudentToHouseCommand>,
    IRequestHandler<MoveStudentToOtherHouseCommand>
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
            new Random().Next(0, int.MaxValue), // Ignore this randomization for now :)
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

    public async Task Handle(
        MoveStudentToOtherHouseCommand command,
        CancellationToken cancellationToken)
    {
        var houses = await _houseRepository.GetAsync(cancellationToken);

        var actualHouse = houses.First(house =>
            house.Students.Any(student =>
                student.Id == command.StudentId));

        var destinationHouse = houses.First(house => house.Name == command.DestinationHouseName);

        var student = actualHouse.RemoveStudent(command.StudentId);
        destinationHouse.AssignStudent(student);

        await _houseRepository.UpdateAsync(actualHouse, cancellationToken);
        await _houseRepository.UpdateAsync(destinationHouse, cancellationToken);
    }
}
