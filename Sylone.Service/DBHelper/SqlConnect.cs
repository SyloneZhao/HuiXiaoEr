using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;
using System.Configuration;
using Sylone.Comm;

namespace Sylone.Service
{
    public class SqlConnect
    {
        //禁止实例化
        private SqlConnect()
        {

        }
        public static string ConnectionString
        {
            get
            {
                string reval = ConfigHelper.GetConnectionStrings("dbContext");
                return reval;
            }
        }
        public static SqlSugarClient GetInstance()
        {
            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig() {
                ConnectionString = ConnectionString,
                DbType = DbType.SqlServer,
                IsAutoCloseConnection = true
            });
            db.Ado.IsEnableLogEvent = false;
            db.Ado.LogEventStarting = (sql, pars) =>
            {
                StringBuilder sqls = new StringBuilder();
                sqls.Append("sql:" + sql);
                if (pars != null)
                {
                    sqls.Append(" params:" + db.Utilities.SerializeObject(pars));
                }
                LogHelper.Info("sql", sqls.ToString());
            };
            return db;
        }
    }
}
