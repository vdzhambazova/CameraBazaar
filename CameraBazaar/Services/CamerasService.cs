using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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

        public CameraDetailsViewModel GetCameraById(int id)
        {
            var camera = this.context.Cameras.Find(id);
            CameraDetailsViewModel cdvm = Mapper.Map<Camera, CameraDetailsViewModel>(camera);

            return cdvm;
        }
    }
}