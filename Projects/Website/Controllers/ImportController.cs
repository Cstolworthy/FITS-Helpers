using System.Web.Mvc;
using Interfaces.FITS;

namespace Website.Controllers
{
    public class ImportController : Controller
    {
        private readonly IFitsMapper _fitsMapper;

        public ImportController(IFitsMapper fitsMapper)
        {
            _fitsMapper = fitsMapper;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Waiting()
        {
            return View();
        }
    }
}
