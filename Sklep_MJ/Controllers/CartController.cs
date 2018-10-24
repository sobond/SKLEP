using Sklep_MJ.DAL;
using Sklep_MJ.Infrastructure;
using Sklep_MJ.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sklep_MJ.Controllers
{
    public class CartController : Controller
    {
        private CartManager cartManager;
        private ISessionManager sessionManager { get; set; }
        private CoursesContext db;

        public CartController()
        {
            db = new CoursesContext();
            sessionManager = new SessionManager();
            cartManager = new CartManager(sessionManager, db);
        }

        // GET: Chart
        public ActionResult Index()
        {
            var cartPositions = cartManager.GetCart();
            var totalPrice = cartManager.GetCartPrice();

            CartViewModel cartVM = new CartViewModel()
            {
                CartPositions = cartPositions,
                TotalPrice = totalPrice
            };

            return View(cartVM);
        }

        public ActionResult AddToCart(int id)
        {
            cartManager.AddToCart(id);
            return RedirectToAction("Index");
        }

        public int GetCartItemsCount()
        {
            return cartManager.GetCartItems();
        }

        public ActionResult RemoveFromCart(int id)
        {
            int removedCount = cartManager.RemoveFromCart(id);
            int cartCount = cartManager.GetCartItems();
            decimal price = cartManager.GetCartPrice();

            var result = new CartRemoveVM
            {
                CartFullPrice = price,
                CartItemsCount = cartCount,
                RemovedCount = removedCount,
                RemovedId = id
            };

            return Json(result);
        }

    }
}