using Microsoft.AspNetCore.Mvc;
using MyWeather.Models;
using System.Diagnostics;

namespace MyWeather.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MasterContext _context;

        public HomeController(MasterContext context, 
        ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }
        // public HomeController(ILogger<HomeController> logger)
        // {
        //     _logger = logger;
        // }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(WeatherRecord wc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wc);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            else
                return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index2()
        {
            var weathers = _context.WeatherRecords.ToList();
            return View(weathers);
        }

        public IActionResult Update(int id)
        {
            var pc = _context.WeatherRecords.Where(a => a.RecordId == id).FirstOrDefault();
            return View(pc);
        }

        [HttpPost]
        public async Task<IActionResult> Update(WeatherRecord wc)
        {
            if (ModelState.IsValid)
            {
                _context.Update(wc);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            else
                return View(wc);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var pc = _context.WeatherRecords.Where(a => a.RecordId == id).FirstOrDefault();
            _context.Remove(pc);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}