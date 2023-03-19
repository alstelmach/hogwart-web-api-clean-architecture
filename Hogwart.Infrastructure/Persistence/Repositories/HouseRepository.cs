using Hogwart.Domain.Aggregates.House;
using Hogwart.Domain.Repositories;

namespace Hogwart.Infrastructure.Persistence.Repositories;

/// <summary>
/// We've encapsulated the persistence logic in repository.
/// If we aimed to introduce a real database instead of in-memory
/// dummy implementation - only this class will be changed.
/// </summary>
public sealed class HouseRepository : IHouseRepository
{
    private static readonly List<House> Houses = new()
    {
        new Slytherin("Slytherin"),
        new Gryffindor("Gryffindor"),
        new Ravenclaw("Ravenclaw"),
        new Hufflepuff("Hufflepuff"),
    };

    public Task<ICollection<House>> GetAsync(CancellationToken cancellationToken = default) =>
        Task.FromResult<ICollection<House>>(Houses);

    public Task<House> GetAsync(
        string houseName,
        CancellationToken cancellationToken = default)
    {
        var house = Houses.FirstOrDefault(house => house.Name == houseName);
        var taskResult = Task.FromResult(house);

        return taskResult;
    }

    public Task UpdateAsync(
        House house,
        CancellationToken cancellationToken = default)
    {
        var houseIndex = Houses.FindIndex(actualHouse => actualHouse.Name == house.Name);

        if (houseIndex != -1)
        {
            Houses[houseIndex] = house;
        }

        return Task.CompletedTask;
    }
}
