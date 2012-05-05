using System.IO;
using System.Net;
using System.Web.Mvc;
using Interfaces.Website;
using Interfaces.Website.Model;
using InterfacesAndDto.Repositories;
using Microsoft.Practices.Unity;

namespace Website.Controllers
{
    [HandleError]
    public class ImporterController : Controller
    {
        private IUnityContainer _container;

        private IFitsDataRepository _repository;
        public IFitsDataRepository Repository
        {
            get { return _repository ?? (_repository = _container.Resolve<IFitsDataRepository>()); }
        }

        public ImporterController(IUnityContainer container)
        {
            _container = container;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Designate()
        {
            var file = Request.QueryString["file"];
            var model = _container.Resolve<IDesignateModel>();
            model.SelectedFile = file;
            return View(model);
        }

        public ActionResult Process()
        {
            var model = _container.Resolve<IProcessModel>();

            return View(model);
        }



    }
}
