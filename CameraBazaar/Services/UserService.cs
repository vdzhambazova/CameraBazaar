using System.Linq;
using AutoMapper;
using CameraBazaar.Models.BindingModels;
using CameraBazaar.Models.Models;
using CameraBazaar.Models.ViewModels;

namespace CameraBazaar.Services
{
    public class UserService: Service
    {
        public void RegisterUser(RegisterUserBindingModel bind)
        {
            User user = Mapper.Map<RegisterUserBindingModel, User>(bind);
            this.context.Users.Add(user);
            this.context.SaveChanges();
        }

        public void LoginUser(LoginUserBindingModel bind, string sessionSessionId)
        {
            if (this.context.Users.Any(u => u.Username == bind.Username && u.Password == bind.Password))
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
        }

        public ProfilePageViewModel GetProfilePage(string username, string userUsername)
        {
            throw new System.NotImplementedException();
        }
    }
}