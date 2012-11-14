using System;
using nom.tam.fits;

namespace Core.HDUHandlers
{
    public class ImageHduHandler : BaseHduHandler
    {
        public ImageHduHandler(ImageHDU hdu) : base(hdu)
        {
        }
    }
}