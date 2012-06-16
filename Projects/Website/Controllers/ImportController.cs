using System.Web.Mvc;
using Interfaces.FITS;
using Website.Models;
using Website.Properties;

namespace Website.Controllers
{
    public class ImportController : Controller
    {
        private readonly IFitsMapper _fitsMapper;
        private IFitsFileAccess _fileAccess;

        public ImportController(IFitsMapper fitsMapper, IFitsFileAccess fileAccess)
        {
            _fitsMapper = fitsMapper;
            _fileAccess = fileAccess;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Waiting()
        {
            var files = _fileAccess.GetFilesThatAreNotFound(Settings.Default.FitsPath);

            FitsWaitingModel model = new FitsWaitingModel();
            model.Files = files;

            return View(model);
        }

        public ActionResult MarkReadyForImport()
        {
            return View();
        }
    }
}
