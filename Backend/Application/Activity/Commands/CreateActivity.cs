using MediatR;
using Persistence;
using ActivityEntity = Domain.Activity;

namespace Application.Activity.Commands
{
    public class CreateActivity
    {
        public class Command : IRequest
        {
            public ActivityEntity Activity { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _dbContext;
            public Handler(DataContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                _dbContext.Activities.Add(request.Activity);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}