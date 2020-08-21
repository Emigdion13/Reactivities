using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Edit
    {
        public class Command : IRequest 
        {
            public Guid Id {get; set;}
            public string Title {get; set;}
            public string Description {get; set;}
            public string Category {get; set;}
            public DateTime? Date {get; set;}
            public string City {get; set;}
            public string Venue {get; set;}
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

                var LeActivity = await _context.Activities.FindAsync(request.Id);

                if (LeActivity == null) 
                    throw new Exception("Could not find activity");

                LeActivity.Title = request.Title ?? LeActivity.Title;
                LeActivity.Description = request.Description ?? LeActivity.Description;
                LeActivity.Category = request.Category ?? LeActivity.Category;
                LeActivity.Date = request.Date ?? LeActivity.Date;
                LeActivity.City = request.City ?? LeActivity.City;
                LeActivity.Venue = request.Venue ?? LeActivity.Venue;

                var LeSaveResult =  await _context.SaveChangesAsync() > 0;

                if (LeSaveResult) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}