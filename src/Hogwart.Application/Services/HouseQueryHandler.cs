using Hogwart.Application.Contracts;
using Hogwart.Application.DTO;
using Hogwart.Domain.Repositories;
using MediatR;

namespace Hogwart.Application.Services;

public class HouseQueryHandler : IRequestHandler<GetHouseQuery, HouseDto>
{
    private readonly IHouseRepository _houseRepository;

    public HouseQueryHandler(IHouseRepository houseRepository) =>
        _houseRepository = houseRepository;

    public async Task<HouseDto> Handle(
        GetHouseQuery query,
        CancellationToken cancellationToken)
    {
        var house = await _houseRepository.GetAsync(query.Name, cancellationToken);
        var studentDtoCollection = house
            .Students
            .Select(student => new StudentDto(student.FullName))
            .ToList();

        var houseDto = new HouseDto(house?.Name, studentDtoCollection);

        return houseDto;
    }
}