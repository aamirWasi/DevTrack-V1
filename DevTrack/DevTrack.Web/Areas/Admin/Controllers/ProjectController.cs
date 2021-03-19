using Autofac;
using DevTrack.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DevTrack.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProjectController : Controller
    {
        public ActionResult Index()
        {
            var model = Startup.AutofacContainer.Resolve<ProjectCreateModel>();
            var UserId = User?.FindFirst(ClaimTypes.NameIdentifier).Value;
            model.UserId = Guid.Parse(UserId);
            model.GetProjectList();

            return View(model);
        }
        public ActionResult Report()
        {
            return View();
        }

        public ActionResult MyActivities()
        {
            return View();
        }
        public ActionResult WebTracker()
        {
            return View();
        }
        public ActionResult Invoices()
        {
            return View();
        }

        public ActionResult AddProject()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProject(ProjectCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var UserId = User?.FindFirst(ClaimTypes.NameIdentifier).Value;
                model.UserId = Guid.Parse(UserId);

                model.CreateProject();

                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var model = Startup.AutofacContainer.Resolve<ProjectCreateModel>();
            model.GetProject(id);

            return View(model);
        }

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
