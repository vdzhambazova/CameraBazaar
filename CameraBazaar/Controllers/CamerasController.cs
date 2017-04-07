using System.Collections.Generic;
using System.Web.Mvc;
using CameraBazaar.Models.ViewModels;
using CameraBazaar.Services;

namespace CameraBazaar.Controllers
{
    [RoutePrefix("cameras")]
    public class CamerasController : Controller
    {
        private CamerasService service;

        public CamerasController()
        {
            this.service = new CamerasService();
        }

        [HttpGet]
        [Route("all")]
        [Route("~/")]
        public ActionResult All()
        {
            IEnumerable<ShortCameraViewModel> scvm = this.service.GetAllCameras();

            return this.View(scvm);
        }

        [HttpGet]
        [Route("details/id?")]
        // GET: Cameras/Details/5
        public ActionResult Details(int id)
        {
            CameraDetailsViewModel cdvm = this.service.GetCameraById(id);

            return this.View(cdvm);
        }

        // GET: Cameras/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cameras/Create
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

        // GET: Cameras/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cameras/Edit/5
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

        // GET: Cameras/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cameras/Delete/5
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
    }
}
