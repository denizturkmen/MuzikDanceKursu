using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MuzikDansNetCore.Business.Abstract;
using MuzikDansNetCore.Entities;
using MuzikDansNetCore.Models.Branch;

namespace MuzikDansNetCore.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BranchController : Controller
    {

        private IBranchService _branchService;

        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        public IActionResult BranchList()
        {
            return View(new BranchListModel()
            {
                Branches = _branchService.GetAll()
            });
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BranchModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = new Branch()
                {
                    BranchName = model.BranchName

                };
                _branchService.Create(entity);
                return RedirectToAction("BranchList");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = _branchService.GetById((int)id);
            if (entity == null)
            {
                return NotFound();
            }
            var model = new BranchModel()
            {
                Id = entity.BranchId,
                BranchName = entity.BranchName
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(BranchModel model)
        {

            if (ModelState.IsValid)
            {
                var entity = _branchService.GetById(model.Id);
                if (entity == null)
                {
                    return NotFound();
                }

                entity.BranchName = model.BranchName;
                _branchService.Update(entity);
                return RedirectToAction("BranchList");
            }

            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var entity = _branchService.GetById(id);
            if (entity != null)
            {
                _branchService.Delete(entity);
            }

            return RedirectToAction("BranchList");
        }

    }
}