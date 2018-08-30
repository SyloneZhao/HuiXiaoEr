using System;
using System.Linq;
using System.Text;

namespace HuiXiaoEr.Model
{
    ///<summary>
    ///
    ///</summary>
    public partial class Book
    {
           public Book(){


           }
           /// <summary>
           /// Desc:编号ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int BookID {get;set;}

           /// <summary>
           /// Desc:开始时间
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime BookStart {get;set;}

           /// <summary>
           /// Desc:结束时间
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime BookEnd {get;set;}

           /// <summary>
           /// Desc:参会人数
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string BookNum {get;set;}

           /// <summary>
           /// Desc:会议预算
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string BookPrice {get;set;}

           /// <summary>
           /// Desc:会议类型
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string BookType {get;set;}

           /// <summary>
           /// Desc:会议需求
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string BookMemo {get;set;}

           /// <summary>
           /// Desc:联系电话
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string BookPhone {get;set;}

           /// <summary>
           /// Desc:注意事项
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string BookNote {get;set;}

           /// <summary>
           /// Desc:提交时间
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime BookTime {get;set;}

    }
}
