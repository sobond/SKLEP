﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Sklep_MJ.DAL;
using Sklep_MJ.Infrastructure;
using Sklep_MJ.Models;
using Sklep_MJ.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
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

        public async Task<ActionResult> Pay()
        {
            if (Request.IsAuthenticated)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

                var order = new Order()
                {
                    FirstName = user.UserData.FirstName,
                    SecondName = user.UserData.SecondName,
                    Address = user.UserData.Address,
                    City = user.UserData.City,
                    PostCode = user.UserData.PostCode,
                    Email = user.UserData.Email,
                    Phone = user.UserData.Phone
                };

                return View(order);
            }
            return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("Pay", "Cart") });
        }

        [HttpPost]
        public async Task<ActionResult> Pay (Order orderDetails)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();

                var newOrder = cartManager.CreateOrder(orderDetails, userId);

                var user = await UserManager.FindByIdAsync(userId);
                TryUpdateModel(user.UserData);
                await UserManager.UpdateAsync(user);

                cartManager.EmptyCart();

                return RedirectToAction("ConfirmOrder");
            }
            else
            {
                return View(orderDetails);
            }
        }

        public ActionResult ConfirmOrder()
        {
            return View();
        }


    }
}