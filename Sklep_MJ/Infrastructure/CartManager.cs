using Sklep_MJ.DAL;
using Sklep_MJ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sklep_MJ.Infrastructure
{
    public class CartManager
    {
        private CoursesContext db;
        private ISessionManager session;

        public CartManager(ISessionManager session, CoursesContext db)
        {
            this.session = session;
            this.db = db;
        }

        public List<CartPosition> GetCart()
        {
            List<CartPosition> cart;

            if (session.Get<List<CartPosition>>(Const.CartSessionKey) == null)
            {
                cart = new List<CartPosition>();
            }
            else
            {
                cart = session.Get<List<CartPosition>>(Const.CartSessionKey) as List<CartPosition>;
            }
            return cart;
        }

        public void AddToCart(int courseId)
        {
            var cart = GetCart();
            var cartPosition = cart.Find(c => c.Course.CourseId == courseId);
            if (cartPosition != null)
            {
                cartPosition.Count++;
            }
            else
            {
                var courseToAdd = db.Courses.Where(c => c.CourseId == courseId).SingleOrDefault();

                if (courseToAdd != null)
                {
                    var newCartPosition = new CartPosition()
                    {
                        Course = courseToAdd,
                        Count = 1,
                        Price = courseToAdd.Price
                    };
                    cart.Add(newCartPosition);
                }
            }
            session.Set(Const.CartSessionKey, cart);
        }

        public int RemoveFromCart(int courseId)
        {
            var cart = GetCart();
            var cartPosition = cart.Find(c => c.Course.CourseId == courseId);

            if (cartPosition != null)
            {
                if (cartPosition.Count > 1)
                {
                    cartPosition.Count--;
                    return cartPosition.Count;
                }
                else
                {
                    cart.Remove(cartPosition);
                }
            }
            return 0;
        }

        public decimal GetCartPrice()
        {
            var cart = GetCart();
            return cart.Sum(c => (c.Count * c.Course.Price));
        }

        public int GetCartItems()
        {
            var cart = GetCart();
            int count = cart.Sum(c => c.Count);
            return count;
        }

        public Order CreateOrder(Order newOrder, string userId)
        {
            var cart = GetCart();
            newOrder.OrderDate = DateTime.Now;
            newOrder.UserId = userId;

            db.Orders.Add(newOrder);

            if (newOrder.OrderPositions == null)
                newOrder.OrderPositions = new List<OrderPosition>();
            decimal cartPrice = 0;

            foreach(var element in cart)
            {
                var newOrderPosition = new OrderPosition()
                {
                    CourseId = element.Course.CourseId,
                    Count = element.Count,
                    Price = element.Course.Price
                };
                cartPrice += (element.Count * element.Course.Price);
                newOrder.OrderPositions.Add(newOrderPosition);

            }

            newOrder.Price = cartPrice;
            db.SaveChanges();

            return newOrder;
        }

        public void EmptyCart()
        {
            session.Set<List<CartPosition>>(Const.CartSessionKey, null);
        }
    }
}