using Microsoft.AspNetCore.Mvc;

namespace Pub.Controllers
{
    public class BrandController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
