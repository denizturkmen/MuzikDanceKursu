using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MuzikDansNetCore.Business.Abstract;
using MuzikDansNetCore.Entities;
using MuzikDansNetCore.Models.Teacher;

namespace MuzikDansNetCore.Controllers
{
    public class TeacherController : Controller
    {
        private ITeacherService _teacherService;
        private IBranchService _branchService;

        public TeacherController(ITeacherService teacherService, IBranchService branchService)
        {
            _teacherService = teacherService;
            _branchService = branchService;
        }

        public IActionResult Index()
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
        public IActionResult Create(TeacherModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = new Teacher()
                {
                    TeacherName = model.TeacherName,
                    Image = model.Image,
                    Education = model.Education,
                    BranchId = model.BranchId
                };
                _teacherService.Create(entity);
                return RedirectToAction("Index");
            }

            ViewBag.BranchId = new SelectList(_branchService.GetAll(), "BranchId", "BranchName", model.BranchId);


            return View(model);

        }

    }
}