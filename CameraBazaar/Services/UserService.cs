using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CameraBazaar.Models.BindingModels;
using CameraBazaar.Models.Models;
using CameraBazaar.Models.ViewModels;

namespace CameraBazaar.Services
{
    public class UserService : Service
    {
        public void RegisterUser(RegisterUserBindingModel bind)
        {
            User user = Mapper.Map<RegisterUserBindingModel, User>(bind);
            this.context.Users.Add(user);
            this.context.SaveChanges();
        }

        public void LoginUser(LoginUserBindingModel bind, string sessionSessionId)
        {
            if (!this.context.Logins.Any(login => login.SessionId == sessionSessionId))
            {
                this.context.Logins.Add(new Login() { SessionId = sessionSessionId });
                this.context.SaveChanges();
            }

            Login mylogin = this.context.Logins.FirstOrDefault(login => login.SessionId == sessionSessionId);
            mylogin.IsActive = true;
            User model =
                this.context.Users.FirstOrDefault(
                    user => user.Username == bind.Username && user.Password == bind.Password);

            mylogin.User = model;
            this.context.SaveChanges();
        }

        public ProfilePageViewModel GetProfilePage(string username, string userUsername)
        {
            User user = this.context.Users.First(user1 => user1.Username == username);
            if (user == null)
            {
                return null;
            }

            ProfilePageViewModel page = new ProfilePageViewModel();
            page.Username = username;
            page.Email = user.Email;
            page.InStockCameras = user.Cameras.Count(camera => camera.Quantity > 0);
            page.OutOfStockCameras = user.Cameras.Count(camera => camera.Quantity == 0);
            page.Phone = user.Phone;
            page.Id = user.Id;
            if (userUsername == username)
            {
                page.Id = 0;
            }

            page.Cameras = Mapper.Map<IEnumerable<Camera>, IEnumerable<ShortCameraViewModel>>(user.Cameras);
            return page;
        }

        public EditUserViewModel GetEditUserVm(User user)
        {
            EditUserViewModel vm = new EditUserViewModel();
            User currentUser = this.context.Users.Find(user.Id);
            vm.Phone = currentUser.Email;
            vm.Phone = currentUser.Phone;

            return vm;
        }

        public void EditUser(EditUserBindingModel bind, User userr)
        {
            User user = this.context.Users.Find(userr.Id);
            user.Phone = bind.Phone;
            user.Email = bind.Email;
            user.Password = bind.Password;
            this.context.SaveChanges();
        }
    }
}