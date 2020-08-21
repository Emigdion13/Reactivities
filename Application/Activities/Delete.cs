using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Delete
    {
        public class Command : IRequest 
        {
            public Guid Id {get; set;}
        }
        
        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {

                var LeActivityToDelete = await _context.Activities.FindAsync(request.Id);

                if (LeActivityToDelete == null) throw new Exception("Failed to find Activity");
                
                _context.Activities.Remove(LeActivityToDelete);

                var LeSaveResult =  await _context.SaveChangesAsync() > 0;

                if (LeSaveResult) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}