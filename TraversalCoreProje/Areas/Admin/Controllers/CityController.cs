using BusinessLayer.Abstract;
using DocumentFormat.OpenXml.Wordprocessing;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TraversalCoreProje.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CityController : Controller
    {
        private readonly IDestinationService _destinationService;

        public CityController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CityList()
        {
            var jsonCity = JsonConvert.SerializeObject(_destinationService.TGetList());
            return Json(jsonCity);
        }
        [HttpPost]
        public IActionResult AddCityDestination(EntityLayer.Concrete.Destination destination) 
        {
            _destinationService.TAdd(destination);
            var values=JsonConvert.SerializeObject(destination);
            return Json(values); 
        }
        public IActionResult GetById(int DestinationID)
        {
            var values = _destinationService.TGetByID(DestinationID);
            var jsonValues=JsonConvert.SerializeObject(values);
            return Json(jsonValues);
        } 
        
        public IActionResult DeleteCity(int id)
        {
            var getbyid=  _destinationService.TGetByID(id);
            _destinationService.TDelete(getbyid);
            
            return NoContent();
        }



        public IActionResult UpdateCity(EntityLayer.Concrete.Destination destination)
        {
            _destinationService.TUpdate(destination); 
            var jsonConvert= JsonConvert.SerializeObject(destination);
            return Json(jsonConvert); 
        }


        
        
        
        
        //public static List<CityClass> cities = new List<CityClass>()
        //{
        //    new CityClass
        //    {
        //        CityID = 1,
        //        CityName="Üsküp",
        //        CityCountry="Makedonya"
        //    },
        //    new CityClass
        //    {
        //        CityID=2,
        //        CityName="Roma",
        //        CityCountry="İtalya"
        //    },
        //    new CityClass
        //    {
        //        CityID=3,
        //        CityName="Londra",
        //        CityCountry="İngiltere"
        //    }
        //};   
    }
}
