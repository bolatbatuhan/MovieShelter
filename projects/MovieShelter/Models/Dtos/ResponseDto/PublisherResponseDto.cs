using Models.Entities;

namespace Models.Dtos.ResponseDto;

public record PublisherResponseDto(int Id, string Name)
{
    public static implicit operator PublisherResponseDto(Publisher publisher)
    {
        return new PublisherResponseDto(Id : publisher.Id, Name: publisher.Name);
    }
}
