using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Website.Content.Services
{
    /// <summary>
    /// Summary description for DocumentUpload
    /// </summary>
    public class DocumentUpload : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string filePath = Path.Combine("c:\\temp\\", "UploadedFile.pdf");
            SaveRequestBodyAsFile(context.Request, filePath);
            context.Response.Write("Document uploaded!");
        }

        private static void SaveRequestBodyAsFile(HttpRequest request, string filePath)
        {
            using (FileStream fileStream = File.Open(filePath, FileMode.Create, FileAccess.Write))
            using (Stream requestStream = request.InputStream)
            {
                int bufferSize = 1024;
                byte[] buffer = new byte[bufferSize];
                int byteCount = 0;
                while ((byteCount = requestStream.Read(buffer, 0, bufferSize)) > 0)
                {
                    fileStream.Write(buffer, 0, byteCount);
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}