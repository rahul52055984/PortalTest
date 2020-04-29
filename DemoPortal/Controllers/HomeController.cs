using DemoPortal.Models;
using DemoPortal.Services;
using DemoPortal.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static DemoPortal.App_Start.App_Start;

namespace DemoPortal.Controllers
{
    [SessionExpire]
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        [UserAuthorize("Admin", "Agent", "Supervisor")]
        public ActionResult Index()
        {
            //UserListModel users = null;
            UserSetting setting = new UserSetting();
            List<UserModel> UserList = null;
            ApiResponse<List<UserModel>> apiResponse = setting.UserType==(int)UserTypeEnum.Admin? new LoginService().GetUserData(): new LoginService().GetUserDataByUserCreated(new UserLoginModel() { UserId=setting.UserId});
            if(apiResponse.Status && apiResponse.Data!=null && apiResponse.Data.Count>0)
            {
                //users = new UserListModel();
                UserList = new List<UserModel>();
                UserList = apiResponse.Data;
            }
            return View(UserList);
        }

        public ActionResult MyProfile()
        {
            UserModel model = new UserModel();
            ApiResponse<UserModel> modelData = new LoginService().GetUserById();
            if(modelData.Status && modelData.Data!=null)
            {
                model = modelData.Data;
            }
                return View(model);
        }

        [UserAuthorize("Admin")]
        [HttpGet]
        public ActionResult UpdateProfile(UserModel model)
        {
            if(model!=null)
            {
                UserSetting setting = new UserSetting();
                model.UpdateddBy = setting.UserId;
                model.UserId = setting.UserId;
                model.UpdateedDate = DateTime.Now;
                ApiResponse<string> modelData = new LoginService().UpdateProfile(model);
            }
            return View("MyProfile");
        }
        
        public ActionResult MyProfilebyAdmin(int UserId)
        {
            UserModel model = new UserModel();
            ApiResponse<UserModel> modelData = new LoginService().GetUserById(UserId);
            if (modelData.Status && modelData.Data != null)
            {
                model = modelData.Data;
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult UpdateProfileByAdmin(UserModel model)
        {
            if (model != null)
            {
                UserSetting setting = new UserSetting();
                model.UpdateddBy = setting.UserId;
                model.UserId = setting.UserId;
                model.UpdateedDate = DateTime.Now;
                ApiResponse<string> modelData = new LoginService().UpdateProfileByAdmin(model);
            }
            return View("MyProfilebyAdmin");
        }
       
        public ActionResult RegistrationUserProfile()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem() { Text = "Admin", Value = "1" ,Selected=true});
            items.Add(new SelectListItem() { Text = "Supervisor", Value = "2" });
            items.Add(new SelectListItem() { Text = "Agent", Value = "3" });
            ViewBag.UserType = items;
            return View();
        }
        [HttpPost]
    
        public ActionResult RegistrationUserProfile(UserModel model)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem() { Text = "Admin", Value = "1" , Selected = true });
            items.Add(new SelectListItem() { Text = "Supervisor", Value = "2" });
            items.Add(new SelectListItem() { Text = "Agent", Value = "3" });
            ViewBag.UserType = items;
            string Message = null;
            if (model != null)
            {
                model.CreatedBy = new UserSetting().UserId;
                model.CreatedDate = DateTime.Now;
                ApiResponse<string> login = new Services.LoginService().CreateUser(model);
            }
            else
                Message = "Please Fill all Data";
            ViewBag.Message = Message;
            return View(model);
        }
        public ActionResult Logout()
        {
            Session["UserDetail"] = null;
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Login", "Login");
        }
    }
}