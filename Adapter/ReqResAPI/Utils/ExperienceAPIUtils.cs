using System;
using Adapter.ReqResAPI.Models;
using Adapter.ReqResAPI.Services;
using log4net;
using Newtonsoft.Json;
using static Adapter.ReqResAPI.API.UserRest;

namespace Adapter.App_API.Utils
{
    public class ExperienceAPIUtils
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ExperienceAPIUtils()
        {
        }
        
        public static string getIDFromCreatedNewUser(object user)
        {
            
            var response = UserService.PostUserCreate(user);
            var responseBody = JsonConvert.DeserializeObject<UserPostResponse>(response.Content);
            string userId = responseBody.id;
            log.Info("CreatedUser >> " + userId);

            return userId;
        }
        

        // public static string getNumberFromCreatedAccount(NewAccount account, Customer primaryCustomer)
        // {
        //     string customerId = ExperienceAPIUtils.getIDFromCreatedNewCustomer(primaryCustomer);
        //     //account.owners[0].customerId = customerId;
        //     var response = AccountService.PostAccountCreate(account);
        //     var responseBody = JsonConvert.DeserializeObject<AccountPostResponse>(response.Content);
        //     string accountNumber = responseBody.account.accountNumber;

        //     return accountNumber;
        // }

        public static object removeKeyFromObject(object json, string key)
        {
            var jsonString = JsonConvert.SerializeObject(json);
            var newObject = (Newtonsoft.Json.Linq.JObject)JsonConvert.DeserializeObject(jsonString);
            newObject.Property(key).Remove();
            return newObject;
        }
    }
}