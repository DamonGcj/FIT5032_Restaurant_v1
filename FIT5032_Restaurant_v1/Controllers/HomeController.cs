using FIT5032_Restaurant_v1.Models;
using FIT5032_Week08A.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FIT5032_Restaurant_v1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Send_Email()
        {
            return View(new SendEmailViewModel());
        }

        [HttpPost]
        public ActionResult Send_Email(SendEmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    String toEmail = model.ToEmail;
                    String subject = model.Subject;
                    String contents = model.Contents;

                    EmailSender es = new EmailSender();
                    es.Send(toEmail, subject, contents);

                    ViewBag.Result = "Email has been send.";

                    ModelState.Clear();

                    return View(new SendEmailViewModel());
                }
                catch
                {
                    return View();
                }
            }

            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(Image image, HttpPostedFileBase postedFile)
        //{
        //    ModelState.Clear();
        //    var myUniqueFileName = string.Format(@"{0}", Guid.NewGuid());
        //    image.Path = myUniqueFileName; TryValidateModel(image);
        //    if (ModelState.IsValid)
        //    {
        //        string serverPath = Server.MapPath("~/Uploads/");
        //        string fileExtension = Path.GetExtension(postedFile.FileName);
        //        string filePath = image.Path + fileExtension;
        //        image.Path = filePath; postedFile.SaveAs(serverPath + image.Path);
        //        db.Images.Add(image); db.SaveChanges(); return RedirectToAction("Index");
        //    }
        //    return View(image);
        //}
    }
}