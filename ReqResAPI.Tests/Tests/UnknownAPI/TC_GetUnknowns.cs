using System.Net;
using Adapter.ReqResAPI.Models;
using Adapter.ReqResAPI.Services;
using Newtonsoft.Json;
using NUnit.Framework;
using static Adapter.ReqResAPI.API.UnknownRest;
using static ReqResAPI.Tests.TestData.DataProvidersAPI;

namespace ReqResAPI.Tests.Tests.UnknownAPI
{
    public class TC_GetUnknowns
    {
        [Test]
        [Category("Unknowns")]
        [Author("Jose L Rojas")]
        [Property("TestCaseId", "12348")]
        [TestCaseSource(typeof(GetUnknownsProvider))]
        [Description("Get Unknowns")]
        public void GetUnknowns_TC12348(UnknownContent unknownContent, HttpStatusCode ExpectedStatusCode)
        {  
            var response = UnknownService.GetUnknowns();
            HttpStatusCode statusCode = response.StatusCode;

            Assert.Multiple(() =>
            {
                var responseBody = JsonConvert.DeserializeObject<UnknownGetResponse>(response.Content);
                Assert.AreEqual(ExpectedStatusCode, statusCode, "Response code differs from expected");

                Assert.AreEqual(unknownContent.page, responseBody.page,"page differs from expected");
                Assert.AreEqual(unknownContent.per_page, responseBody.per_page,"per_page differs from expected");
                Assert.AreEqual(unknownContent.total, responseBody.total,"total differs from expected");
                Assert.AreEqual(unknownContent.total_pages, responseBody.total_pages,"total_pages differs from expected");

                Assert.AreEqual(unknownContent.data[0].id, responseBody.data[0].id,"data[0].id differs from expected");
                Assert.AreEqual(unknownContent.data[0].name, responseBody.data[0].name,"data[0].name differs from expected");
                Assert.AreEqual(unknownContent.data[0].year, responseBody.data[0].year,"data[0].year differs from expected");
                Assert.AreEqual(unknownContent.data[0].color, responseBody.data[0].color,"data[0].color differs from expected");
                Assert.AreEqual(unknownContent.data[0].pantone_value, responseBody.data[0].pantone_value,"data[0].pantone_value differs from expected");

                Assert.AreEqual(unknownContent.support.url, responseBody.support.url,"support.url differs from expected");
                Assert.AreEqual(unknownContent.support.text, responseBody.support.text,"support.text differs from expected");
            });
        }
    }
}