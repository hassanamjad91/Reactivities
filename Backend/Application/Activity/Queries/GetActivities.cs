using Microsoft.EntityFrameworkCore;
using MediatR;
using Persistence;
using ActivityEntity = Domain.Activity;

namespace Application.Activity.Queries
{
    public class GetActivities
    {
        public class Query : IRequest<List<ActivityEntity>> { }
        public class Handler : IRequestHandler<Query, List<ActivityEntity>>
        {
            private readonly DataContext _dbContext;
            public Handler(DataContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<List<ActivityEntity>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _dbContext.Activities.ToListAsync();
            }
        }
    }
}