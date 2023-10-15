using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Activity.Commands
{
    public class DeleteActivity
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _dbContext;
            public Handler(DataContext dbContext, Mapper mapper)
            {
                _dbContext = dbContext;
            }

            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _dbContext.Activities.FindAsync(request.Id);
                if (activity != null)
                {
                    _dbContext.Activities.Remove(activity);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}