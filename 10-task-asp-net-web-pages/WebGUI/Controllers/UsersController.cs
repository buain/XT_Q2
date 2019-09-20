using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGUI.Models;
using System.Web.UI;

namespace WebGUI.Controllers
{
    public class UsersController : Controller
    {
        //GET: /Users/
        // watch all users
        [AllowAnonymous]
        public ActionResult Index()
        {
            var model = Models.Users.GetAllUsers();
            return View(model);
        }
        
        [Authorize(Roles ="User, Admin")]
        public ActionResult Details(Guid Id)
        {
            var model = Models.Users.GetUser(Id);
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(Models.Users model)
        {
            if (ModelState.IsValid)
            {
                Models.Users.CreateUser(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
        public JsonResult CheckUserName(string Name)
        {
            var result = Models.Users.CheckUserName(Name);

            if (result)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("User with this name already exists.", JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(Guid id)
        {
            var model = Models.Users.GetUser(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(Models.Users model)
        {
            try
            {
                Models.Users.DeleteUser(model.Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        [Authorize(Roles = "User, Admin")]
        public ActionResult UserAwards(Guid id)
        {
            var model = Models.Users.GetUser(id);
            return View(model);
        }

        //[ChildActionOnly]
        [Authorize(Roles = "User, Admin")]
        public ActionResult GetUserAwards(Guid id)
        {
            var model = Models.Users.GetUserAwards(id);
            return PartialView(model);
        }

        [Authorize(Roles = "User, Admin")]
        public ActionResult GetUserAwardsToIndex(Guid id)
        {
            var model = Models.Users.GetUserAwards(id);
            return PartialView(model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AddAwardToUser(Guid id)
        {
            var model = Models.Users.GetUser(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult AddAwardToUser(Guid UserID, Guid AwardID)
        {
            var model = Models.Users.GetUser(UserID);
            if (Models.Users.AddAwardToUser(UserID, AwardID))
            {
                return RedirectToAction("UserAwards", new { id = UserID });
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult GetUserImage(string path)
        {
            return File(DataFile.GetFile(path), "image/jpeg", path);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult UploadImage(Guid id)
        {
            Guid UserID = id;
            return View(UserID);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult UploadImage(Guid id, HttpPostedFileBase image)
        {
            Guid UserID = id;
            try
            {
                Models.Users user = Models.Users.GetUser(id);
                string path = Path.Combine(Models.Users.ImageDirectory, user.Id.ToString());
                DataFile.SaveFile(image, path);
                user.SetImage();
            }
            catch
            {
                return RedirectToAction("Details", new { id = UserID });
            }

            return RedirectToAction("Details", new { id = UserID });
        }

        //  [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult RemoveImage(Guid id)
        {
            Models.Users user = Models.Users.GetUser(id);
            user.RemoveImage();
            Guid UserID = id;

            return RedirectToAction("Details", new { id = UserID });
        }
    }
}