using Microsoft.AspNetCore.Mvc;

namespace Module6HW7.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
