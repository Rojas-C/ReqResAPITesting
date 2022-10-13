using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Adapter.ReqResAPI.Models
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class Data
    {
        public int id { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string avatar { get; set; }
    }

    public class Support
    {
        public string url { get; set; }
        public string text { get; set; }
    }

    public class Content
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public List<Data> data { get; set; }
        public Support support { get; set; }
    }

    public class UnknownData
    {
        public int id { get; set; }
        public string name { get; set; }
        public string year { get; set; }
        public string color { get; set; }
        public string pantone_value { get; set; }
    }

    public class UnknownContent
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public List<UnknownData> data { get; set; }
        public Support support { get; set; }
    }  

    public class User
    {
        public string name { get; set; }
        public string job { get; set; }
    }

    public class UserFakers
    {
        public UserFakers(string name, string job)
        {
            this.name = name;
            this.job = job;
        }

        public string name { get; set; }
        public string job { get; set; }
    }

    public class UserContent
    {
        public string name { get; set; }
        public string job { get; set; }
        public string id { get; set; }
        public string createdAt { get; set; }
    }
}
