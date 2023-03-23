using Hogwart.Domain.Aggregates.House;

namespace Hogwart.Domain.Repositories;

public interface IHouseRepository
{
    Task<ICollection<House>> GetAsync(CancellationToken cancellationToken = default);

    Task<House> GetAsync(
        string houseName,
        CancellationToken cancellationToken = default);

    Task UpdateAsync(House house, CancellationToken cancellationToken = default);
}
