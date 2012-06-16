using System.Linq;
using System.Web;
using System.Web.Mvc;
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

        public ImportController(IFitsMapper fitsMapper, IFitsFileSystemAccess fileSystemAccess, IFitsManager manager)
        {
            _fitsMapper = fitsMapper;
            _fileSystemAccess = fileSystemAccess;
            _manager = manager;
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
    }
}
