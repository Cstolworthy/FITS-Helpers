using System;
using System.Collections.Generic;
using nom.tam.fits;

namespace FitsLogic
{
    public class ImageHduHandler
    {
        private string _connectionString;

        public ImageHduHandler(string mongoConnectionString)
        {
            _connectionString = mongoConnectionString;
        }

        public virtual void Handle(ImageHDU hdu)
        {
            if (hdu.Tiler != null)
            {
                var imageObj = hdu.Tiler.CompleteImage;

                if (imageObj != null)
                {
                    if (imageObj is Array)
                    {
                        foreach (var index in imageObj as Array)
                        {
                            HandleImageData(index as Array);
                        }
                    }
                }
            }
        }

        public void HandleImageData(Array index)
        {
            var documents = new List<string>();

            foreach (var obj in index)
            {
                if (obj is Array)
                {
                    var cast = obj as Array;
                    var val = cast.GetValue(0);

                    if (val is Array)
                    {
                        HandleImageData(obj as Array);
                    }
                    else
                    {
                        var token = SaveImageData(cast);
                        documents.Add(token);
                    }
                }
                else
                {
                    var token = SaveImageData(index);
                    documents.Add(token);
                }
            }
        }

        public virtual string SaveImageData(Array cast)
        {
            return "";
        }
    }
}
