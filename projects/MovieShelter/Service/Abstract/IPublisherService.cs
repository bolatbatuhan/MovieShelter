
using Core.Shared;
using Models.Dtos.RequestDto;
using Models.Dtos.ResponseDto;

namespace Service.Abstract;

public interface IPublisherService
{
    Response<PublisherResponseDto> Add(PublisherAddRequest publisherAddRequest);
    Response<PublisherResponseDto> Update(PublisherUpdateRequest publisherUpdateRequest);

    Response<PublisherResponseDto> Delete(int id);
    Response<PublisherResponseDto> GetById(int id);
    Response<List<PublisherResponseDto>> GetAll();
}
