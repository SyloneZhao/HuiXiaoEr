using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Mvc;
using HuiXiaoEr.Model;
using Sylone.Comm;
using Sylone.Service;

namespace HuiXiaoEr.Controllers
{
    public class DefaultController : ControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Login(string adminName, string adminPass)
        {
            try
            {
                Admin admin = new AdminInfoService().Login(adminName, adminPass);
                if (admin != null)
                {
                    SessionHelper.Set("Admin", admin);
                }
                return Success("登录成功");
            }
            catch (Exception ex)
            {
                LogHelper.Error("/Default/Login", ex.Message);
                return Error(ex.Message);
            }
        }
        public ActionResult Show() {
            return View();
        }
    }
}