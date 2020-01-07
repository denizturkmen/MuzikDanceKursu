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
        public async Task<IActionResult> Create(TeacherModel model, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                var entity = new Teacher()
                {
                    TeacherName = model.TeacherName,
                    Education = model.Education,
                    BranchId = model.BranchId
                };
                if (file != null)
                {
                    entity.Image = file.FileName;

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", file.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
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
            var model = new TeacherModel()
            {
                Id = entity.TeacherId,
                TeacherName = entity.TeacherName,
                Education = entity.Education,
                Image = entity.Image,
                BranchId = entity.BranchId
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TeacherModel model, IFormFile file)
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