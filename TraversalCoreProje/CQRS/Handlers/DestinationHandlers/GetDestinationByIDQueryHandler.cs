using DataAccesLayer.Concrete;
using TraversalCoreProje.CQRS.Queries.DestinationQueries;
using TraversalCoreProje.CQRS.Results.DestinationResults;

namespace TraversalCoreProje.CQRS.Handlers.DestinationHandlers
{
    public class GetDestinationByIDQueryHandler
    {
        private readonly Context _context;

        public GetDestinationByIDQueryHandler(Context context)
        {
            _context = context;
        }
        public GetDestinationByIDResult Handle(GetDestinationByIDQuery query)
        {
            var values=_context.Destinations.Find(query.id);
            return new GetDestinationByIDResult{ 
                DestionID = values.DestinationID,
                DayNight = values.DayNight,
                City = values.City,
                Price = values.Price,
            };
        }

    }
}
