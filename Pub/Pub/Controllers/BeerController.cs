using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pub.Models;

namespace Pub.Controllers
{
    public class BeerController : Controller
    {
        private readonly PubContext _pubContext;

        public BeerController(PubContext pubContext)
        {
            _pubContext = pubContext;
        }

        public async Task<IActionResult> Index()
        {
            var beers = _pubContext.Beers.Include(b => b.Brand);
            return View(await beers.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewData["brands"] = new SelectList(_pubContext.Brands, "BrandId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create()
        {
            ViewData["brands"] = new SelectList(_pubContext.Brands, "BrandId", "Name");
            return View();
        }
    }
}
