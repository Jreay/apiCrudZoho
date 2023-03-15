using Microsoft.AspNetCore.Mvc;

namespace ApiMVC.Controllers
{
    public class ContactoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
