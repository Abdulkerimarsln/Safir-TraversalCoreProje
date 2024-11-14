using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;

namespace TraversalCoreProje.ViewComponents.Default
{
    public class _PopularDestinations : ViewComponent
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationalDal());
        public IViewComponentResult Invoke()
        {
            var values = destinationManager.TGetList();
            return View(values);
        }
    }
}
