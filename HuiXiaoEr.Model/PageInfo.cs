using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuiXiaoEr.Model
{
    public class PageInfo
    {
        public object count { get; set; }
        public object data { get; set; }
    }
    public class Join
    {
        public string tableName { get; set; }
        public string shortName { get; set; }
        public string JoinWhere { get; set; }
        public string leftFiled { get; set; }
        public string RightFiled { get; set; }

        public string JoinType { get; set; }
        public SqlSugar.JoinType type
        {
            get
            {
                switch (JoinType)
                {
                    case "INNER":
                        return SqlSugar.JoinType.Inner;
                    case "LEFT":
                        return SqlSugar.JoinType.Left;
                    case "RIGHT":
                        return SqlSugar.JoinType.Right;
                    default:
                        return SqlSugar.JoinType.Inner;
                }
            }
        }
    }
}
