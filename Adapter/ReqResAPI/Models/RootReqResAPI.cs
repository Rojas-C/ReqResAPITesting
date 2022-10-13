using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Adapter.ReqResAPI.Models
{
    public class GetUsersTC12345
    {
        public string id { get; set; }
        public string name { get; set; }
        public Content content { get; set; }
    }

    public class GetUnknowns_TC12348
    {
        public string id { get; set; }
        public string name { get; set; }
        public UnknownContent unknownContent { get; set; }
    }

    public class CreateUser_TC12349
    {
        public string id { get; set; }
        public string name { get; set; }
        public User user { get; set; }
        public UserContent userContent { get; set; }
    }

    public class PatchUser_TC12350
    {
        public string id { get; set; }
        public string name { get; set; }
        public object user { get; set; }
        public object patchUserPayload { get; set; }
    }

    public class GetUsers_TC12345_2
    {
        public string id { get; set; }
        public string name { get; set; }
        public object content { get; set; }
    }

    public class CreateUserFakeData_TC12352
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Root
    {
        public List<GetUsersTC12345> GetUsers_TC12345 { get; set; }
        public List<GetUsersTC12345> GetSingleUser_TC12346 { get; set; }
        public List<GetUsersTC12345> ValidateUserNotFound_TC12347 { get; set; }
        public List<GetUnknowns_TC12348> GetUnknowns_TC12348 { get; set; }
        public List<CreateUser_TC12349> CreateUser_TC12349 { get; set; }
        public List<PatchUser_TC12350> PatchUser_TC12350 { get; set; }
        public List<GetUsers_TC12345_2> GetUsers_TC12345_2 { get; set; }
        public List<CreateUser_TC12349> CreateUserNoJob_TC12351 { get; set; }
        public List<CreateUserFakeData_TC12352> CreateUserFakeData_TC12352 { get; set; }

        public static Root ListFromJsonFile(string jsonFileName)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), jsonFileName);
            return JsonConvert.DeserializeObject<Root>(File.ReadAllText(path));
        }
    }
}
