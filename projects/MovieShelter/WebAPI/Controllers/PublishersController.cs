using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Dtos.RequestDto;
using Service.Abstract;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PublishersController : BaseController
{
    private readonly IPublisherService _publisherService;

    public PublishersController(IPublisherService publisherService)
    {
        _publisherService = publisherService;
    }

    [HttpPost]
    public IActionResult Add([FromBody]PublisherAddRequest publisherAddRequest)
    {
        var result = _publisherService.Add(publisherAddRequest);
        return ActionResultInstance(result);
    }
    [HttpPut]
    public IActionResult Update(PublisherUpdateRequest publisherUpdateRequest)
    {
        var result = _publisherService.Update(publisherUpdateRequest);
        return ActionResultInstance(result);
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        var result = _publisherService.Delete(id);
        return ActionResultInstance(result);
    }

    [HttpGet("getbyid")]
    public IActionResult GetById(int id)
    {
        var result = _publisherService.GetById(id);
        return ActionResultInstance(result);
    }

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = _publisherService.GetAll();
        return ActionResultInstance(result);
    }
}
