using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class Test : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
