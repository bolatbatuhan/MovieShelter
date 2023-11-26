using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Rules;

public class MovieRules
{
    private readonly IMovieRepository _movieRepository;

    public MovieRules(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public void MovieNameMustBeUnique(string movieName)
    {
        var movie = _movieRepository.GetByFilter(x=>x.Title==movieName);

        if(movie is not null)
        {
            throw new BusinessException("Film ismi benzersiz olmalidir.");
        }
    }

    public void MovieIsPresent(Guid id)
    {
        var movie = _movieRepository.GetById(id);

        if(movie is  null)
        {
            throw new BusinessException($"Id {id} olan film bulunamadi");
        }
    }
}
