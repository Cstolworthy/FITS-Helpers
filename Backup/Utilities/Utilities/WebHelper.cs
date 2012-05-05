using System;
using System.Web;

namespace Utilities
{
    public static class WebHelper
    {
        public static string BasePath
        {
            get { return BuildPath(HttpContext.Current.Request);}
        }

        private static string BuildPath(HttpRequest request)
        {
            return String.Format("{0}://{1}:{2}{3}/",request.Url.Scheme,request.Url.Host,request.Url.Port, request.ApplicationPath);
        }
    }
}
