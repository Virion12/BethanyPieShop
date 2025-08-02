using BethanyPieShop.Models;
using BethanyPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanyPieShop.Controlers
{
    public class ShoppingCartController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly IShoppingCart _shoppingCart;

        public ShoppingCartController(IPieRepository pieRepository, IShoppingCart shoppingCart)
        {
            _pieRepository = pieRepository;
            _shoppingCart = shoppingCart;
        }

        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel(_shoppingCart, _shoppingCart.GetShoppingCartTotal());

            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int pieId)
        {
            var selectedPies = _pieRepository.AllPies.FirstOrDefault(p => p.PieId == pieId);
            if (selectedPies != null)
            {
                _shoppingCart.AddToCart(selectedPies);
            }
            return RedirectToAction("Index");

        }

        public RedirectToActionResult RemoveFromShoppingCart(int pieId)
        {
            var selectedPies = _pieRepository.AllPies.FirstOrDefault(p => p.PieId == pieId);
            if (selectedPies != null)
            {
                _shoppingCart.RemoveFromCart(selectedPies);
            }
            return RedirectToAction("Index");

        }
    }
}
