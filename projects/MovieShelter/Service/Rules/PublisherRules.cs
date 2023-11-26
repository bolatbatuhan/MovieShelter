
using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Repositories.Abstracts;

namespace Service.Rules;

public class PublisherRules
{
    private readonly IPublisherRepository _publisherRepository;

    public PublisherRules(IPublisherRepository publisherRepository)
    {
        _publisherRepository = publisherRepository;
    }

    public void PublisherNameMustBeUnique(string publisherName)
    {
        var publisher = _publisherRepository.GetByFilter(x => x.Name == publisherName);

        if (publisher is not null)
        {
            throw new BusinessException($"Yayinci ismi {publisherName} benzersiz olmalidir.");
        }

    }

    public void PublisherIsPresent(int id)
    {
        var publisher = _publisherRepository.GetById(id);
        if(publisher is null)
        {
            throw new BusinessException($"Id {id} olan yayinci bulunamadi");
        }
    }

}
