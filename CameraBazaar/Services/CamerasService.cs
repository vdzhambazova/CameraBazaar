using System.Collections.Generic;
using System.Data.Entity;
using AutoMapper;
using CameraBazaar.Models.BindingModels;
using CameraBazaar.Models.Models;
using CameraBazaar.Models.ViewModels;

namespace CameraBazaar.Services
{
    public class CamerasService : Service
    {
        public IEnumerable<ShortCameraViewModel> GetAllCameras()
        {
            IEnumerable<Camera> allCameras = this.context.Cameras;
            IEnumerable<ShortCameraViewModel> allscvm = Mapper.Map<IEnumerable<Camera>, IEnumerable<ShortCameraViewModel>>(allCameras);

            return allscvm;
        }

        public CameraDetailsViewModel GetDetailsCameraById(int id)
        {
            var camera = this.context.Cameras.Find(id);
            CameraDetailsViewModel cdvm = Mapper.Map<Camera, CameraDetailsViewModel>(camera);

            return cdvm;
        }

        public void CreateCamera(CreateCameraBindingModel bind)
        {
            Camera camera = Mapper.Map<CreateCameraBindingModel, Camera>(bind);
            this.context.Cameras.Add(camera);
            this.context.SaveChanges();
        }

        public EditCameraViewModel GetEditView(int id)
        {
            Camera cam = this.context.Cameras.Find(id);
            EditCameraViewModel euvm = Mapper.Map<Camera, EditCameraViewModel>(cam);

            return euvm;
        }

        public void EditCamera(EditCameraBindingModel ecbm)
        {
            Camera cam = Mapper.Map<EditCameraBindingModel, Camera>(ecbm);
            this.context.Entry(cam).State = EntityState.Modified;
            this.context.SaveChanges();
        }

        public DeleteCameraViewModel GetDeleteCameraById(int? id)
        {
            Camera cam = this.context.Cameras.Find(id);
            DeleteCameraViewModel dcvm = Mapper.Map<Camera, DeleteCameraViewModel>(cam);

            return dcvm;
        }

        public void DeleteCamera(int id)
        {
            Camera camera = this.context.Cameras.Find(id);
            this.context.Cameras.Remove(camera);
            this.context.SaveChanges();
        }
    }
}