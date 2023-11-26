using Models.Entities;

namespace Models.Dtos.RequestDto;

public record  MovieAddRequest(string Title, string Director, int ReleaseDate, int CategoryId,int PubliherId)
{
    
}



//public static Movie ConvertToEntity(MovieAddRequest request)
//{
//    return new Movie
//    {
//        Id = request.Id,
//        Title = request.Title,
//        Director = request.Director,
//        ReleaseDate = request.ReleaseDate,
//        CategoryId = request.CategoryId
//    };
//}