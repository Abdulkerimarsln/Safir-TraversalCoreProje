using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactUsController : Controller
    {
        private readonly IContactUsService _contactService;

        public ContactUsController(IContactUsService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            var values=_contactService.TGetListContactUsByTrue();
            return View(values);
        }
    }
}
