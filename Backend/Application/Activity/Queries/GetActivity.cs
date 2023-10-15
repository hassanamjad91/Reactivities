using MediatR;
using Persistence;
using ActivityEntity = Domain.Activity;

namespace Application.Activity.Queries
{
    public class GetActivity
    {
        public class Query : IRequest<ActivityEntity>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, ActivityEntity>
        {
            private readonly DataContext _dbContext;
            public Handler(DataContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ActivityEntity> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _dbContext.Activities.FindAsync(request.Id);
            }
        }
    }
}