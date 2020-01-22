using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using MuzikDansNetCore.Business.Abstract;
using MuzikDansNetCore.DataAccessLayer.Abstract;
using MuzikDansNetCore.Entities;
using MuzikDansNetCore.Models.Teacher;

namespace MuzikDansNetCore.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TeacherController : Controller
    {
        private ITeacherService _teacherService;
        private IBranchService _branchService;

        public TeacherController(ITeacherService teacherService, IBranchService branchService)
        {
            _teacherService = teacherService;
            _branchService = branchService;
        }

        public IActionResult TeacherList()
        {
            return View(new TeacherListModel()
            {
                Teachers = _teacherService.GetAll()
            });
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.BranchId = new SelectList(_branchService.GetAll(), "BranchId", "BranchName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TeacherModelSocial model)
        {
            if (ModelState.IsValid)
            {
                var entity = new Teacher()
                {
                    TeacherName = model.TeacherName,
                    Education = model.Education,
                    BranchId = model.BranchId,
                    Description = model.Description,
                    FacebookAdress = model.FacebookAdress,
                    TwitterAdress = model.TwitterAdress,
                    InstagramAdress = model.InstagramAdress

                };
                if (model.Image.Length > 0)
                {
                    entity.Image = model.Image.FileName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", model.Image.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await model.Image.CopyToAsync(stream);
                    }
                }

                _teacherService.Create(entity);
                return RedirectToAction("TeacherList");
            }

            ViewBag.BranchId = new SelectList(_branchService.GetAll(), "BranchId", "BranchName", model.BranchId);

            return View(model);

        }

        public IActionResult Edit(int? id)
        {
            ViewBag.BranchId = new SelectList(_branchService.GetAll(), "BranchId", "BranchName");
            if (id == null)
            {
                return NotFound();
            }
            var entity = _teacherService.GetById((int)id);
            if (entity == null)
            {
                return NotFound();
            }
            var model = new TeacherEdit()
            {
                Id = entity.TeacherId,
                TeacherName = entity.TeacherName,
                Education = entity.Education,
                Image = entity.Image,
                Description = entity.Description,
                FacebookAdress = entity.FacebookAdress,
                TwitterAdress = entity.TwitterAdress,
                InstagramAdress = entity.InstagramAdress,
                BranchId = entity.BranchId,

            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TeacherEdit model, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                var entity = _teacherService.GetById(model.Id);

                if (entity == null)
                {
                    return NotFound();
                }

                entity.TeacherName = model.TeacherName;
                entity.Education = model.Education;
                entity.BranchId = model.BranchId;
                entity.Description = model.Description;
                entity.FacebookAdress = model.FacebookAdress;
                entity.TwitterAdress = model.TwitterAdress;
                entity.InstagramAdress = model.InstagramAdress;

                if (file != null)
                {
                    entity.Image = file.FileName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", file.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }

                _teacherService.Update(entity);
                return RedirectToAction("TeacherList");
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var entity = _teacherService.GetById(id);

            if (entity != null)
            {
                _teacherService.Delete(entity);
            }

            return RedirectToAction("TeacherList");

        }

    }
}