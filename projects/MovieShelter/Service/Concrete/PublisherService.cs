
using Azure.Core;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Shared;
using DataAccess.Repositories.Abstracts;
using Models.Dtos.RequestDto;
using Models.Dtos.ResponseDto;
using Models.Entities;
using Service.Abstract;
using Service.Rules;

namespace Service.Concrete;

public class PublisherService : IPublisherService
{
    private readonly IPublisherRepository _publisherRepository;
    private readonly PublisherRules _publisherRules;

    public PublisherService(IPublisherRepository publisherRepository, PublisherRules publisherRules)
    {
        _publisherRepository = publisherRepository;
        _publisherRules = publisherRules;
    }

    public Response<PublisherResponseDto> Add(PublisherAddRequest publisherAddRequest)
    {
        try
        {
            Publisher publisher = publisherAddRequest;
            _publisherRules.PublisherNameMustBeUnique(publisher.Name);
            _publisherRepository.Add(publisher);

            PublisherResponseDto response = publisher;

            return new Response<PublisherResponseDto>
            {
                Data = response,
                Message = "Yayinci eklendi",
                StatusCode = System.Net.HttpStatusCode.Created
            };
        }
        catch (BusinessException ex)
        {
            return new Response<PublisherResponseDto>
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }


    }

    public Response<PublisherResponseDto> Delete(int id)
    {
        try
        {
            _publisherRules.PublisherIsPresent(id);
            Publisher publisher = _publisherRepository.GetById(id);
            _publisherRepository.Delete(publisher);

            PublisherResponseDto response = publisher;
            return new Response<PublisherResponseDto>
            {
                Data = response,
                Message = "Yayinci silindi",
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (BusinessException ex)
        {
            return new Response<PublisherResponseDto>
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }

    }

    public Response<List<PublisherResponseDto>> GetAll()
    {
        List<Publisher> publishers = _publisherRepository.GetAll();
        List<PublisherResponseDto> response = publishers.Select(x => (PublisherResponseDto)x).ToList();

        return new Response<List<PublisherResponseDto>>()
        {
            Data = response,
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public Response<PublisherResponseDto> GetById(int id)
    {
        try
        {
            _publisherRules.PublisherIsPresent(id);
            Publisher publisher = _publisherRepository.GetById(id);
            PublisherResponseDto response = publisher;

            return new Response<PublisherResponseDto>
            {
                Data = response,
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (BusinessException ex)
        {
            return new Response<PublisherResponseDto>
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }

    }

    public Response<PublisherResponseDto> Update(PublisherUpdateRequest publisherUpdateRequest)
    {
        try
        {
            Publisher publisher = publisherUpdateRequest;
            _publisherRules.PublisherNameMustBeUnique(publisher.Name);
            _publisherRepository.Update(publisher);

            PublisherResponseDto publisherResponseDto = publisher;

            return new Response<PublisherResponseDto>
            {
                Data = publisherResponseDto,
                Message = "Yayinci guncellendi",
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (BusinessException ex)
        {
            return new Response<PublisherResponseDto>
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }

    }
}
