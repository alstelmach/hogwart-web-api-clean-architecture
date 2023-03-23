using Hogwart.Domain.Aggregates.House;
using Hogwart.Domain.Aggregates.House.Entities;

namespace Hogwart.Domain.Services;

public interface ISortingDomainService
{
    Task<House> DetermineHouseAsync(
        Student student,
        CancellationToken cancellationToken = default);
}
