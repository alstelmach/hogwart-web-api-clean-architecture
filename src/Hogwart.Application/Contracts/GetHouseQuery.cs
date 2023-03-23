using Hogwart.Application.DTO;
using MediatR;

namespace Hogwart.Application.Contracts;

public sealed record GetHouseQuery(string Name) : IRequest<HouseDto>;