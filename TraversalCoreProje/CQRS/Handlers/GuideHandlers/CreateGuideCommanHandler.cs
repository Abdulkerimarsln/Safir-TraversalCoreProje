using DataAccesLayer.Concrete;
using MediatR;
using NuGet.Protocol.Plugins;
using TraversalCoreProje.CQRS.Commands.GuideCommands;

namespace TraversalCoreProje.CQRS.Handlers.GuideHandlers
{
    public class CreateGuideCommanHandler : IRequestHandler<CreateGuideCommand>
    {
        private readonly Context _context;

        public CreateGuideCommanHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateGuideCommand request, CancellationToken cancellationToken)
        {
            _context.Guides.Add(new EntityLayer.Concrete.Guide
            {
                Name = request.Name,
                Description = request.Description,
                Status = true,
            });
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
