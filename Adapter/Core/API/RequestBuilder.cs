using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;

namespace Adapter.Core.API
{
    ///<summary>
    /// RestRequestBuilder is a helper class library that utilizes Fluent Syntax in order to create
    /// RestRequest objects.
    ///</summary>
    public class RequestBuilder : IRequestBuilder
    {
        #region Private Properties

        private string _resource;
        private Dictionary<string, string> _headers;
        private Dictionary<string, string> _cookies;
        private Dictionary<string, string> _parameters;
        private DataFormat _dataFormat;
        private Method _method;
        private object _body;
        private int _timeOut;

        private string _fileName;
        private string _filePath;
        private string _fileType;

        #endregion Private Properties

        #region Public Properties

        public int HeaderCount => _headers.Count;

        #endregion Public Properties

        #region Public Constructors
        /// <summary>
        /// Public Constructor with string as argument.
        /// </summary>
        /// <param name="resource" ></param>
        public RequestBuilder(string resource)
        {
            if (string.IsNullOrEmpty(resource))
            {
                throw new ArgumentNullException(nameof(resource));
            }

            _resource = resource;
            _headers = new Dictionary<string, string>();
            _parameters = new Dictionary<string, string>();
            _method = Method.GET;
            _dataFormat = DataFormat.Json;
            _cookies = new Dictionary<string, string>();
            _timeOut = 0;

        }
        /// <summary>
        /// Public Constructor with a FormattableString argument.
        /// The string is stored as a string compiled with arguments.
        /// </ summary >
        /// <param name="resource"></ param >
        public RequestBuilder(FormattableString resource)
        {
            if (resource is null)
            {
                throw new ArgumentNullException(nameof(resource));
            }

            _resource = resource.ToString();
            _headers = new Dictionary<string, string>();
            _parameters = new Dictionary<string, string>();
            _method = Method.GET;
            _dataFormat = DataFormat.Json;
            _cookies = new Dictionary<string, string>();
            _timeOut = 0;
        }

        /// <summary>
        /// Public Constructor with a Uri argument.
        /// Uri argument is stored as string.
        /// </summary>
        /// <param name="resource"></ param >
        public RequestBuilder(Uri resource)
        {
            if (resource is null)
            {
                throw new ArgumentNullException(nameof(resource));
            }

            _resource = resource.ToString();
            _headers = new Dictionary<string, string>();
            _parameters = new Dictionary<string, string>();
            _method = Method.GET;
            _dataFormat = DataFormat.Json;
            _cookies = new Dictionary<string, string>();
            _timeOut = 0;

        }

        /// <summary>
        /// RequestBuilder Constructor with <see cref = "Method" /> argument.
        /// </summary>
        /// <param name = "resource" ></ param >
        /// <param name= "method"></param>
        public RequestBuilder(string resource, Method method)
        {
            if (string.IsNullOrEmpty(resource))
            {
                throw new ArgumentNullException(nameof(resource));
            }

            _resource = resource;
            _headers = new Dictionary<string, string>();
            _parameters = new Dictionary<string, string>();
            _method = method;
            _dataFormat = DataFormat.Json;
            _cookies = new Dictionary<string, string>();
            _timeOut = 0;
        }

        /// <summary>
        /// RequestBuilder Constructor with <see cref="Method"/> and <see cref="DataFormat"/> arguments.
        /// </summary>
        /// <param name = "resource" ></ param >
        /// <param name= "method"></param>
        /// <param name= "format"></param>
        public RequestBuilder(string resource, Method method, DataFormat dataFormat)
        {
            if (string.IsNullOrEmpty(resource))
            {
                throw new ArgumentNullException(nameof(resource));
            }

            _resource = resource;
            _headers = new Dictionary<string, string>();
            _parameters = new Dictionary<string, string>();
            _method = method;
            _dataFormat = DataFormat.Json;
            _cookies = new Dictionary<string, string>();
            _timeOut = 0;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Add a serialized object to the IRestRequest.
        /// </summary>
        /// <param name = "body" ></ param >
        /// <returns></returns>
        public IRequestBuilder AddBody(object body)
        {
            if (body is null)
            {
                throw new ArgumentNullException(nameof(body));
            }

            _body = body;
            return this;
        }

        /// <summary>
        /// Adds a file to the RestRequest.
        /// </summary>
        /// <param name "name"></param>
        /// <param name "path"></param>
        /// <param name "contentType"></param>
        /// <returns></returns>
        public IRequestBuilder AddFile(string name, string path, string contentType = null)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            _fileName = name;
            _filePath = path;
            _fileType = contentType;

            return this;
        }

        /// <summary>
        /// Set the DataFormat of the IRequest.
        /// </summary>
        /// <param name "dataFormat"></param>
        /// <returns></returns>
        public IRequestBuilder SetFormat(DataFormat dataFormat)
        {
            _dataFormat = dataFormat;
            return this;
        }

