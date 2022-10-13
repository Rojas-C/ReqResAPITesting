using System;
using Adapter.Core.Web;
using Adapter.ReqResAPI.API;
using log4net;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using static Adapter.ReqResAPI.API.UserRest;

namespace Adapter.ReqResAPI.Services
{
    public class UserService
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static string protocol => TestContext.Parameters["Protocol"];
        private static string baseUrl => TestContext.Parameters["BaseUrl"];
        private static string userEndpoint => TestContext.Parameters["Path"] + TestContext.Parameters["UserResource"];
        private UserRest userRest;
        private UserGetResponse userResult;

        public UserService()
        {
            var url = ITAFConfig.BuildURL(protocol, baseUrl);
            userRest = new UserRest(url, userEndpoint);
            userResult = new UserGetResponse();
        }

        public static IRestResponse GetUsers()
        {
            var url = ITAFConfig.BuildURL(protocol, baseUrl);
            UserService us = new UserService();
            us.userRest = new UserRest(url, userEndpoint);

            return us.userRest.GetMethod();
        }

        public static IRestResponse GetUserById(int userId)
        {
            var url = ITAFConfig.BuildURL(protocol, baseUrl);
            UserService us = new UserService();
            us.userRest = new UserRest(url, userEndpoint + $"/{userId}");

            return us.userRest.apiRequest(RestSharp.Method.GET);
        }

        public static IRestResponse PostUserCreate(object user)
        {
            var url = ITAFConfig.BuildURL(protocol, baseUrl);
            UserService us = new UserService();
            us.userRest = new UserRest(url, userEndpoint);

            return us.userRest.PostMethod(JsonConvert.SerializeObject(user));
        }

        public static IRestResponse PatchUser(string userId, object user)
        {
            var url = ITAFConfig.BuildURL(protocol, baseUrl);
            UserService us = new UserService();
            us.userRest = new UserRest(url, userEndpoint + "/" + userId);

            return us.userRest.PatchMethod(JsonConvert.SerializeObject(user));
        }
    }
}
