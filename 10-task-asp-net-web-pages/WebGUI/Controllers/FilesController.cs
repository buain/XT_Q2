using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGUI.Models;

namespace WebGUI.Controllers
{
    public class FilesController : Controller
    {
        //
        // GET: /Files/

        public ActionResult Index()
        {
            var desc = DataFile.FileName == null ? null : new FileDescription{ Name = DataFile.FileName };

            return View(desc);
        }

        public ActionResult UploadImage()
        {
            return View();
        }

        [HttpPost]
        //  [ValidateAntiForgeryToken]
        public ActionResult UploadImage(HttpPostedFileBase image)
        {
            DataFile.SaveFile(image);
            return RedirectToAction("Index");
        }

        public ActionResult GetImage()
        {
            return File(DataFile.GetFile("D:\\EpamTask"), "image/jpeg", "D:\\EpamTask");
        }
    }
}