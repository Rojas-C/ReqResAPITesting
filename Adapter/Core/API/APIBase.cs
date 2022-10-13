using System;
using RestSharp;
namespace Adapter.Core.API
{
    public class APIBase
    {
        protected IRequestBuilder RestRequest { get; set; }
        protected IRestResponse restResponse;
        protected IRestClient restClient;

        public APIBase(string url, string resource)
        {
            restClient = new RestClient();
            restClient.BaseUrl = new Uri(url);
            restClient.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

            RestRequest = new RequestBuilder(resource);
            restResponse = new RestResponse();
        }

        public IRestResponse Execute()
        {
            var restReq = RestRequest.Create();
            restResponse = restClient.Execute(restReq);
            return restResponse;
        }
    }
}
