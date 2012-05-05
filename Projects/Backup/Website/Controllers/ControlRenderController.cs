using System;
using System.Web.Mvc;
using Interfaces.Website.Model;
using Microsoft.Practices.Unity;
using Utilities;

namespace Website.Controllers
{
    public class ControlRenderController : Controller
    {
        private IUnityContainer _container;

        public ControlRenderController(IUnityContainer container)
        {
            _container = container;
        }

        public PartialViewResult Index()
        {
            var controlName = Request.QueryString["control"];
            var model = _container.Resolve<IProcessModel>();

            return PartialView(controlName, model);
        }

    }
}
