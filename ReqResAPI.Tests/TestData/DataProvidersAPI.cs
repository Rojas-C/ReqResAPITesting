using System;
using System.Collections.Generic;
using System.Net;
using Adapter.Core.Test;
using Adapter.ReqResAPI.Models;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace ReqResAPI.Tests.TestData
{
    public class DataProvidersAPI
    {
        public class GetUsersProvider : ItemTestCaseProvider
        {
            private static string jsonPath = "TestData/ReqResAPIData.json";
            public override IEnumerator<ITestCaseData> GetEnumerator()
            {
                var root = Root.ListFromJsonFile(jsonPath);

                foreach (var TC12345 in root.GetUsers_TC12345)
                {
                    yield return new TestCaseData(
                        TC12345.content,
                        HttpStatusCode.OK
                    ).SetName(TC12345.name);
                }
            }
        }

        public class GetSingleUserProvider : ItemTestCaseProvider
        {
            private static string jsonPath = "TestData/ReqResAPIData.json";
            public override IEnumerator<ITestCaseData> GetEnumerator()
            {
                var root = Root.ListFromJsonFile(jsonPath);

                foreach (var TC12346 in root.GetSingleUser_TC12346)
                {
                    yield return new TestCaseData(
                        TC12346.content,
                        HttpStatusCode.OK,
                        TC12346.content.data[0].id
                    ).SetName(TC12346.name);
                }
            }
        }

        public class ValidateUserNotFoundProvider : ItemTestCaseProvider
        {
            private static string jsonPath = "TestData/ReqResAPIData.json";
            public override IEnumerator<ITestCaseData> GetEnumerator()
            {
                var root = Root.ListFromJsonFile(jsonPath);

                foreach (var TC12347 in root.ValidateUserNotFound_TC12347)
                {
                    yield return new TestCaseData(
                        HttpStatusCode.NotFound,
                        TC12347.content.data[0].id
                    ).SetName(TC12347.name);
                }
            }
        }

        public class GetUnknownsProvider : ItemTestCaseProvider
        {
            private static string jsonPath = "TestData/ReqResAPIData.json";
            public override IEnumerator<ITestCaseData> GetEnumerator()
            {
                var root = Root.ListFromJsonFile(jsonPath);

                foreach (var TC12348 in root.GetUnknowns_TC12348)
                {
                    yield return new TestCaseData(
                        TC12348.unknownContent,
                        HttpStatusCode.OK
                    ).SetName(TC12348.name);
                }
            }
        }

        public class CreateUserProvider : ItemTestCaseProvider
        {
            private static string jsonPath = "TestData/ReqResAPIData.json";
            public override IEnumerator<ITestCaseData> GetEnumerator()
            {
                var root = Root.ListFromJsonFile(jsonPath);

                foreach (var TC12349 in root.CreateUser_TC12349)
                {
                    yield return new TestCaseData(
                        TC12349.user,
                        TC12349.userContent,
                        HttpStatusCode.Created
                    ).SetName(TC12349.name);
                }
            }
        }

        public class PatchUserProvider : ItemTestCaseProvider
        {
            private static string jsonPath = "TestData/ReqResAPIData.json";
            public override IEnumerator<ITestCaseData> GetEnumerator()
            {
                var root = Root.ListFromJsonFile(jsonPath);

                foreach (var TC12350 in root.PatchUser_TC12350)
                {
                    yield return new TestCaseData(
                        TC12350.user,
                        TC12350.patchUserPayload,
                        HttpStatusCode.OK
                    ).SetName(TC12350.name);
                }
            }
        }

        public class GetUsers2Provider : ItemTestCaseProvider
        {
            private static string jsonPath = "TestData/ReqResAPIData.json";
            public override IEnumerator<ITestCaseData> GetEnumerator()
            {
                var root = Root.ListFromJsonFile(jsonPath);

                foreach (var TC12345_2 in root.GetUsers_TC12345_2)
                {
                    yield return new TestCaseData(
                        TC12345_2.content,
                        HttpStatusCode.OK
                    ).SetName(TC12345_2.name);
                }
            }
        }

        public class CreateUserNoJobProvider : ItemTestCaseProvider
        {
            private static string jsonPath = "TestData/ReqResAPIData.json";
            public override IEnumerator<ITestCaseData> GetEnumerator()
            {
                var root = Root.ListFromJsonFile(jsonPath);

                foreach (var TC12351 in root.CreateUserNoJob_TC12351)
                {
                    yield return new TestCaseData(
                        TC12351.user,
                        TC12351.userContent,
                        HttpStatusCode.Created
                    ).SetName(TC12351.name);
                }
            }
        }

        public class CreateUserFakeDataProvider : ItemTestCaseProvider
        {
            private static string jsonPath = "TestData/ReqResAPIData.json";
            public override IEnumerator<ITestCaseData> GetEnumerator()
            {
                var root = Root.ListFromJsonFile(jsonPath);

                foreach (var TC12352 in root.CreateUserFakeData_TC12352)
                {
                    yield return new TestCaseData(
                        Faker.Name.First(),
                        Faker.Country.Name(),
                        HttpStatusCode.Created
                    ).SetName(TC12352.name);
                }
            }
        }
        

        public DataProvidersAPI()
        {
        }
    }
}
