using System;
using FitsLogic;
using Interfaces.DTO;
using Interfaces.FITS;
using log4net;
using nom.tam.fits;

namespace BusinessLogic.FITS
{
    public class FitsFileFileImporter : IFitsFileImporter
    {
        private readonly IFitsFileSystemAccess _fileSystemAccess;
        private readonly string _fitsPath;
        private readonly IFitsMapper _fitsMapper;
        private readonly ILog _logger = Logging.Logging.GetLogger("FitsFileFileImporter");

        public FitsFileFileImporter(IFitsFileSystemAccess fileSystemAccess, string fitsPath, IFitsMapper fitsMapper)
        {
#warning Refactor this so that the IOC provides the fitspath directly to the fileaccess object
            _fileSystemAccess = fileSystemAccess;
            _fitsPath = fitsPath;
            _fitsMapper = fitsMapper;
        }

        public virtual void ScanForNewFiles()
        {
            var files = _fileSystemAccess.GetFilesThatAreNotFound(_fitsPath);

            if (files != null)
            {
                foreach (var fileInfo in files)
                {
                    _fitsMapper.CreateNewFileImportRequest(fileInfo);
                }
            }
        }

        public virtual void ProcessWaitingFiles()
        {
            var files = _fitsMapper.GetFilesWaitingImport();

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

                ReadHdus(fitsFile, fileOptions);
            }
            catch (Exception e)
            {
                _logger.Fatal("Exception while parsing FITS", e);
            }

        }

        public virtual void ReadHdus(Fits fitsFile, IFileImportOptions fileOptions)
        {
            BasicHDU curHdu = null;
            
            while ((curHdu = fitsFile.ReadHDU()) != null)
            {
                BeginImport(curHdu, fileOptions);
            }
        }

        public virtual void BeginImport(BasicHDU curHdu, IFileImportOptions fileOptions)
        {
            _fitsMapper.CreateNewImport(fileOptions);

            if (curHdu is BinaryTableHDU)
                HandleBinaryHDUImport(curHdu as BinaryTableHDU);
        }

        private void HandleBinaryHDUImport(BinaryTableHDU binaryTableHdu)
        {
            for (int i = 0; i < binaryTableHdu.NRows; i++)
            {
                var row = binaryTableHdu.GetRow(i);

                _fitsMapper.CreateNewDocument();

                SetValues(binaryTableHdu, row);

                _fitsMapper.SaveDocument();
            }
        }

        private void SetValues(BinaryTableHDU binaryTableHdu, Array values)
        {
            var columns = binaryTableHdu.GetColumnNames();

            foreach (var keyValuePair in columns)
            {
                var theValue = values.GetValue(keyValuePair.Key);

                _fitsMapper.SetValue(keyValuePair.Value, theValue);
            }
        }
    }
}
