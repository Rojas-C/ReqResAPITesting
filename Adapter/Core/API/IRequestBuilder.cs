using System;
using System.Collections.Generic;
using RestSharp;

namespace Adapter.Core.API
{
    public interface IRequestBuilder
    {
        int HeaderCount { get; }
        IRequestBuilder AddCookie(string name, string value);
        IRequestBuilder AddHeader(string name, string value);
        IRequestBuilder AddHeaders(Dictionary<string, string> headers);
        IRequestBuilder SetTimeout(int timeout);
        IRequestBuilder SetMethod(Method method);
        IRequestBuilder AddParameter(string name, string value);
        IRequestBuilder AddParameters(Dictionary<string, string> parameters);
        IRequestBuilder RemoveHeaders();
        IRequestBuilder RemoveHeader(string name);
        IRequestBuilder RemoveCookies();
        IRequestBuilder RemoveParameters();
        IRequestBuilder RemoveParameter(string name);
        IRequestBuilder SetFormat(DataFormat dataFormat);
        IRequestBuilder AddBody(object body);
        IRequestBuilder AddFile(string name, string path, string contentType = null);
        IRestRequest Create();

    }
}
