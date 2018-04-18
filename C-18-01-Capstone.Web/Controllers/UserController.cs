using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using C_18_01_Capstone.Web.ViewModels;
using C_18_01_Capstone.Main.DataContext;

namespace C_18_01_Capstone.Web.Controllers
{  
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            var loginViewModel = new LoginViewModel()
            {
                Login = "Test",
                Password = "Test"
            };
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Register(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Login = userViewModel.Login,
                    HashedPassword = userViewModel.Password
                };
                return View();
            }
            throw new ApplicationException();
        }

        [HttpPost]
        public string Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                return "Logged in!";
            }
            throw new ApplicationException();
          
        }
    }
}