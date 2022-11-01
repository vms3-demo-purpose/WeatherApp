using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWeather.Models;

namespace MyWeather.Controllers
{
    public class WeatherController : Controller
    {
        private readonly MasterContext _context;

        public WeatherController(MasterContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var weathers = await _context.WeatherRecords.ToListAsync();
            return View(weathers);
        }
    }
}
