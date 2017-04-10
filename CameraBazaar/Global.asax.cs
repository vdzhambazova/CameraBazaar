using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using CameraBazaar.Models.BindingModels;
using CameraBazaar.Models.Models;
using CameraBazaar.Models.ViewModels;

namespace CameraBazaar
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            this.ConfigureMapper();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void ConfigureMapper()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<RegisterUserBindingModel, User>();
                expression.CreateMap<CreateCameraViewModel, Camera>();
                expression.CreateMap<CreateCameraBindingModel, CreateCameraViewModel>();
                expression.CreateMap<Camera, EditCameraViewModel>();
                expression.CreateMap<EditCameraBindingModel, EditCameraViewModel>();
                expression.CreateMap<EditCameraBindingModel, Camera>();
                expression.CreateMap<Camera, DeleteCameraViewModel>();
                expression.CreateMap<Camera, CameraDetailsViewModel>();
                expression.CreateMap<Camera, ShortCameraViewModel>();
            });
        }
    }
}
