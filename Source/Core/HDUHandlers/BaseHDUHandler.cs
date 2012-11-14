using System;
using nom.tam.fits;

namespace Core.HDUHandlers
{
    public class BaseHduHandler
    {
        private readonly BasicHDU _hdu;

        public BaseHduHandler(BasicHDU hdu)
         {
             if (hdu == null)
                 throw new ArgumentNullException("Hdu cannot be null");

             _hdu = hdu;
         }
    }
}