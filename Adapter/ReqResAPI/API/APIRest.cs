using System;
using System.Collections.Generic;
using Adapter.Core.API;
using log4net;
using RestSharp;

namespace Adapter.ReqResAPI.API
{
    public class APIRest : APIBase
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public APIRest(string url, string resource) : base(url, resource)
        {

        }

        public IRestResponse apiRequest(Method requestType, object requestBody = null, Dictionary<string, string> requestHeaders = null)
        {
            RestRequest
                .SetFormat((DataFormat)requestType)
                .SetFormat(DataFormat.Json)
                .AddHeaders(CommonHeaders());

            if (requestHeaders != null)
            {
                RestRequest.AddHeaders(requestHeaders);
            }
            if (requestBody != null)
            {
                RestRequest.AddBody(requestBody);
            }

            restResponse = Execute();

            return restResponse;
        }

        public IRestResponse GetMethod()
        {
            RestRequest
                .SetFormat(DataFormat.Json)
                .SetMethod(Method.GET)
                .AddHeaders(CommonHeaders());

            restResponse = Execute();

            return restResponse;
        }

        public IRestResponse PostMethod(object body)
        {
            RestRequest
                .SetFormat(DataFormat.Json)
                .SetMethod(Method.POST)
                .AddHeaders(CommonHeaders())
                .AddBody(body);

            restResponse = Execute();
            return restResponse;
        }

        public IRestResponse PatchMethod(object body)
        {
            RestRequest
                .SetFormat(DataFormat.Json)
                .SetMethod(Method.PATCH)
                .AddHeaders(CommonHeaders())
                .AddBody(body);

            restResponse = Execute();
            return restResponse;
        }

        private Dictionary<string, string> CommonHeaders()
        {
            return new Dictionary<string, string>()
            {
                { "Accept","*/*" },
                // { "Accept-Encoding","gzip, deflate, br" }, //I Comented this line in order to don't accept gzip/compressed-Encrypted responses
                { "Connection","keep-alive" },
                { "X-Correlation-Id","1234" }
            };
        }
    }
}
