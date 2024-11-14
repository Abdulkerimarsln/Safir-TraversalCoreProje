using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TraversalCoreProje.Areas.Admin.Models;
using System.Net.Http.Headers;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    public class ApiExchangeController : Controller
    {
        [Area("Admin")]
        public async Task<IActionResult> Index()
        {
            List<BookingExchangeViewModel2> bookingExchangeViewModel2s = new List<BookingExchangeViewModel2>();
            var client = new HttpClient();
            string Kur = "AED";
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?locale=en-gb&currency={Kur}"),
                Headers =
                {
                    { "x-rapidapi-key", "e1b8b3e43fmsh52e8a34a9d149b8p18190djsn47f3460da202" },
                    { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<BookingExchangeViewModel2>(body);
                return View(values.exchange_rates);
            }
        }
    }
}
