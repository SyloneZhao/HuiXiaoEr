using Microsoft.VisualStudio.TestTools.UnitTesting;
using SqlSugar;

namespace Sylone.Service.DBHelper.Tests
{
    [TestClass()]
    public class SqlConnectTests
    {
        [TestMethod()]
        public void GetInstanceTest()
        {
            
            SqlSugarClient db = SqlConnect.GetInstance();
            db.DbFirst.CreateClassFile("G:/网站/01/会小二/WEB/HuiXiaoEr/HuiXiaoEr.Model", "HuiXiaoEr.Model");
        }
    }
}