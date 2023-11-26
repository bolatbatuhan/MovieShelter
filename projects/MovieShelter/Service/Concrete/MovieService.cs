using Core.CrossCuttingConcerns.Exceptions;
using Core.Shared;
using DataAccess.Repositories.Abstracts;
using Models.Dtos.RequestDto;
using Models.Dtos.ResponseDto;
using Models.Entities;
using Service.Abstract;
using Service.Rules;


namespace Service.Concrete;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _movieRepository;
    private readonly MovieRules _rules;

    public MovieService(IMovieRepository movieRepository, MovieRules rules)
    {
        _movieRepository = movieRepository;
        _rules = rules;
    }

    public Response<MovieResponseDto> Add(MovieAddRequest request)
    {

        try
        {
            Movie movie = request;
            _rules.MovieNameMustBeUnique(movie.Title);

            movie.Id = new Guid();
            _movieRepository.Add(movie);

            MovieResponseDto response = movie;

            return new Response<MovieResponseDto>
            {
                Data = response,
                Message = "Film Eklendi",
                StatusCode = System.Net.HttpStatusCode.Created
            };
        }
        catch (BusinessException ex)
        {
            return new Response<MovieResponseDto>()
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }


    }

    public Response<MovieResponseDto> Delete(Guid id)
    {
        try
        {
            _rules.MovieIsPresent(id);

            Movie movie = _movieRepository.GetById(id);
            _movieRepository.Delete(movie);

            MovieResponseDto movieResponseDto = movie;

            return new Response<MovieResponseDto>
            {
                Data = movie,
                Message = "Film silindi",
                StatusCode = System.Net.HttpStatusCode.OK

            };
        }
        catch (BusinessException ex)
        {
            return new Response<MovieResponseDto>
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }



    }

    public Response<List<MovieResponseDto>> GetAll()
    {
        List<Movie> movies = _movieRepository.GetAll();
        List<MovieResponseDto> response = movies.Select(x => (MovieResponseDto)x).ToList();
        return new Response<List<MovieResponseDto>>()
        {
            Data = response,
            StatusCode = System.Net.HttpStatusCode.OK

        };
    }

    public Response<MovieResponseDto> GetById(Guid id)
    {
        try
        {
            _rules.MovieIsPresent(id);
            Movie movie = _movieRepository.GetById(id);

            MovieResponseDto response = movie;

            return new Response<MovieResponseDto>
            {
                Data = response,
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (BusinessException ex)
        {
            return new Response<MovieResponseDto>
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }

    }

    public Response<MovieResponseDto> Update(MovieUpdateRequest request)
    {
        try
        {
            Movie movie = request;
            _rules.MovieNameMustBeUnique(movie.Title);

            _movieRepository.Update(movie);

            MovieResponseDto movieResponseDto = movie;

            return new Response<MovieResponseDto>
            {
                Data = movie,
                Message = "Film Guncellendi",
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (BusinessException ex)
        {
            return new Response<MovieResponseDto>
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }


    }
}
