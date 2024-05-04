using Microsoft.AspNetCore.Mvc;

namespace Restify.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
