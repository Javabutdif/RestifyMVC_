using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcLandlord.Data;
using Restify.Models;
using System.Diagnostics;

namespace Restify.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MvcLandlordContext _context;


        public HomeController(ILogger<HomeController> logger, MvcLandlordContext context)
        {
            _logger = logger;
            _context = context;
        }
       
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> LoginSubmit(string? email, string? pass)
        {
            var landlord = await _context.Landlord
                .FirstOrDefaultAsync(m => m.landlord_email == email && m.landlord_password == pass);
            if (landlord == null)
            {
                return NotFound();
            }
            else
            {
                return RedirectToAction("Dashboard", "User");
            }

            
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
