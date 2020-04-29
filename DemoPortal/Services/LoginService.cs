using DemoPortal.Models;
using DemoPortal.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace DemoPortal.Services
{
    public class LoginService
    {
        public ApiResponse<UserLoginModel> Login(UserLoginModel model)
        {
            ApiResponse<UserLoginModel> response = new ApiResponse<UserLoginModel>();
            using (var clients = new HttpClient())
            {
                response = Api.ApiRequest<UserLoginModel, ApiResponse<UserLoginModel>>(model, "api/login", "Post");
            };
            return response;
        }

        public ApiResponse<List<UserModel>> GetUserData()
        {
            ApiResponse<List<UserModel>> response = new ApiResponse<List<UserModel>>();
            using (var clients = new HttpClient())
            {

                response = Api.ApiRequest<UserLoginModel, ApiResponse<List<UserModel>>>(new UserLoginModel(), "api/AdminGetData", "Post");
            };
            return response;
        }

        public ApiResponse<List<UserModel>> GetUserDataByUserCreated(UserLoginModel model)
        {
            ApiResponse<List<UserModel>> response = new ApiResponse<List<UserModel>>();
            using (var clients = new HttpClient())
            {
                response = Api.ApiRequest<UserLoginModel, ApiResponse<List<UserModel>>>(model, "api/GetUserDataByUserCreated", "Post");
            };
            return response;
        }
        public ApiResponse<UserModel> GetUserById()
        {
            ApiResponse<UserModel> response = new ApiResponse<UserModel>();
            using (var clients = new HttpClient())
            {
                response = Api.ApiRequest<UserModel, ApiResponse<UserModel>>(new UserModel() { UserId = new UserSetting().UserId }, "api/GetUserById", "Post");
            };
            return response;
        }

        public ApiResponse<UserModel> GetUserById(int UserId)
        {
            ApiResponse<UserModel> response = new ApiResponse<UserModel>();
            using (var clients = new HttpClient())
            {
                response = Api.ApiRequest<UserModel, ApiResponse<UserModel>>(new UserModel() { UserId = UserId }, "api/GetUserById", "Post");
            };
            return response;
        }
        public ApiResponse<string> UpdateProfile(UserModel model)
        {
            ApiResponse<string> response = new ApiResponse<string>();
            using (var clients = new HttpClient())
            {
                response = Api.ApiRequest<UserModel, ApiResponse<string>>(model, "api/UpdateProfile", "Post");
            };
            return response;
        }
        public ApiResponse<string> CreateUser(UserModel model)
        {
            ApiResponse<string> response = new ApiResponse<string>();
            using (var clients = new HttpClient())
            {
                response = Api.ApiRequest<UserModel, ApiResponse<string>>(model, "api/createuser", "Post");
            };
            return response;
        }
        public ApiResponse<string> UpdateProfileByAdmin(UserModel model)
        {
            ApiResponse<string> response = new ApiResponse<string>();
            using (var clients = new HttpClient())
            {
                response = Api.ApiRequest<UserModel, ApiResponse<string>>(model, "api/UpdateProfilebyAdmin", "Post");
            };
            return response;
        }
    }
}