using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using DemoPortal.Models;
using DemoPortal.Services;
using static DemoPortal.App_Start.App_Start;

namespace DemoPortal.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        
        public ActionResult Login(UserLoginModel model)
        {
            string Message = null;
            if (model != null && model.Email != null && model.Password != null)
            {
                ApiResponse<UserLoginModel> login = new Services.LoginService().Login(model);
                if (login.Status && login.Data != null)
                {
                    Session["UserDetail"] = login.Data;
                    return RedirectToAction("Index", "Home");
                }
                else
                    Message = "User Id or Password wrong.";

            }
            else
                Message = "Please enter UserId/Password";
            ViewBag.Message = Message;
            return View();
        }

         }
}