using DTDOrganizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DTDOrganizer.Controllers
{
    public class ResourcesController : Controller
    {
        private MyDBContext db = new MyDBContext();
        // GET: Resources
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Office()
        {
            return PartialView("~/Views/Resources/_OfficePartial.cshtml", db.AdminResources.Where(i => i.Type == ResourceType.Office));
        }

        public ActionResult WorkMaterials()
        {
            return PartialView("~/Views/Resources/_OfficePartial.cshtml", db.AdminResources.Where(i => i.Type == ResourceType.WorkMaterials));
        }

        public ActionResult Utilities()
        {
            return PartialView("~/Views/Resources/_OfficePartial.cshtml", db.AdminResources.Where(i => i.Type == ResourceType.Utilities));
        }

        public ActionResult Requests()
        {
            return PartialView("~/Views/Resources/_RequestsPartial.cshtml", db.RequestResources);
        }

        [HttpGet]
        public ActionResult RequestAnItem(int id) {
            ResourcesAdminModel model = db.AdminResources.Where(i => i.Id == id).FirstOrDefault();
            var viewModel = new ResourcesRequestModel()
            {
                //Id = ((db.RequestResources.ToList().LastOrDefault() == null) ? 0 : db.RequestResources.ToList().Last().Id) + 1,
                type = model.Type,
                ResourceName = model.Name,
                Qty = 0,
                Comment = "",
                Urgent = false
            };

            return PartialView("~/Views/Resources/RequestAnItem.cshtml", viewModel);
        }

        [HttpPost]
        public ActionResult RequestAnItem(ResourcesRequestModel model)
        {
            using (MyDBContext context = new MyDBContext())
            {
                //List<ResourcesRequestModel> dataModel = context.RequestResources.ToList();
                //dataModel.Add(model);
                context.RequestResources.Add(model);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: Resources/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Resources/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Resources/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Resources/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Resources/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Resources/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Resources/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
