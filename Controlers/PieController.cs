using BethanyPieShop.Models;
using BethanyPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanyPieShop.Controlers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _PieRepository;
        private readonly ICategoryRepository _CategoryRepository;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
            {
                _PieRepository = pieRepository;
                _CategoryRepository = categoryRepository;
        }

        public IActionResult List()
        {
            //ViewBag.CurrentCategory = "Chees Cake";
            //return View(_PieRepository.AllPies);
            PieListViewModel pieListViewModel = new PieListViewModel(_PieRepository.AllPies, "Chees cakes");
            return View(pieListViewModel);
        }


    }
}
