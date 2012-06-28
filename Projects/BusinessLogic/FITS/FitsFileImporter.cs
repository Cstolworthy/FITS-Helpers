using System;
using System.Threading.Tasks;
using BusinessLogic.Factories;
using BusinessLogic.Properties;
using FitsLogic;
using Interfaces.DTO;
using Interfaces.FITS;
using log4net;
using MongoDB.Bson;
using nom.tam.fits;

namespace BusinessLogic.FITS
{
    public class FitsFileFileImporter : IFitsFileImporter
    {
        private readonly IFitsFileSystemAccess _fileSystemAccess;
        private readonly string _fitsPath;
        private readonly IFitsMapper _fitsMapper;
        private readonly DtoFactory _dtoFactory;
        private readonly ILog _logger = Logging.Logging.GetLogger("FitsFileFileImporter");

        public FitsFileFileImporter(IFitsFileSystemAccess fileSystemAccess, IFitsMapper fitsMapper, DtoFactory dtoFactory)
        {
#warning Refactor this so that the IOC provides the fitspath directly to the fileaccess object
            _fileSystemAccess = fileSystemAccess;
            _fitsPath = Settings.Default.FitsPath;
            _fitsMapper = fitsMapper;
            _dtoFactory = dtoFactory;
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

        //        public virtual void ProcessWaitingFiles()
        //        {
        //            var files = _fitsMapper.GetFilesWaitingImport();
        //
        //            foreach (var fileInfo in files)
        //            {
        //                ProcessIndividualFile(fileInfo);
        //            }
        //        }

        public virtual void ProcessIndividualFile(IFileImportRequest fileOptions)
        {
            try
            {
                var fitsFile = new Fits(fileOptions.FileNameAndPath);

                ReadHdus(fitsFile, fileOptions);
            }
            catch (Exception e)
            {
                _logger.Fatal("Exception while parsing FITS", e);
            }

        }

        public virtual void ReadHdus(Fits fitsFile, IFileImportRequest fileOptions)
        {
            BasicHDU curHdu = null;

            while ((curHdu = fitsFile.ReadHDU()) != null)
            {
                BeginImport(curHdu, fileOptions);
            }
        }

        public virtual void BeginImport(BasicHDU curHdu, IFileImportRequest fileOptions)
        {
            _fitsMapper.CreateNewImport(fileOptions);

            if (curHdu is BinaryTableHDU)
                HandleBinaryHDUImport(curHdu as BinaryTableHDU);


        }

        private void Foo()
        {

        }

        private void HandleBinaryHDUImport(BinaryTableHDU binaryTableHdu)
        {
            int rows = binaryTableHdu.NRows;

            int count = 0;
            Parallel.For<long>(0, rows, () => 0, (j, loop, subtotal) =>
            {
                var row = binaryTableHdu.GetRow(j);


                BsonDocument doc = new BsonDocument();
                
                SetValues(binaryTableHdu, row, doc);

                _fitsMapper.SaveDocument(doc);

                return 0;
            },
                  (x) => Foo()//Interlocked.Add(ref total, x)
              );

//            for (int i = 0; i < rows; i++)
//            {
//                var row = binaryTableHdu.GetRow(i);
//
//                _fitsMapper.CreateNewDocument();
//
//                SetValues(binaryTableHdu, row);
//
//                _fitsMapper.SaveDocument();
//            }
        }

        private void SetValues(BinaryTableHDU binaryTableHdu, Array values, BsonDocument doc)
        {
            var columns = binaryTableHdu.GetColumnNames();

            foreach (var keyValuePair in columns)
            {
                var theValue = values.GetValue(keyValuePair.Key);

                var val = BsonValue.Create(theValue);
                doc[keyValuePair.Value] = val;
            }
        }

        private void SetValues(BinaryTableHDU binaryTableHdu, Array values)
        {
            var columns = binaryTableHdu.GetColumnNames();

            foreach (var keyValuePair in columns)
            {
                var theValue = values.GetValue(keyValuePair.Key);

                var val = BsonValue.Create(theValue);
                _fitsMapper.SetValue(keyValuePair.Value, val);
            }
        }
    }
}
