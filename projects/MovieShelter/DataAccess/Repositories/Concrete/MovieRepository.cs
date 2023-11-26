using Core.Persistence.Repositories;
using DataAccess.Context;
using DataAccess.Repositories.Abstracts;
using Models.Entities;


namespace DataAccess.Repositories.Concrete;

public class MovieRepository : EfRepositoryBase<BaseDbContext, Movie, Guid>, IMovieRepository
{
    public MovieRepository(BaseDbContext context) : base(context)
    {
    }
}
