using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using CameraBazaar.Models.BindingModels;
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
        [Route("details/{id?}")]
        // GET: Cameras/Details/5
        public ActionResult Details(int id)
        {
            CameraDetailsViewModel cdvm = this.service.GetDetailsCameraById(id);
            if (cdvm == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return this.View(cdvm);
        }

        // GET: Cameras/Create
        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {
            CreateCameraViewModel ccvm = new CreateCameraViewModel();
            return View(ccvm);
        }

        // POST: Cameras/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Make,Model,Price,Quantity,MinShutterSpeed,MaxShutterSpeed,MinIso,MaxIso,IsFullFrame,VideoResolution,LightMetering,Description,ImageUrl")] CreateCameraBindingModel ccbm)
        {
            if (this.ModelState.IsValid)
            {
                this.service.CreateCamera(ccbm);
                return this.RedirectToAction("All");
            }

            CreateCameraViewModel ccvm = Mapper.Map<CreateCameraBindingModel, CreateCameraViewModel>(ccbm);
            return View(ccvm);

        }

        // GET: Cameras/Edit/5
        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int id)
        {
            EditCameraViewModel ecvm = this.service.GetEditView(id);

            if (ecvm == null)
            {
                return this.RedirectToAction("All");
            }
             
            return View(ecvm);
        }

        // POST: Cameras/Edit/5
        [HttpPost]
        [Route("edit/{id}")]
        public ActionResult Edit([Bind(Include = "Id, Make,Model,Price,Quantity,MinShutterSpeed,MaxShutterSpeed,MinIso,MaxIso,IsFullFrame,VideoResolution,LightMetering,Description,ImageUrl")] EditCameraBindingModel ecbm)
        {
            if (ModelState.IsValid)
            {
                this.service.EditCamera(ecbm);
                return this.RedirectToAction("All");
            }

            EditCameraViewModel ecvm = Mapper.Map<EditCameraBindingModel, EditCameraViewModel>(ecbm);

            return this.View(ecvm);
        }

        // GET: Cameras/Delete/5
        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int? id)
        {
            DeleteCameraViewModel dcvm = this.service.GetDeleteCameraById(id);
            if (dcvm == null)
            {
                return this.RedirectToAction("All");
            }

            return this.View(dcvm);
        }

        // POST: Cameras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("delete/{id}")]
        public ActionResult DeleteConfirmed(int id)
        {
            this.service.DeleteCamera(id);

            return this.RedirectToAction("All");
        }
    }
}
