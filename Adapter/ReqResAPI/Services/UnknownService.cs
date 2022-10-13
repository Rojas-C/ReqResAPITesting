using Adapter.Core.Web;
using Adapter.ReqResAPI.API;
using log4net;
using NUnit.Framework;
using RestSharp;
using static Adapter.ReqResAPI.API.UnknownRest;

namespace Adapter.ReqResAPI.Services
{
    public class UnknownService
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static string protocol => TestContext.Parameters["Protocol"];
        private static string baseUrl => TestContext.Parameters["BaseUrl"];
        private static string unknownEndpoint => TestContext.Parameters["Path"] + TestContext.Parameters["UnknownResource"];
        private UnknownRest unknownRest;
        private UnknownGetResponse unknownResult;

        public UnknownService()
        {
            var url = ITAFConfig.BuildURL(protocol, baseUrl);
            unknownRest = new UnknownRest(url, unknownEndpoint);
            unknownResult = new UnknownGetResponse();
        }

        public static IRestResponse GetUnknowns()
        {
            var url = ITAFConfig.BuildURL(protocol, baseUrl);
            UnknownService us = new UnknownService();
            us.unknownRest = new UnknownRest(url, unknownEndpoint);

            return us.unknownRest.GetMethod();
        }

        public static IRestResponse GetUnknownById(int unknownId)
        {
            var url = ITAFConfig.BuildURL(protocol, baseUrl);
            UnknownService us = new UnknownService();
            us.unknownRest = new UnknownRest(url, unknownEndpoint + $"/{unknownId}");

            return us.unknownRest.apiRequest(RestSharp.Method.GET);
        }
    }
}
