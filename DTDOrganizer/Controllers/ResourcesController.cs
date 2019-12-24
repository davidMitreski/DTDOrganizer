using DTDOrganizer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DTDOrganizer.Controllers
{
    //Handles the HTTP requests for the Resources module
    public class ResourcesController : Controller
    {
        private MyDBContext db = new MyDBContext();
        // GET: Resources
        public ActionResult Index()
        {
            return View();
        }

        // POST: Resources/Office
        [HttpPost]
        public ActionResult Office()
        {
            return PartialView("~/Views/Resources/_ResourcePartial.cshtml", db.AdminResources.Where(i => i.Type == ResourceType.Office));
        }

        // POST: Resources/WorkMaterials
        [HttpPost]
        public ActionResult WorkMaterials()
        {
            return PartialView("~/Views/Resources/_ResourcePartial.cshtml", db.AdminResources.Where(i => i.Type == ResourceType.WorkMaterials));
        }

        // POST: Resources/Utilities
        [HttpPost]
        public ActionResult Utilities()
        {
            return PartialView("~/Views/Resources/_ResourcePartial.cshtml", db.AdminResources.Where(i => i.Type == ResourceType.Utilities));
        }

        // POST: Resources/Requests
        [HttpPost]
        public ActionResult Requests()
        {
            return PartialView("~/Views/Resources/_RequestsPartial.cshtml", db.RequestResources);
        }

        // GET: Resources/RequestAnItem
        [HttpGet]
        public ActionResult RequestAnItem(int id) {
            ResourcesAdminModel model = db.AdminResources.Where(i => i.Id == id).FirstOrDefault();
            var viewModel = new ResourcesRequestViewModel()
            {
                type = model.Type,
                ResourceName = model.Name,
                Qty = 0,
                Comment = "",
                Urgent = false
            };

            return PartialView("~/Views/Resources/RequestAnItem.cshtml", viewModel);
        }

        // POST: Resources/RequestAnItem
        [HttpPost]
        public ActionResult RequestAnItem(ResourcesRequestViewModel model)
        {
            db.RequestResources.Add(new ResourcesRequestModel(model));
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Resources/Create
        public ActionResult CreateResource()
        {
            return View();
        }

        // POST: Resources/Create
        [HttpPost]
        public ActionResult CreateResource(ResourcesAdminViewModel model)
        {
            try
            {
                ResourcesAdminModel addResource = new ResourcesAdminModel
                {
                    Name = model.Name,
                    Description = model.Description,
                    Type = model.Type
                };
                if (model.image.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(model.image.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Content/Images/Resources"), _FileName);
                    model.image.SaveAs(_path);
                    addResource.Image = _path;
                }

                db.AdminResources.Add(addResource);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Resources/Delete
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                var resource = db.AdminResources.ToList().Find(r => r.Id == id);
                if(resource != null) db.AdminResources.Remove(resource);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //Disposes of the database instance so we can be certain that the database resource is released
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
