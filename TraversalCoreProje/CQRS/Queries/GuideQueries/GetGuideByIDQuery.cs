using MediatR;
using TraversalCoreProje.CQRS.Results.GuideResults;

namespace TraversalCoreProje.CQRS.Queries.GuideQueries
{
    public class GetGuideByIDQuery:IRequest<GetGuideByIDQueryResult>
    {
        public int Id { get; set; }

        public GetGuideByIDQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
