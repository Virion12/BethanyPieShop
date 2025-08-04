using Microsoft.AspNetCore.Mvc;

namespace BethanyPieShop.Controlers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
