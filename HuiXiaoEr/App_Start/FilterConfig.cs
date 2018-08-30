using System.Web.Mvc;

namespace HuiXiaoEr
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new SyloneAuthorizeAttribute());
        }
    }
}