        /// <summary>
        /// Add a Header to the IRestRequest
        /// </summary>
        /// <param name "name"></param>
        /// <param name "value"></param>
        /// <returns></returns>
        public IRequestBuilder AddHeader(string name, string value)
        {
            AddValue(_headers, name, value);

            return this;
        }

        /// <summary>
        /// Add Cookie to Request.
        /// </summary>
        /// <param name "name"></param>
        /// <param name "value"></param>
        /// <returns></returns>
        public IRequestBuilder AddCookie(string name, string value)
        {
            AddValue(_cookies, name, value);

            return this;
        }

        /// <summary>
        /// Add Headers to the IRestRequest.
        /// </summary>
        /// <param name "headers"></param>
        /// <returns></returns>
        public IRequestBuilder AddHeaders(Dictionary<string, string> headers)
        {
            AddValues(_headers, headers);

            return this;
        }

        /// <summary>
        /// Add Headers to the IRestRequest.
        /// </summary>
        /// <param name "method"></param>
        /// <returns></returns>
        public IRequestBuilder SetMethod(Method method)
        {
            _method = method;
            return this;
        }

        /// <summary>
        /// Set the IRestRequest Timeout value.
        /// </summary>
        /// <param name "timeout"></param>
        /// <returns></returns>
        public IRequestBuilder SetTimeout(int timeout)
        {
            if (timeout < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(timeout));
            }

            _timeOut = timeout;
            return this;
        }

        /// <summary>
        /// Add a Parameter to the IRestRequest.
        /// </summary>
        /// <param name "parameter"></param>
        /// <returns></returns>
        public IRequestBuilder AddParameter(string name, string value)
        {
            AddValue(_parameters, name, value);
            return this;
        }

        /// <summary>
        /// Add Parameters to the <see cref="IRestRequest"/> IRestRequest.
        /// </summary>
        /// <param name "parameters"></param>
        /// <returns></returns>
        public IRequestBuilder AddParameters(Dictionary<string, string> parameters)
        {
            AddValues(_parameters, parameters);

            return this;
        }

        /// <summary>
        /// Remove Header by Name.
        /// </summary>
        /// <param name "name"></param>
        /// <returns></returns>
        public IRequestBuilder RemoveHeader(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentOutOfRangeException(nameof(name));
            }

            if (_headers.ContainsKey(name))
            {
                _headers.Remove(name);
            }

            return this;
        }

        /// <summary>
        /// Removes all Headers.
        /// </summary>
        /// <returns></returns>
        public IRequestBuilder RemoveHeaders()
        {
            _headers.Clear();
            return this;
        }

        /// <summary>
        /// Remove Cookies.
        /// </summary>
        /// <returns></returns>
        public IRequestBuilder RemoveCookies()
        {
            _cookies.Clear();
            return this;
        }

        /// <summary>
        /// Remove Parameters.
        /// </summary>
        /// <returns></returns>
        public IRequestBuilder RemoveParameters()
        {
            _parameters.Clear();
            return this;
        }

        /// <summary>
        /// Remove a Parameter.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public IRequestBuilder RemoveParameter(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentOutOfRangeException(nameof(name));
            }

            if (_parameters.ContainsKey(name))
            {
                _parameters.Remove(name);
            }

            return this;
        }

        /// <sumary>
        /// Creates the IRestRequest object.
        /// </sumary>
        /// <returns>IRestRequest</returns>
        public IRestRequest Create()
        {
            var request = new RestRequest(_resource, _method, _dataFormat);

            foreach (var param in _parameters)
            {
                request.AddParameter(param.Key, param.Value);
            }

            if (_body != null)
            {
                request.AddJsonBody(_body);
            }

            foreach (var header in _headers)
            {
                request.AddHeader(header.Key, header.Value);
            }

            foreach (var cookie in _cookies)
            {
                request.AddCookie(cookie.Key, cookie.Value);
            }

            if (!string.IsNullOrEmpty(_fileName) && !string.IsNullOrEmpty(_filePath))
            {
                request.AddFile(_fileName, _filePath, _fileType);
            }

            request.Timeout = _timeOut;

            return request;
        }

        #endregion Public Methods

        private void AddValue(Dictionary<string, string> dict, string name, string value)
        {
            string valueValue = string.Empty;

            if (dict.TryGetValue(name, out valueValue))
            {
                if (value != valueValue)
                {
                    dict[name] = value;
                }
            }
            else
            {
                dict.Add(name, value);
            }
        }

        private void AddValues(Dictionary<string, string> dict, Dictionary<string, string> dictValues)
        {
            foreach (var value in dictValues)
            {
                string valueValue = string.Empty;

                if (dict.TryGetValue(value.Key, out valueValue))
                {
                    if (valueValue != value.Value)
                    {
                        dict[value.Key] = value.Value;
                    }

                    continue;
                }

                dict.Add(value.Key, value.Value);
            }
        }
    }
}