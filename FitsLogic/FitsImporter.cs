using System;
using nom.tam.fits;

namespace FitsLogic
{
    public class FitsImporter
    {
        private string _mongoConnectionString;

        public event Action<int> ProgressPercentage;
        public event Action<String> ProgressMessage;

        public void InvokeProgressMessage(string message)
        {
            Action<string> handler = ProgressMessage;
            if (handler != null) handler(message);
        }

        public void InvokeProgressParsing(int progress)
        {
            Action<int> handler = ProgressPercentage;
            if (handler != null) handler(progress);
        }

        public virtual Fits Fits { get; set; }
        public virtual ImageHduHandler ImageHandler { get; set; }
        public virtual BinaryHduHandler BinaryHandler { get; set; }

        public FitsImporter(string mongoConnectionString, string fitsFile)
        {
            _mongoConnectionString = mongoConnectionString;

            ImageHandler = new ImageHduHandler(mongoConnectionString);
            BinaryHandler = new BinaryHduHandler(mongoConnectionString);

            BinaryHandler.Message +=new Action<string>(InvokeProgressMessage);
            BinaryHandler.Progress += new Action<int>(InvokeProgressParsing);

            if (!String.IsNullOrEmpty(fitsFile))
                Fits = new Fits(fitsFile);
        }

        public virtual BasicHDU FetchHduSafely()
        {
            int count = 0;

            if (Fits != null)
            {
                while (count < 10)
                {
                    try
                    {
                        return Fits.ReadHDU();
                    }
                    catch (Exception e)
                    {
                        count++;
                    }
                }

            }

            return null;
        }

        public void Parse(string collectionName)
        {
            BasicHDU curUntypedHdu = FetchHduSafely();
            int lastHdu = 0;
            while (curUntypedHdu != null)
            {
                if (lastHdu == curUntypedHdu.GetHashCode())
                {
                    break;
                }
                lastHdu = curUntypedHdu.GetHashCode();

                if (curUntypedHdu is ImageHDU)
                    ImageHandler.Handle(curUntypedHdu as ImageHDU);
                if (curUntypedHdu is BinaryTableHDU)
                    BinaryHandler.Handle(curUntypedHdu as BinaryTableHDU, collectionName );

                curUntypedHdu = FetchHduSafely();
            }
        }
    }
}
