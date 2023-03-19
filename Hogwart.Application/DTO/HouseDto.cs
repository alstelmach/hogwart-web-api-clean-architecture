namespace Hogwart.Application.DTO;

public sealed record HouseDto(
    string Name,
    ICollection<StudentDto> Students);