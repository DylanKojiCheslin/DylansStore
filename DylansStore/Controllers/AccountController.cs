using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DylansStore.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Acount/

        //public ActionResult Index()
        //{
        //    //creates a user
        //    //var test = Membership.CreateUser("admin", "test1234", "email@mail.com");

        //    ////log in a user
        //    //FormsAuthentication.SetAuthCookie("admin", false);


        //    ////to valadate a user
        //    //if (Membership.ValidateUser("admin", "password"))
        //    //{
        //    //    //log in
        //    //}
        //    //else
        //    //{
        //    //        // pass dosn't work
        //    //}


        //    //return Content(test.UserName);
        //}

        [HttpPost]
        public ActionResult Login(Models.Login login, string returnURL)
        {
            if (Membership.ValidateUser(login.UserName, login.PassWord))
            {
                //valid user
                FormsAuthentication.SetAuthCookie(login.UserName, false);
                return Redirect(returnURL);
            }
            else
            {
                //invalid user
                ViewBag.ErrorMessage ="Invalid user name or password";
                return PartialView(login);
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Models.Register register)
        {
            try
            {
                var user = Membership.CreateUser(register.UserName, register.Password, register.Email);
                FormsAuthentication.SetAuthCookie(register.UserName, false);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {

                ViewBag.ErrorMesage = ex.Message;
                return View(register);
            }
        }

        public ActionResult Logout(string returnURL)
        {
            FormsAuthentication.SignOut();
            return Redirect(returnURL);
        }
    }
}
