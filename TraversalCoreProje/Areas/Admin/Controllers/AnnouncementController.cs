using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DTOs.AnnouncementDTO;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProje.Areas.Admin.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IMapper _mapper;

        public AnnouncementController(IAnnouncementService announcementService, IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var values = _mapper.Map<List<AnnouncementListDTO>>(_announcementService.TGetList());
            return View(values);
        }

        [HttpGet]
        public IActionResult AddAnnouncement()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAnnouncement(AnnouncementAddDTO announcement)
        {
            if(ModelState.IsValid)
            {
                _announcementService.TAdd(new Announcement()
                {
                    Content= announcement.Content,
                    Title=announcement.Title,
                    Date=Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });
                return RedirectToAction("Index");
            }
            return View(announcement);
        }
        public IActionResult DeleteAnnouncement(int id)
        {
            var values= _announcementService.TGetByID(id);
            _announcementService.TDelete(values);
            return RedirectToAction("Index"); 
        }

        [HttpGet]
        public IActionResult UpdateAnnouncement(int id)
        {
            var values = _mapper.Map<AnnouncementUpdateDTO>(_announcementService.TGetByID(id));
            return View(values); 
        }
        [HttpPost]
        public IActionResult UpdateAnnouncement(AnnouncementUpdateDTO announcementUpdateDTO)
        {
            if (ModelState.IsValid) 
            {
                _announcementService.TUpdate(new Announcement
                {
                    AnnouncementID=announcementUpdateDTO.AnnouncementID,
                    Title=announcementUpdateDTO.Title,
                    Content=announcementUpdateDTO.Content,
                    Date=Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });

                return RedirectToAction("Index");

            }

            return View(announcementUpdateDTO);
        }
    }
}
