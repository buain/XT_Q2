using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGUI.Models;

namespace WebGUI.Controllers
{
    public class UsersController : Controller
    {
        public ActionResult Index()
        {
            var model = Users.GetAllUsers();
            return View(model);
        }
    }
}