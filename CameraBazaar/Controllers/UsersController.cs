using System.Web.Mvc;
using CameraBazaar.Models.BindingModels;
using CameraBazaar.Models.Models;
using CameraBazaar.Models.ViewModels;
using CameraBazaar.Security;
using CameraBazaar.Services;

namespace CameraBazaar.Controllers
{
    [RoutePrefix("users")]
    public class UsersController : Controller
    {
        private UserService userService;

        public UsersController()
        {
            this.userService = new UserService();
        }

        // GET: Users
        [HttpGet]
        [Route("register")]
        public ActionResult Register()
        {
            return View(new RegisterUserViewModel());
        }

        [HttpPost]
        public ActionResult Register(RegisterUserBindingModel bind)
        {
            if (this.ModelState.IsValid)
            {
                this.userService.RegisterUser(bind);
                return this.RedirectToAction("Login");
            }

            return View(new RegisterUserViewModel());
        }

        [HttpGet]
        [Route("login")]
        public ActionResult Login()
        {
            return this.View(new LoginUserBindingModel());
        }

        [HttpPost]
        public ActionResult Login(LoginUserBindingModel bind)
        {
            if (this.ModelState.IsValid)
            {
                this.userService.LoginUser(bind, this.Session.SessionID);
                return this.RedirectToAction("Profile");
            }

            return this.View(new LoginUserBindingModel());
        }

        [HttpPost]
        [Route("logout")]
        public ActionResult Logout()
        {
            string sessionId = this.Request.Cookies.Get("sessionId")?.Value;
            if (AuthenticationManager.IsAuthenticated(sessionId))
            {
                AuthenticationManager.Logout(sessionId);
            }

            return this.RedirectToAction("Login");
        }

        [HttpGet]
        [Route("profile/{username?}")]
        public ActionResult Profile(string username)
        {
            string sessionId = this.Request.Cookies.Get("sessionId")?.Value;
            if (!AuthenticationManager.IsAuthenticated(sessionId))
            {
                return this.RedirectToAction("Login");
            }

            User user = AuthenticationManager.GetAuthenticatedUser(sessionId);
            if (string.IsNullOrEmpty(username))
            {
                ProfilePageViewModel myProfile = this.userService.GetProfilePage(user.Username, user.Username);
                if (myProfile == null)
                {
                    return new HttpNotFoundResult();
                }

                return this.View("MyProfile", myProfile);
            }

            ProfilePageViewModel vm = this.userService.GetProfilePage(username, user.Username);
            return this.View(vm);
        }

    }
}