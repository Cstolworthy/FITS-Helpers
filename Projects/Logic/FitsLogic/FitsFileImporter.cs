using System;
using Interfaces;
using Interfaces.FITS;
using log4net;
using nom.tam.fits;

namespace FitsLogic
{
    public class FitsFileFileImporter : IFitsFileImporter
    {
        private readonly IFitsFileAccess _fileAccess;
        private readonly string _fitsPath;
        private readonly IFitsRepository _fitsRepository;
        private readonly ILog _logger = Logging.Logging.GetLogger("FitsFileFileImporter");

        public FitsFileFileImporter(IFitsFileAccess fileAccess, string fitsPath, IFitsRepository fitsRepository)
        {
            _fileAccess = fileAccess;
            _fitsPath = fitsPath;
            _fitsRepository = fitsRepository;
        }

        public virtual void ProcessWaitingFiles()
        {
            var files = _fitsRepository.GetFilesWaitingImport();

            foreach (var fileInfo in files)
            {
                ProcessIndividualFile(fileInfo);
            }
        }

        public virtual void ProcessIndividualFile(IFileImportOptions fileOptions)
        {
            try
            {
                var fitsFile = new Fits(fileOptions.FilePath);

                ReadHdus(fitsFile);
            }
            catch (Exception e)
            {
                _logger.Fatal("Exception while parsing FITS", e);
            }

        }

        public void ReadHdus(Fits fitsFile)
        {
            BasicHDU curHdu = null;

            while ((curHdu = fitsFile.ReadHDU()) != null)
            {
                BeginImport(curHdu);
            }
        }

        public void BeginImport(BasicHDU curHdu)
        {
            _fitsRepository.CreateNewImport(curHdu);

            if (curHdu is BinaryTableHDU)
                HandleBinaryHDUImport(curHdu as BinaryTableHDU);
        }

        private void HandleBinaryHDUImport(BinaryTableHDU binaryTableHdu)
        {
            
        }
    }
}
