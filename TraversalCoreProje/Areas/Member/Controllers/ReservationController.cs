using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TraversalCoreProje.Areas.Member.Controllers
{
   [Area("Member")]
    [Route("Member/[controller]/[action]")]

    public class ReservationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationalDal());
        ReservationManager reservationManager = new ReservationManager(new EfReservationDal());
        private readonly UserManager<AppUser> _userManager;

        public ReservationController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> MyCurrentReservation() 
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var valuesList = reservationManager.GetListApprovalReservationByAccepted(values.Id);
            return View(valuesList);
        }
        [HttpGet]
        public async Task<IActionResult> MyOldReservation()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var valuesList = reservationManager.GetListApprovalReservationByPrevious(values.Id);
            return View(valuesList);
        }

        [HttpGet]
        public IActionResult NewReservation()
        {
            List<SelectListItem> values = (from x in destinationManager.TGetList()
                                           select new SelectListItem {
                                           Text=x.City,
                                           Value=x.DestinationID.ToString()
                                           }).ToList();
            ViewBag.v=values;
            return View();
        }
        [HttpPost]
        public IActionResult NewReservation(Rezervation p)
        {
            p.AppUserId = 2;
            p.DestinationID = 4;
            p.Status = "Onay Bekliyor";
            reservationManager.TAdd(p);
            return RedirectToAction("MyCurrentReservation");
        }
        public async Task<IActionResult> MyApprovalReservation() 
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
           var valuesList= reservationManager.GetListApprovalReservationByWaitAproval(values.Id);
            return View(valuesList); 
        }

        public IActionResult Deneme()
        {
            return View(); 
        }
    }
}
