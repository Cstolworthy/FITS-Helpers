using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Web;

namespace Website.Controllers
{
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class DocumentsResource
    {
        [WebGet(UriTemplate = "*")]
        public Stream Get()
        {
            var segments = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.WildcardPathSegments;
            string file = String.Join("\\", segments);
            if(file != "")
            {
                var path = System.Web.HttpContext.Current.Server.MapPath(@"\");
                path = string.Format(@"{0}{1}{2}", path, "bin\\documents\\", file);
                FileStream stream = new FileStream(path,FileMode.Open,FileAccess.Read);
                return stream;
            }
            return null;
        }

        [WebInvoke(UriTemplate = "*", Method = "POST")]
        public void Post(Stream document)
        {
            var context = WebOperationContext.Current;
            var requestUri = context.IncomingRequest.UriTemplateMatch.RequestUri.AbsoluteUri;

            var segments = context.IncomingRequest.UriTemplateMatch.WildcardPathSegments;

            string file = string.Join("\\", segments);

            var path = System.Web.HttpContext.Current.Server.MapPath(@"\");
            path = string.Format(@"{0}{1}{2}", path, "bin\\documents\\", file);
            var directory = Path.GetDirectoryName(path);

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            FileStream stream = new FileStream(path,FileMode.Create);
            document.CopyTo(stream);
            document.Close();

            context.OutgoingResponse.StatusCode = HttpStatusCode.Created;
            context.OutgoingResponse.Location = requestUri;

        }
    }
}