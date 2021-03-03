using Autofac;
using DevTrack.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTrack.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectController : Controller
    {
        // GET: ProjectController
        public ActionResult Index()
        {
            var model = Startup.AutofacContainer.Resolve<ProjectCreateModel>();
            model.GetProjectList();

            return View(model);
        }

        public ActionResult AddProject()
        {
            return View();
        }

        // POST: ProjectController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProject(ProjectCreateModel model)
        {
            if (ModelState.IsValid)
            {
                model.CreateProject();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: ProjectController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = Startup.AutofacContainer.Resolve<ProjectCreateModel>();
            model.GetProject(id);

            return View(model);
        }

        // POST: ProjectController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProjectCreateModel model)
        {
            if (ModelState.IsValid)
            {
                model.EditProject();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var model = Startup.AutofacContainer.Resolve<ProjectCreateModel>();
            model.GetProject(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ProjectCreateModel model)
        {
            var id = model.Id;
            model.DeleteProject(id);
            
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var model = Startup.AutofacContainer.Resolve<ProjectCreateModel>();
            model.GetProject(id);

            return View(model);
        }
    }
}
