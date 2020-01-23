using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MuzikDansNetCore.Business.Abstract;
using MuzikDansNetCore.EmailServices;
using MuzikDansNetCore.Models.Email;
using MuzikDansNetCore.Models.Lesson;
using MuzikDansNetCore.Models.Teacher;


namespace MuzikDansNetCore.Controllers
{
    public class HomeController : Controller
    {
        private ITeacherService _teacherService;
        private ILessonService _lessonService;


        public HomeController(ITeacherService teacherService, ILessonService lessonService)
        {
            _teacherService = teacherService;
            _lessonService = lessonService;
        }

        public IActionResult Index()
        {
            return View(new TeacherListModel()
            {
                Teachers = _teacherService.GetAll(),
                Lessons = _lessonService.GetAll()
            });
        }

        [HttpPost]
        public IActionResult Contact(TeacherListModel model)
        {
            string context = "<br> Name : " + model.EmailModel.Name;
            context += "<br> Email : " + model.EmailModel.Email;
            context += "<br> Message :" + model.EmailModel.Message;

            if (EmailSender.SendMail(model.EmailModel.Email, model.EmailModel.Email, model.EmailModel.Message, context))
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
