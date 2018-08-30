using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Sylone.Comm;

namespace HuiXiaoEr
{
    public class SyloneAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            LoginAuthorize(filterContext);
        }
        public static void LoginAuthorize(AuthorizationContext filterContext)
        {
            var area = filterContext.RouteData.DataTokens["area"];
            // string controllerName = filterContext.RouteData.Values["controller"].ToString();
            //string actionName = filterContext.RouteData.Values["action"].ToString();
            if (area != null)
            {
                if (SessionHelper.Get("Admin") == null)
                {
                    JavaScriptHelper.AlertAndRedirect("登录超时，请重新登录！", "/");
                    filterContext.Result = new EmptyResult();
                    return;
                }
            }
        }
    }
}