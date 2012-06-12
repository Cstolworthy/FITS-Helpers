using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using Interfaces;

namespace Website
{
    public class UnityControllerFactory : IControllerFactory
    {
        #region IControllerFactory Members

        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            var containerAccessor =
                requestContext.HttpContext.ApplicationInstance as IContainerAccessor;
            CapitalizeControllerName(ref controllerName);
            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            var controllerTypes = from t in currentAssembly.GetTypes()
                                  where t.Name.ToLower().Contains(controllerName.ToLower() + "controller")
                                  select t;

            if (controllerTypes.Count() > 0)
            {
                return containerAccessor.Container.Resolve(controllerTypes.First(), "") as IController;
            }
            else
            {
                return null;
            }
        }

        private void CapitalizeControllerName(ref string controllerName)
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

        public void ReleaseController(IController controller)
        {
            controller = null;
        }

        #endregion
    }
}