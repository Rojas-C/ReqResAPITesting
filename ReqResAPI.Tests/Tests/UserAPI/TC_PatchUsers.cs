using System;
using System.Net;
using Adapter.App_API.Utils;
using Adapter.ReqResAPI.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using static Adapter.ReqResAPI.API.UserRest;
using static ReqResAPI.Tests.TestData.DataProvidersAPI;

namespace ReqResAPI.Tests.Tests.UserAPI
{
    public class TC_PatchUsers
    {
        [Test]
        [Category("Users")]
        [Author("JLR")]
        [Property("TestCaseId", "12350")]
        [TestCaseSource(typeof(PatchUserProvider))]
        [Description("Validate User Not Found")]
        public void PatchUser_TC12350(object user, JObject patchUserPayload, HttpStatusCode ExpectedStatusCode)
        {
            string userId = ExperienceAPIUtils.getIDFromCreatedNewUser(user);
            var response = UserService.PatchUser(userId, patchUserPayload);
            HttpStatusCode statusCode = response.StatusCode;

            Assert.Multiple(() =>
            {
                var responseBody = JsonConvert.DeserializeObject<UserPatchResponse>(response.Content);
                Assert.AreEqual(ExpectedStatusCode, statusCode, "Response code differs from expected");

                Assert.AreEqual(patchUserPayload["name"].ToString(), responseBody.name,"name differs from expected");
                Assert.AreEqual(patchUserPayload["job"].ToString(), responseBody.job,"job differs from expected");
                Assert.NotNull(responseBody.updatedAt,"total differs from expected");
            });
        }
    }
}