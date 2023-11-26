using Core.Persistence.Repositories;
using DataAccess.Context;
using DataAccess.Repositories.Abstracts;
using Models.Entities;

namespace DataAccess.Repositories.Concrete;

public class PublisherRepository : EfRepositoryBase<BaseDbContext, Publisher, int>, IPublisherRepository
{
    public PublisherRepository(BaseDbContext context) : base(context)
    {
    }
}
