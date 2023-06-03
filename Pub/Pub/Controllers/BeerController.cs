using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pub.Models;
using Pub.Models.ViewModels;

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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BeerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var beer = new Beer()
                {
                    Name = model.Name,
                    BrandId = model.BrandId
                };
                _pubContext.Add(beer);
                await _pubContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["brands"] = new SelectList(_pubContext.Brands, "BrandId", "Name", model.BrandId);
            return View(model);
        }
    }
}
