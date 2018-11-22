using EmailNotification.Models;
using System.Web.Helpers;
using System.Web.Mvc;

namespace EmailNotification.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SendEmail(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                string body = "<p>Hi " + model.Name + "</p></br>";
                body += "<pre>" + model.Message + "</pre>";
                WebMail.Send(model.Email, model.Subject, body, null, null, null, true, null, null, null, null, null, null);
                TempData["Success"] = "Email sent successfully.";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Error occured while sending Email.";
            return RedirectToAction("Index");
        }

    }
}