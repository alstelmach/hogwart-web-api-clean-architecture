using Hogwart.Domain.Aggregates.House;
using Hogwart.Domain.Aggregates.House.Entities;
using Hogwart.Domain.Repositories;

namespace Hogwart.Domain.Services;

public class SortingDomainService : ISortingDomainService
{
    private readonly IHouseRepository _houseRepository;

    public SortingDomainService(IHouseRepository houseRepository)
    {
        _houseRepository = houseRepository;
    }

    public async Task<House> DetermineHouseAsync(
        Student student,
        CancellationToken cancellationToken = default)
    {
        var houses = await _houseRepository.GetAsync(cancellationToken);
        var sortedHouses = houses
            .OrderBy(GetHouseIndex)
            .ToList();
        
        var houseToBeAssigned = sortedHouses.First(house => house.CanAssignStudent(student));

        return houseToBeAssigned.Students.Count % 2 == 0
            ? houseToBeAssigned
            : await AssignStudentToRandomHouseAsync(
                houses,
                student);
    }

    private async Task<House> AssignStudentToRandomHouseAsync(
        ICollection<House> houses,
        Student student)
    {
        var random = new Random();
        var houseIndex = random.Next(0, 3);
        var house = houses.ElementAt(houseIndex);

        return house.CanAssignStudent(student)
            ? house
            : await AssignStudentToRandomHouseAsync(
                houses,
                student);
    }

    private static int GetHouseIndex(House house) =>
        house switch
        {
            Slytherin => 0,
            Gryffindor => 1,
            Ravenclaw => 2,
            Hufflepuff => 3,
            _ => throw new Exception("Unknown house has been found!"),
        };
}
