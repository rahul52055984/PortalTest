using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using DemoPortal.DBContext;
using DemoPortal.Models;
using DemoPortal.Utility;



namespace DemoPortal.WebApis
{

    public class AccountController : ApiController
    {
        [System.Web.Http.Route("api/login")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult Login(UserLoginModel model)
        {
            ApiResponse<UserLoginModel> response = new ApiResponse<UserLoginModel>();
            try
            {
                List<UserLoginModel> users = (from n in PortalDBContext.DB_Instance.LoginUsers.Where(x => x.Email == model.Email && x.Password == model.Password)
                                              select new UserLoginModel()
                                              {
                                                  UserId = n.UserId,
                                                  FullName = n.FullName,
                                                  Email = n.Email,
                                                  Password = n.Password,
                                                  RoleId = n.RoleId,

                                              }).ToList();

                if (users != null && users.Count > 0)
                {
                    response.Data = users.FirstOrDefault();
                    response.Message = "Data Found";
                    response.Status = true;
                }
                else
                {
                    response.Data = null;
                    response.Message = "User Not Exist";
                    response.Status = false;
                }
                return Ok(response);
            }
            catch (Exception Ex)
            {
                return Ok(new ApiResponse<UserModel>() { Message = "Error Occured", Data = null, Error = Ex.ToString(), Status = false });
            }
        }

        //[System.Web.Http.Route("api/GetData")]
        //[System.Web.Http.HttpPost]
        //public IHttpActionResult GetUserData(int CreatedBy)
        //{
        //    ApiResponse<List<UserModel>> response = new ApiResponse<List<UserModel>>();
        //    try
        //    {
        //        List<UserLoginModel> users = (from n in PortalDBContext.DB_Instance.Users.Where(x => x.Id == CreatedBy)
        //                                      select new UserLoginModel()
        //                                      {
        //                                          Id = n.Id,
        //                                          FullName = n.FullName,
        //                                          EmailID = n.EmailID,
        //                                          Password = n.Password,
        //                                          RoleId = n.RoleId,
        //                                          UserName = n.UserName
        //                                      }).ToList();

        //        if (users != null && users.Count > 0)
        //        {
        //            response.Data = users;
        //            response.Message = "Data Found";
        //            response.Status = true;
        //        }
        //        else
        //        {
        //            response.Data = null;
        //            response.Message = "User Not Exist";
        //            response.Status = false;
        //        }
        //        return Ok(response);
        //    }
        //    catch (Exception Ex)
        //    {
        //        return Ok(new ApiResponse<UserModel>() { Message = "Error Occured", Data = null, Error = Ex.ToString(), Status = false });
        //    }
        //}

        [System.Web.Http.Route("api/AdminGetData")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult GetUserData()
        {
            ApiResponse<List<UserModel>> response = new ApiResponse<List<UserModel>>();
            try
            {
                List<UserModel> users = (from n in PortalDBContext.DB_Instance.LoginUsers
                                         select new UserModel()
                                         {
                                             UserId = n.UserId,
                                             FullName = n.FullName,
                                             MobileNumber = n.MobileNumber,
                                             Email = n.Email,
                                             Address = n.Address,
                                             Status = n.Status,
                                             CreatedBy = n.CreatedBy,
                                             CreatedDate = n.CreatedDate,
                                             RoleId = n.RoleId,
                                         }).ToList();

                if (users != null && users.Count > 0)
                {
                    response.Data = users;
                    response.Message = "Data Found";
                    response.Status = true;
                }
                else
                {
                    response.Data = null;
                    response.Message = "User Not Exist";
                    response.Status = false;
                }
                return Ok(response);
            }
            catch (Exception Ex)
            {
                return Ok(new ApiResponse<UserListModel>() { Message = "Error Occured", Data = null, Error = Ex.ToString(), Status = false });
            }
        }
        [System.Web.Http.Route("api/GetUserById")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult GetUserById(UserModel User)
        {
            ApiResponse<UserModel> response = new ApiResponse<UserModel>();
            try
            {
                List<UserModel> users = (from n in PortalDBContext.DB_Instance.LoginUsers.Where(x => x.UserId == User.UserId)
                                         select new UserModel()
                                         {
                                             UserId = n.UserId,
                                             FullName = n.FullName,
                                             MobileNumber = n.MobileNumber,
                                             Email = n.Email,
                                             Address = n.Address,
                                             Status = n.Status,
                                             CreatedBy = n.CreatedBy,
                                             CreatedDate = n.CreatedDate,
                                             RoleId = n.RoleId,
                                             Password = n.Password,
                                         }).ToList();

                if (users != null && users.Count > 0)
                {
                    response.Data = users.FirstOrDefault();
                    response.Message = "Data Found";
                    response.Status = true;
                }
                else
                {
                    response.Data = null;
                    response.Message = "User Not Exist";
                    response.Status = false;
                }
                return Ok(response);
            }
            catch (Exception Ex)
            {
                return Ok(new ApiResponse<UserListModel>() { Message = "Error Occured", Data = null, Error = Ex.ToString(), Status = false });
            }
        }


        [System.Web.Http.Route("api/GetUserDataByUserCreated")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult GetUserDataByUserCreated(UserModel model)
        {
            ApiResponse<List<UserModel>> response = new ApiResponse<List<UserModel>>();
            try
            {
                List<UserModel> users = (from n in PortalDBContext.DB_Instance.LoginUsers.Where(x=>x.CreatedBy==model.UserId)
                                         select new UserModel()
                                         {
                                             UserId = n.UserId,
                                             FullName = n.FullName,
                                             MobileNumber = n.MobileNumber,
                                             Email = n.Email,
                                             Address = n.Address,
                                             Status = n.Status,
                                             CreatedBy = n.CreatedBy,
                                             CreatedDate = n.CreatedDate,
                                             RoleId = n.RoleId,
                                         }).ToList();

                if (users != null && users.Count > 0)
                {
                    response.Data = users;
                    response.Message = "Data Found";
                    response.Status = true;
                }
                else
                {
                    response.Data = null;
                    response.Message = "User Not Exist";
                    response.Status = false;
                }
                return Ok(response);
            }
            catch (Exception Ex)
            {
                return Ok(new ApiResponse<UserListModel>() { Message = "Error Occured", Data = null, Error = Ex.ToString(), Status = false });
            }
        }

        [System.Web.Http.Route("api/UpdateProfile")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult UpdateProfile(UserModel User)
        {
            ApiResponse<string> response = new ApiResponse<string>();
            try
            {
                LoginUser users = (from x in PortalDBContext.DB_Instance.LoginUsers where x.UserId == User.UserId select x).FirstOrDefault();

                if (users != null)
                {
                    users.FullName = User.FullName;
                    users.Email = User.Email;
                    users.MobileNumber = User.MobileNumber;
                    users.Address = User.Address;
                    users.Password = User.Password;
                    users.UpdateddBy = User.UpdateddBy;
                    users.UpdateedDate = User.UpdateedDate;
                    if (PortalDBContext.DB_Instance.SaveChanges() > 0)
                    {
                        response.Message = "User Updated";
                        response.Data = "User Updated";
                        response.Status = true;
                    }
                    else
                    {
                        response.Message = "User Not Updated";
                        response.Data = "Not Updated";
                        response.Status = false;
                    }
                }
                else
                {
                    response.Data = "Not Updated";
                    response.Message = "User Not Updated";
                    response.Status = false;
                }
                return Ok(response);
            }
            catch (Exception Ex)
            {
                return Ok(new ApiResponse<string>() { Message = "Error Occured", Data = "Error Occured", Error = Ex.ToString(), Status = false });
            }
        }
        [System.Web.Http.Route("api/createuser")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult Registration(UserModel model)
        {
            ApiResponse<string> response = new ApiResponse<string>();
            try
            {
                if (model != null)
                {
                    //UserSetting setting = new UserSetting();
                    LoginUser newUser = new LoginUser()
                    {
                        FullName = model.FullName,
                        Email=model.Email,
                        Password=model.Password,
                        MobileNumber = model.MobileNumber,
                        Address = model.Address,
                        Status = model.Status,
                        RoleId=model.RoleId,
                        CreatedBy=model.CreatedBy,
                        CreatedDate=DateTime.Now,
                        UpdateedDate=model.UpdateedDate,
                        UpdateddBy=model.UpdateddBy

                    };
                    PortalDBContext.DB_Instance.LoginUsers.Add(newUser);
                    if (PortalDBContext.DB_Instance.SaveChanges() > 0)
                    {
                        response.Message = "User Created";
                        response.Status = true;
                    }
                    else
                    {
                        response.Message = "User Not Created";
                        response.Status = false;
                    }
                }
                return Ok(response);
            }
            catch (Exception Ex)
            {
                return Ok(new ApiResponse<string>() { Message = "Error Occured", Data = "", Error = Ex.ToString(), Status = false });
            }
        }
        [System.Web.Http.Route("api/UpdateProfilebyAdmin")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult UpdateProfilebyAdmin(UserModel User)
        {
            ApiResponse<string> response = new ApiResponse<string>();
            try
            {
                LoginUser users = (from x in PortalDBContext.DB_Instance.LoginUsers where x.UserId == User.UserId select x).FirstOrDefault();

                if (users != null)
                {
                    users.FullName = User.FullName;
                    users.Email = User.Email;
                    users.MobileNumber = User.MobileNumber;
                    users.Address = User.Address;
                    users.Password = User.Password;
                    users.UpdateddBy = User.UpdateddBy;
                    users.UpdateedDate = User.UpdateedDate;
                    if (PortalDBContext.DB_Instance.SaveChanges() > 0)
                    {
                        response.Message = "User Updated";
                        response.Data = "User Updated";
                        response.Status = true;
                    }
                    else
                    {
                        response.Message = "User Not Updated";
                        response.Data = "Not Updated";
                        response.Status = false;
                    }
                }
                else
                {
                    response.Data = "Not Updated";
                    response.Message = "User Not Updated";
                    response.Status = false;
                }
                return Ok(response);
            }
            catch (Exception Ex)
            {
                return Ok(new ApiResponse<string>() { Message = "Error Occured", Data = "Error Occured", Error = Ex.ToString(), Status = false });
            }
        }
    }
}