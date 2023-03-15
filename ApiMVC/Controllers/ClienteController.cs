using Microsoft.AspNetCore.Mvc;

namespace ApiMVC.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
