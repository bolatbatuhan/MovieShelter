using Core.Shared;
using Models.Dtos.RequestDto;
using Models.Dtos.ResponseDto;

namespace Service.Abstract;

public interface IMovieService
{
    Response<MovieResponseDto> Add(MovieAddRequest request);
    Response<MovieResponseDto> Update(MovieUpdateRequest request);
    Response<MovieResponseDto> Delete(Guid id);

    Response<MovieResponseDto> GetById(Guid id);
    Response<List<MovieResponseDto>> GetAll();



    
}
