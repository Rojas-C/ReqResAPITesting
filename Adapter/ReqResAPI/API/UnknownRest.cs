using System;
using System.Collections.Generic;
using Adapter.ReqResAPI.Models;
using log4net;
using Newtonsoft.Json;

namespace Adapter.ReqResAPI.API
{
    public class UnknownRest : APIRest
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public UnknownRest(string url, string resource) : base(url, resource)
        {

        }

        public class UnknownGetResponse
        {
            [JsonProperty("page")]
            public int page { get; set; }
            [JsonProperty("per_page")]
            public int per_page { get; set; }
            [JsonProperty("total")]
            public int total { get; set; }
            [JsonProperty("total_pages")]
            public int total_pages { get; set; }
            [JsonProperty("data")]
            public List<UnknownData> data { get; set; }
            [JsonProperty("support")]
            public Support support { get; set; }


            public static implicit operator UnknownGetResponse(string v)
            {
                throw new NotImplementedException();
            }
        }
    }
}