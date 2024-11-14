using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Controllers
{
    public class DestinationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationalDal());
        private readonly UserManager<AppUser> _userManager;

        public DestinationController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var values = destinationManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> DestinationsDetails(int id)
        {
            var values =  await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.UserID = values.Id;
            var value = destinationManager.TGetDestinationWithGuide(id);
            return View(value);
        }
        //[HttpPost]
        //public IActionResult DestinationsDetails(Destination p)
        //{
        //    return View(p);
        //}
    }
}
