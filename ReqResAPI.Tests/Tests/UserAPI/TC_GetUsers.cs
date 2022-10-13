using System;
using System.Net;
using Adapter.ReqResAPI.Models;
using Adapter.ReqResAPI.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using static Adapter.ReqResAPI.API.UserRest;
using static ReqResAPI.Tests.TestData.DataProvidersAPI;

namespace ReqResAPI.Tests.Tests.UserAPI
{
    public class TC_GetUsers
    {
        [Test]
        [Category("Users")]
        [Author("JLR")]
        [Property("TestCaseId", "12345")]
        [TestCaseSource(typeof(GetUsersProvider))]
        [Description("Get Users")]
        public void GetUsers_TC12345(Content content, HttpStatusCode ExpectedStatusCode)
        {
            var response = UserService.GetUsers();
            HttpStatusCode statusCode = response.StatusCode;

            Assert.Multiple(() =>
            {
                var responseBody = JsonConvert.DeserializeObject<UserGetResponse>(response.Content);
                //Console.WriteLine(response.Content);
                //Console.WriteLine("My json " + JsonConvert.SerializeObject(content));
                Assert.AreEqual(ExpectedStatusCode, statusCode, "Response code differs from expected");

                Assert.AreEqual(content.page, responseBody.page,"page differs from expected");
                Assert.AreEqual(content.per_page, responseBody.per_page,"per_page differs from expected");
                Assert.AreEqual(content.total, responseBody.total,"total differs from expected");
                Assert.AreEqual(content.total_pages, responseBody.total_pages,"total_pages differs from expected");

                Assert.AreEqual(content.data[0].id, responseBody.data[0].id,"data[0].id differs from expected");
                Assert.AreEqual(content.data[0].email, responseBody.data[0].email,"data[0].email differs from expected");
                Assert.AreEqual(content.data[0].first_name, responseBody.data[0].first_name,"data[0].first_name differs from expected");
                Assert.AreEqual(content.data[0].last_name, responseBody.data[0].last_name,"data[0].last_name differs from expected");
                Assert.AreEqual(content.data[0].avatar, responseBody.data[0].avatar,"data[0].avatar differs from expected");

                Assert.AreEqual(content.data[1].id, responseBody.data[1].id,"data[1].id differs from expected");
                Assert.AreEqual(content.data[1].email, responseBody.data[1].email,"data[1].email differs from expected");
                Assert.AreEqual(content.data[1].first_name, responseBody.data[1].first_name,"data[1].first_name differs from expected");
                Assert.AreEqual(content.data[1].last_name, responseBody.data[1].last_name,"data[1].last_name differs from expected");
                Assert.AreEqual(content.data[1].avatar, responseBody.data[1].avatar,"data[1].avatar differs from expected");

                Assert.AreEqual(content.support.url, responseBody.support.url,"support.url differs from expected");
                Assert.AreEqual(content.support.text, responseBody.support.text,"support.text differs from expected");

                Assert.IsTrue(responseBody.data.Exists(p => p.id.Equals(5)), "The user id doesn't exists");
            });
        }

        [Test]
        [Category("Users")]
        [Author("JLR")]
        [Property("TestCaseId", "12346")]
        [TestCaseSource(typeof(GetSingleUserProvider))]
        [Description("Get Single Users")]
        public void GetSingleUser_TC12346(Content content, HttpStatusCode ExpectedStatusCode, int userId)
        {
            var response = UserService.GetUserById(userId);
            HttpStatusCode statusCode = response.StatusCode;

            Assert.Multiple(() =>
            {
                var responseBody = JsonConvert.DeserializeObject<SingleUserGetResponse>(response.Content);
                
                Assert.AreEqual(ExpectedStatusCode, statusCode, "Response code differs from expected");

                Assert.AreEqual(content.data[0].email, responseBody.data.email,"data[0].email differs from expected");
                Assert.AreEqual(content.data[0].first_name, responseBody.data.first_name,"data[0].first_name differs from expected");
                Assert.AreEqual(content.data[0].last_name, responseBody.data.last_name,"data[0].last_name differs from expected");
                Assert.AreEqual(content.data[0].avatar, responseBody.data.avatar,"data[0].avatar differs from expected");

                Assert.AreEqual(content.support.url, responseBody.support.url,"support.url differs from expected");
                Assert.AreEqual(content.support.text, responseBody.support.text,"support.text differs from expected");
            });
        }

