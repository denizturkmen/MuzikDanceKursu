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

                if (model.Images.Length > 0)
                {
                    entity.Images = model.Images.FileName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", model.Images.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await model.Images.CopyToAsync(stream);
                    }
                }
                _lessonService.Create(entity);
                return RedirectToAction("LessonList");

            }

            return View(model);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = _lessonService.GetById((int)id);
            if (entity == null)
            {
                return NotFound();
            }
            var model = new LessonEdit()
            {
                Id = entity.LessonId,
                LessonName = entity.LessonName,
                Description = entity.Description,
                Images = entity.Images

            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(LessonEdit model,IFormFile file)
        {
            if (ModelState.IsValid)
            {
                var entity = _lessonService.GetById(model.Id);
                if (entity == null)
                {
                    return NotFound();
                }

                entity.LessonName = model.LessonName;
                entity.Description = model.Description;
                if (file != null)
                {
                    entity.Images = file.FileName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", file.FileName);
                    using (var stream = new FileStream(path,FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }


                _lessonService.Update(entity);
                return RedirectToAction("LessonList");
            }

            return View(model);

        }

        public IActionResult Delete(int id)
        {
            var entity = _lessonService.GetById(id);
            if (entity!=null)
            {
                _lessonService.Delete(entity);
            }

            return RedirectToAction("LessonList");
        }


    }
}