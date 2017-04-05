using System.Collections.Generic;

namespace CameraBazaar.Models.ViewModels
{
    public class ProfilePageViewModel
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int InStockCameras { get; set; }

        public int OutOfStockCameras { get; set; }

        public IEnumerable<ShortCameraViewModel> Cameras { get; set; }
    }
}