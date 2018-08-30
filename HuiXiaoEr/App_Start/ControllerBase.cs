using System.Web.Mvc;
using HuiXiaoEr.Model;

namespace HuiXiaoEr
{
    public class ControllerBase : Controller
    {
        protected virtual JsonResult Success(string message)
        {
            return Json(new ResultInfo { state = ResultType.success.ToString(), message = message });
        }
        protected virtual JsonResult Success(string message, object data)
        {
            return Json(new ResultInfo { state = ResultType.success.ToString(), message = message, data = data });
        }
        protected virtual JsonResult Error(string message)
        {
            return Json(new ResultInfo { state = ResultType.error.ToString(), message = message });
        }
    }
}