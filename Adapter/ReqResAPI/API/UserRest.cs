using System;
using System.Collections.Generic;
using Adapter.ReqResAPI.Models;
using log4net;
using Newtonsoft.Json;

namespace Adapter.ReqResAPI.API
{
    public class UserRest : APIRest
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public UserRest(string url, string resource) : base(url, resource)
        {

        }

        public class UserGetResponse
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
            public List<Data> data { get; set; }
            [JsonProperty("support")]
            public Support support { get; set; }


            public static implicit operator UserGetResponse(string v)
            {
                throw new NotImplementedException();
            }
        }

        public class SingleUserGetResponse
        {
            [JsonProperty("data")]
            public Data data { get; set; }
            [JsonProperty("support")]
            public Support support { get; set; }


            public static implicit operator SingleUserGetResponse(string v)
            {
                throw new NotImplementedException();
            }
        }

        public class UserPostResponse
        {
            [JsonProperty("name")]
            public string name { get; set; }
            [JsonProperty("job")]
            public string job { get; set; }
            [JsonProperty("id")]
            public string id { get; set; }
            [JsonProperty("createdAt")]
            public string createdAt { get; set; }


            public static implicit operator UserPostResponse(string v)
            {
                throw new NotImplementedException();
            }
        }

        public class UserPatchResponse
        {
            [JsonProperty("name")]
            public string name { get; set; }
            [JsonProperty("job")]
            public string job { get; set; }
            [JsonProperty("updatedAt")]
            public string updatedAt { get; set; }


            public static implicit operator UserPatchResponse(string v)
            {
                throw new NotImplementedException();
            }
        }
    }
}
