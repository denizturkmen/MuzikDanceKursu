using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MuzikDansNetCore.EmailServices;
using MuzikDansNetCore.Models.Email;


namespace MuzikDansNetCore.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(EmailModel model)
        {
            string context = "<br> Name : " + model.Name;
            context += "<br> Email : " + model.Email;
            context += "<br> Message :" + model.Message;

            if (EmailSender.SendMail(model.Email, model.Email, model.Message, context))
            {
                ViewBag.Message = "Success";
            }
            else
            {
                ViewBag.Message = "Error";
            }

            return RedirectToAction("Index");
        }


    }
}
