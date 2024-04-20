using Microsoft.AspNetCore.Mvc;

namespace Ejercicio_1.Controllers
{
    public class ContactoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