        [Test]
        [Category("Users")]
        [Author("JLR")]
        [Property("TestCaseId", "12347")]
        [TestCaseSource(typeof(ValidateUserNotFoundProvider))]
        [Description("Validate User Not Found")]
        public void ValidateUserNotFound_TC12347(HttpStatusCode ExpectedStatusCode, int userId)
        {
            var response = UserService.GetUserById(userId);
            HttpStatusCode statusCode = response.StatusCode;

            Assert.Multiple(() =>
            {
                var responseBody = JsonConvert.DeserializeObject<SingleUserGetResponse>(response.Content);
                Assert.AreEqual(ExpectedStatusCode, statusCode, "Response code differs from expected");
            });
        }

        //Another way to work with body/payloads using the Newtonsoft fw

        [Test]
        [Category("Users")]
        [Author("JLR")]
        [Property("TestCaseId", "12345_2")]
        [TestCaseSource(typeof(GetUsers2Provider))]
        [Description("Get Users using JObject/object")]
        public void GetUsers_TC12345_2(JObject content, HttpStatusCode ExpectedStatusCode)
        {
            var response = UserService.GetUsers();
            HttpStatusCode statusCode = response.StatusCode;

            Assert.Multiple(() =>
            {
                var responseBody = JsonConvert.DeserializeObject<UserGetResponse>(response.Content);
                Assert.AreEqual(ExpectedStatusCode, statusCode, "Response code differs from expected");

                Assert.AreEqual(int.Parse(content["page"].ToString()), responseBody.page,"page differs from expected");
                Assert.AreEqual(int.Parse(content["per_page"].ToString()), responseBody.per_page,"per_page differs from expected");
                Assert.AreEqual(int.Parse(content["total"].ToString()), responseBody.total,"total differs from expected");
                Assert.AreEqual(int.Parse(content["total_pages"].ToString()), responseBody.total_pages,"total_pages differs from expected");

                Assert.AreEqual(int.Parse(content["data"][0]["id"].ToString()), responseBody.data[0].id,"data[0].id differs from expected");
                Assert.AreEqual(content["data"][0]["email"].ToString(), responseBody.data[0].email,"data[0].email differs from expected");
                Assert.AreEqual(content["data"][0]["first_name"].ToString(), responseBody.data[0].first_name,"data[0].first_name differs from expected");
                Assert.AreEqual(content["data"][0]["last_name"].ToString(), responseBody.data[0].last_name,"data[0].last_name differs from expected");
                Assert.AreEqual(content["data"][0]["avatar"].ToString(), responseBody.data[0].avatar,"data[0].avatar differs from expected");

                Assert.AreEqual(int.Parse(content["data"][1]["id"].ToString()), responseBody.data[1].id,"data[1].id differs from expected");
                Assert.AreEqual(content["data"][1]["email"].ToString(), responseBody.data[1].email,"data[1].email differs from expected");
                Assert.AreEqual(content["data"][1]["first_name"].ToString(), responseBody.data[1].first_name,"data[1].first_name differs from expected");
                Assert.AreEqual(content["data"][1]["last_name"].ToString(), responseBody.data[1].last_name,"data[1].last_name differs from expected");
                Assert.AreEqual(content["data"][1]["avatar"].ToString(), responseBody.data[1].avatar,"data[1].avatar differs from expected");

                Assert.AreEqual(content["support"]["url"].ToString(), responseBody.support.url,"support.url differs from expected");
                Assert.AreEqual(content["support"]["text"].ToString(), responseBody.support.text,"support.text differs from expected");

                Assert.IsTrue(responseBody.data.Exists(p => p.id.Equals(5)), "The user id doesn't exists");
            });
        }


    }
}
