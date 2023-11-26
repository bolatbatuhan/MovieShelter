using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Dtos.RequestDto;
using Service.Abstract;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MoviesController : BaseController
{
    private readonly IMovieService _movieService;

    public MoviesController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    [HttpPost]
    public IActionResult Add([FromBody]MovieAddRequest movieAddRequest)
    {
        var result = _movieService.Add(movieAddRequest);

        return ActionResultInstance(result);
    }
    [HttpPut]
    public IActionResult Update([FromBody]MovieUpdateRequest movieUpdateRequest)
    {
        var result = _movieService.Update(movieUpdateRequest);

        return ActionResultInstance(result);
    }

    [HttpDelete]
    public IActionResult Delete([FromQuery] Guid id)
    {
        var result = _movieService.Delete(id);
        return ActionResultInstance(result);
    }
    [HttpGet("getbyid")]
    public IActionResult GetById([FromQuery]Guid id)
    {
        var result = _movieService.GetById(id);

        return ActionResultInstance(result);
    }
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = _movieService.GetAll();
        return ActionResultInstance(result);
    }
}

