using Core.HDUHandlers;
using nom.tam.fits;

namespace Core
{
    public class FitsImporter
    {
        private readonly string _filePath;
        private Fits _fits;

        public FitsImporter(string filePath)
        {
            _filePath = filePath;
            _fits = new Fits(filePath);
        }

        public void ImportFits()
        {
            BasicHDU curHdu;
            while ((curHdu = _fits.ReadHDU()) != null)
            {
                var handler = GetHandler(curHdu);
            }
        }

        private BaseHduHandler GetHandler(BasicHDU curHdu)
        {
            if (curHdu is ImageHDU)
                return new ImageHduHandler(curHdu as ImageHDU);
            if (curHdu is TableHDU)
                return new TableHduHandler(curHdu as TableHDU);

            return null;
        }
    }
}