using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VapeShop.Models;
using VapeShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VapeShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IVapeRepository _vapeRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IVapeRepository vapeRepository, ShoppingCart shoppingCart)
        {
            _vapeRepository = vapeRepository;
            _shoppingCart = shoppingCart;
        }

        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int vapeId)
        {
            var selectedVape = _vapeRepository.AllVapes.FirstOrDefault(p => p.VapeId == vapeId);

            if (selectedVape != null)
            {
                _shoppingCart.AddToCart(selectedVape, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int vapeId)
        {
            var selectedVape = _vapeRepository.AllVapes.FirstOrDefault(p => p.VapeId == vapeId);

            if (selectedVape != null)
            {
                _shoppingCart.RemoveFromCart(selectedVape);
            }
            return RedirectToAction("Index");
        }
    }
}
