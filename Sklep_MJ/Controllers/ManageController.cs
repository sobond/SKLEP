using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Sklep_MJ.DAL;
using Sklep_MJ.Infrastructure;
using Sklep_MJ.Models;
using Sklep_MJ.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Sklep_MJ.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {

        private CoursesContext db = new CoursesContext();

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            Error
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

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        // GET: Manage
        public async Task<ActionResult> Index(ManageMessageId? message)
        {
            if (TempData["ViewData"] != null)
            {
                ViewData = (ViewDataDictionary)TempData["ViewData"];
            }

            if (User.IsInRole("Admin"))
                ViewBag.UserIsAdmin = true;
            else
                ViewBag.UserIsAdmin = false;

            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user == null)
            {
                return View("Error");
            }
            var model = new ManageCredentialsViewModel
            {
                Message = message,
                UserData = user.UserData
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangeProfile([Bind(Prefix = "UserData")]UserData userData)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                user.UserData = userData;
                var result = await UserManager.UpdateAsync(user);

                AddErrors(result);
            }
            if (!ModelState.IsValid)
            {
                TempData["ViewData"] = ViewData;
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword([Bind(Prefix = "ChangePasswordViewModel")]ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["ViewData"] = ViewData;
                return RedirectToAction("Index");
            }

            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInAsync(user, isPersistent: false);
                }
                return RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
            }

            var message = ManageMessageId.ChangePasswordSuccess;
            return RedirectToAction("Index", new { Message = message });
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("password-error", error);
            }
        }

        private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie, DefaultAuthenticationTypes.TwoFactorCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = isPersistent }, await user.GenerateUserIdentityAsync(UserManager));
        }

        public ActionResult OrderList()
        {
            bool isAdmin = User.IsInRole("Admin");
            ViewBag.UserIsAdmin = isAdmin;

            IEnumerable<Order> userOrders;

            if (isAdmin)
            {
                userOrders = db.Orders.Include("OrderPositions").OrderByDescending(o => o.OrderDate).ToArray();
            }
            else
            {
                var userId = User.Identity.GetUserId();
                userOrders = db.Orders.Where(o => o.UserId == userId).Include("OrderPositions").OrderByDescending(o => o.OrderDate).ToArray();
            }

            return View(userOrders);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public OrderStatus ChangeOrderStatus(Order order)
        {
            Order orderToModify = db.Orders.Find(order.OrderId);
            orderToModify.OrderStatus = order.OrderStatus;
            db.SaveChanges();

            return order.OrderStatus;

        }

        [Authorize(Roles = "Admin")]
        public ActionResult AddCourse(int? id, bool? confirmation)
        {
            Course course;
            if (id.HasValue)
            {
                ViewBag.EditMode = true;
                course = db.Courses.Find(id);
            }
            else
            {
                ViewBag.EditMode = false;
                course = new Course();
            }

            var result = new EditCourseViewModel();
            result.Categories = db.Categories.ToList();
            result.Course = course;
            result.Confirmation = confirmation;

            return View(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult AddCourse(EditCourseViewModel model, HttpPostedFileBase file)
        {
            if (model.Course.CourseId > 0)
            {
                //modyfikacja kursu
                db.Entry(model.Course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("AddCourse", new { confirmation = true });
            }
            else
            {

                if (file != null && file.ContentLength > 0)
                {
                    if (ModelState.IsValid)
                    {
                        //generowanie pliku
                        var fileExt = Path.GetExtension(file.FileName);
                        var fileName = Guid.NewGuid() + fileExt;

                        var path = Path.Combine(Server.MapPath(AppConfig.CoursesIconsFolder), fileName);
                        file.SaveAs(path);

                        model.Course.FileIcon = fileName;
                        model.Course.DateAdd = DateTime.Now;

                        db.Entry(model.Course).State = EntityState.Added;
                        db.SaveChanges();

                        return RedirectToAction("AddCourse", new { confirmation = true });
                    }
                    else
                    {
                        var categories = db.Categories.ToList();
                        model.Categories = categories;

                        return View(model);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Brak pliku");
                    var categories = db.Categories.ToList();
                    model.Categories = categories;

                    return View(model);
                }
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult HideCourse(int id)
        {
            var course = db.Courses.Find(id);
            course.Hidden = true;
            db.SaveChanges();

            return RedirectToAction("AddCourse", new { confirmation = true });
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ShowCourse(int id)
        {
            var course = db.Courses.Find(id);
            course.Hidden = false;
            db.SaveChanges();

            return RedirectToAction("AddCourse", new { confirmation = true });
        }
    }
}