using Microsoft.AspNetCore.Mvc;

namespace ProyectoWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

