using Models.Entities;

namespace Models.Dtos.ResponseDto;

public  record MovieResponseDto(Guid Id, string Title, string Director, int ReleaseDate, int CategoryId, int PublisherId)
{
    public static implicit operator MovieResponseDto(Movie movie)
    {
        return new MovieResponseDto(Id:movie.Id, Title:movie.Title, Director:movie.Director, ReleaseDate:movie.ReleaseDate, CategoryId:movie.CategoryId, PublisherId:movie.PublisherId);
    }
}
