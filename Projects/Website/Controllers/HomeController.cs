using System.Web.Mvc;
using Interfaces.DataAccess;

namespace Website.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
