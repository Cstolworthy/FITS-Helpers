using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Content.Services
{
    /// <summary>
    /// Summary description for MapHandler
    /// </summary>
    public class MapHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var queryString = context.Request.QueryString;

//            return "/Content/Services/Maphandler.ashx?" + "zoom=" + zoom + "&x=" + coord.x + "&y=" + coord.y + "&client=api&lon=" + va + "&lat=" + ua;
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}