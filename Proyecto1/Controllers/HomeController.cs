using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using Proyecto1.Models;
using Proyecto1.Models.ViewModels;
using Proyecto1.Extensions;
using System.Text.Json;

namespace Proyecto1.Controllers
{
    public class HomeController : Controller
    {
        private readonly FUENTESODAContext _context;

        public HomeController(FUENTESODAContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var fUENTESODAContext = _context.Producto.Include(p => p.IdeCatNavigation);
            return View(await fUENTESODAContext.ToListAsync());
        }

        [HttpPost]
        public IActionResult Index(HomeViewModel homeViewModel)
        {
            var homeViewModelList = HttpContext.Session.Get<List<HomeViewModel>>("HomeViewModelList");
            
            if (homeViewModelList == null)
            {
                homeViewModelList = new List<HomeViewModel>();
            }

            homeViewModelList.Add(homeViewModel);
            HttpContext.Session.Set("HomeViewModelList", homeViewModelList);

            return RedirectToAction("Index");
        }
    }
}
