using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using log4net;

namespace Adapter.Core.Web
{
    public class ITAFConfig
    {
        protected static readonly ILog log = LogManager.GetLogger(typeof(ITAFConfig));

        public static List<string> GetAttributes(string sectionGroup, string section)
        {
            var appSettings = ConfigurationManager.GetSection(sectionGroup + "/" + section) as NameValueCollection;
            var list = new List<string>();

            if (!appSettings.HasKeys())
            {
                log.Warn("Section " + sectionGroup + "/" + section + " does not have any parameters");
                return null;
            }
            else
            {
                foreach (var key in appSettings.AllKeys)
                {
                    list.Add(appSettings[key]);
                }
                log.Debug("List of properties get from" + sectionGroup + "/" + section + ": " + appSettings.ToString());
                return list;
            }
        }

        public static string BuildURL(string protocol, string url)
        {
            UriBuilder uriBuilder = new UriBuilder();

            uriBuilder.Scheme = protocol;
            uriBuilder.Host = url;
            //uriBuilder.Port = Int32.Parse(port);

            return uriBuilder.Uri.AbsoluteUri;
        }
    }
}
