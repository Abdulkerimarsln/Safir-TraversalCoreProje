using DataAccesLayer.Concrete;
using DocumentFormat.OpenXml.Drawing.Charts;
using TraversalCoreProje.CQRS.Commands.DestinationCommands;

namespace TraversalCoreProje.CQRS.Handlers.DestinationHandlers
{
    public class UpdateDestinationCommandHandler
    {
       private readonly Context _context;

        public UpdateDestinationCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(UpdateDestinationCommand command)
        {
            var value = _context.Destinations.Find(command.DestionID);
            value.City = command.City;
            value.DayNight = command.DayNight;
            value.Price = command.Price;
            _context.SaveChanges();
        }

    }
}
