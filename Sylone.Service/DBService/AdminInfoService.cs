using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SqlSugar;
using HuiXiaoEr.Model;
using Sylone.Comm;

namespace Sylone.Service
{
    public class AdminInfoService
    {
        private SqlSugarClient db = SqlConnect.GetInstance();

        public Admin Login(string adminName,string adminPass)
        {

            Admin admin = db.Queryable<Admin>().First(a => a.AdminName == adminName);
            if (admin != null)
            {
                string password = MD5Encrypt.GetStrMD5(DESDEncrypt.Encrypt(adminPass));
                if (password == admin.AdminPass.ToString())
                {
                    return admin;
                }
                else
                {
                    throw new Exception("密码不正确，请重新输入");
                }
            }
            else
            {
                throw new Exception("账户不存在，请重新输入");
            }
        }
    }
}
