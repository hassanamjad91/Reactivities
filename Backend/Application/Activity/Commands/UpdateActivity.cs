using AutoMapper;
using MediatR;
using Persistence;
using ActivityEntity = Domain.Activity;

namespace Application.Activity.Commands
{
    public class UpdateActivity
    {
        public class Command : IRequest
        {
            public ActivityEntity Activity { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _dbContext;
            private readonly Mapper _mapper;
            public Handler(DataContext dbContext, Mapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _dbContext.Activities.FindAsync(request.Activity.Id);
                _mapper.Map(request.Activity, activity);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}