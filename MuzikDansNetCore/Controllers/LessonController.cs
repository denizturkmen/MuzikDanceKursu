using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MuzikDansNetCore.Business.Abstract;
using MuzikDansNetCore.Entities;
using MuzikDansNetCore.Models.Lesson;

namespace MuzikDansNetCore.Controllers
{
    public class LessonController : Controller
    {
        private ILessonService _lessonService;

        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        public IActionResult LessonList()
        {
            return View(new LessonListModel()
            {
                Lessons = _lessonService.GetAll()
            });
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(LessonModel model)
        {
            
            if (ModelState.IsValid)
            {
                var entity = new Lesson()
                {
                    LessonName = model.LessonName,
                    Description = model.Description
                };

                if (model.Images.Length>0) // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                {
                    entity.Images = model.Images.FileName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", model.Images.FileName);
                    using (var stream = new FileStream(path,FileMode.Create))
                    {
                        await model.Images.CopyToAsync(stream);
                    }
                }
                _lessonService.Create(entity);
                return RedirectToAction("LessonList");

            }

            return View();
        }


    }
}