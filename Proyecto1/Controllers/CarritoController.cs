using Microsoft.AspNetCore.Mvc;
using Proyecto1.Extensions;
using Proyecto1.Models.ViewModels;

namespace Proyecto1.Controllers
{
    public class CarritoController : Controller
    {
        public IActionResult Index()
        {
            var homeViewModelList = HttpContext.Session.Get<List<HomeViewModel>>("HomeViewModelList");

            if (homeViewModelList == null)
            {
                homeViewModelList = new List<HomeViewModel>();
            }

            return View(homeViewModelList);
        }
    }
}
