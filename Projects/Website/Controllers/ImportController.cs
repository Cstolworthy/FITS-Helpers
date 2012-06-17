using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic.Factories;
using Interfaces.FITS;
using Website.Models;
using Website.Properties;

namespace Website.Controllers
{
    public class ImportController : Controller
    {
        private readonly IFitsMapper _fitsMapper;
        private IFitsFileSystemAccess _fileSystemAccess;
        private IFitsManager _manager;
        private readonly FileImportRequestFactory _importRequestFactory;

        public ImportController(IFitsMapper fitsMapper, IFitsFileSystemAccess fileSystemAccess, IFitsManager manager, FileImportRequestFactory importRequestFactory)
        {
            _fitsMapper = fitsMapper;
            _fileSystemAccess = fileSystemAccess;
            _manager = manager;
            _importRequestFactory = importRequestFactory;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Waiting()
        {
            var files = _fileSystemAccess.GetFilesThatAreNotFound(Settings.Default.FitsPath);

            FitsWaitingModel model = new FitsWaitingModel();
            model.Files = files;

            return View(model);
        }

        public ActionResult MarkReadyForImport()
        {
            var fileName = Request.QueryString["fileid"];

            var files = _fileSystemAccess.GetFilesThatAreNotFound(Settings.Default.FitsPath);

            var theFile = files.Where(f => f.Name == fileName).FirstOrDefault();

            var columns = _manager.GetColumnHeaders(theFile);

            MarkReadyForImportModel model = new MarkReadyForImportModel();

            model.ColumnNames = columns;

            return View(model);
        }

   
        public ActionResult SaveNewImport()
        {
            var raColumn = Request.Params["raSelect"];
            var decColumn = Request.Params["decSelect"];

            var request = _importRequestFactory.Create(raColumn, decColumn);

            var files = _fileSystemAccess.GetFilesThatAreNotFound(Settings.Default.FitsPath);

            var fileInfo = files.Where(f => f.Name == Request.Params["file"]).FirstOrDefault();

            if(fileInfo != null)
            {
                request.FileNameAndPath = fileInfo.FullName;

                _fitsMapper.SaveNewFileImportRequest(request);
                return Success();
            }



            return MarkReadyForImport();
        }

        private ActionResult Success()
        {
            return View();
        }
    }
}
