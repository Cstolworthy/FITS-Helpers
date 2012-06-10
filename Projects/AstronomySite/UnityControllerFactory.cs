using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace AstronomySite
{
    public class UnityControllerFactory : IControllerFactory
    {
        #region IControllerFactory Members

        public IController CreateController(RequestContext requestContext, string controllerName)
        {
           
                var containerAccessor =
                    requestContext.HttpContext.ApplicationInstance as IContainerAccessor;
                NormalizeControllerName(ref controllerName);
                Assembly currentAssembly = Assembly.GetExecutingAssembly();
                var controllerTypes = from t in currentAssembly.GetTypes()
                                      where t.Name.ToLower().Contains(controllerName.ToLower() + "controller")
                                      select t;

                if (controllerTypes.Count() > 0 && containerAccessor != null)
                {
                    return containerAccessor.Container.Resolve(controllerTypes.First(), "") as IController;
                }

//           
//            requestContext.HttpContext.Response.StatusCode = 404;
//            requestContext.HttpContext.Response.End();
            return null;
        }

        private static void NormalizeControllerName(ref string controllerName)
        {
            if (String.IsNullOrWhiteSpace(controllerName))
                return;


            controllerName = controllerName.ToLower();
            controllerName = char.ToUpper(controllerName[0]) + controllerName.Substring(1);

        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }

        // ReSharper disable RedundantAssignment
        public void ReleaseController(IController controller)
        // ReSharper restore RedundantAssignment
        {
            // ReSharper disable RedundantAssignment
            controller = null;
            // ReSharper restore RedundantAssignment
        }

        #endregion
    }
}