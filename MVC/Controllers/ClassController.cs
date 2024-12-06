﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BLL.Controllers.Bases;
using BLL.Services.Bases;
using BLL.Models;
using BLL.DAL;
using BLL.Services;

// Generated from Custom Template.

namespace MVC.Controllers
{
    public class ClassController : MvcController
    {
        // Service injections:
        private readonly IClassService _classService;

        /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
        //private readonly IService<{Entity}, {Entity}Model> _{Entity}Service;

        public ClassController(
            IClassService classService

            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            //, Service<{Entity}, {Entity}Model> {Entity}Service
        )
        {
            _classService = classService;

            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            //_{Entity}Service = {Entity}Service;
        }

        // GET: Classes
        public IActionResult Index()
        {
            // Get collection service logic:
            var list = _classService.Query().ToList();
            return View(list);
        }

        // GET: Classes/Details/5
        public IActionResult Details(int id)
        {
            // Get item service logic:
            var item = _classService.Query().SingleOrDefault(q => q.Record.Id == id);
            return View(item);
        }

        protected void SetViewData()
        {
            // Related items service logic to set ViewData (Record.Id and Name parameters may need to be changed in the SelectList constructor according to the model):
            
            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            //ViewBag.{Entity}Ids = new MultiSelectList(_{Entity}Service.Query().ToList(), "Record.Id", "Name");
        }

        // GET: Classes/Create
        public IActionResult Create()
        {
            SetViewData();
            return View();
        }

        // POST: Classes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ClassModel @class)
        {
            if (ModelState.IsValid)
            {
                // Insert item service logic:
                var result = _classService.Create(@class.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = @class.Record.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(@class);
        }

        // GET: Classes/Edit/5
        public IActionResult Edit(int id)
        {
            // Get item to edit service logic:
            var item = _classService.Query().SingleOrDefault(q => q.Record.Id == id);
            SetViewData();
            return View(item);
        }

        // POST: Classes/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ClassModel @class)
        {
            if (ModelState.IsValid)
            {
                // Update item service logic:
                var result = _classService.Update(@class.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = @class.Record.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(@class);
        }

        // GET: Classes/Delete/5
        public IActionResult Delete(int id)
        {
            // Get item to delete service logic:
            var item = _classService.Query().SingleOrDefault(q => q.Record.Id == id);
            return View(item);
        }

        // POST: Classes/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // Delete item service logic:
            var result = _classService.Delete(id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}