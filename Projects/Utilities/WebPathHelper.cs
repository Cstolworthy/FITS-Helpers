using System.Web;

namespace Utilities
{
    public static class WebPathHelper
    {
        public const string HttpPattern = "{0}://{1}:{2}/";

        public static string BasePath
        {
            get
            {
                var req = HttpContext.Current.Request;

                return string.Format(HttpPattern, req.Url.Scheme, req.Url.Host, req.Url.Port);
            }
        }
    }
}
