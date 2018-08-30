using System;
using System.Linq;
using System.Text;

namespace HuiXiaoEr.Model
{
    ///<summary>
    ///
    ///</summary>
    public partial class Room
    {
           public Room(){


           }
           /// <summary>
           /// Desc:编号ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int RoomID {get;set;}

           /// <summary>
           /// Desc:酒店ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int HotelID {get;set;}

           /// <summary>
           /// Desc:房间名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string RoomName {get;set;}

           /// <summary>
           /// Desc:房间图片
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string RoomImg {get;set;}

           /// <summary>
           /// Desc:房间面积
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int RoomArea {get;set;}

           /// <summary>
           /// Desc:几人间
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int RoomPeople {get;set;}

           /// <summary>
           /// Desc:房间特点
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string RoomLabel {get;set;}

           /// <summary>
           /// Desc:房间价格
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string RoomPrice {get;set;}

           /// <summary>
           /// Desc:添加时间
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime RoomTime {get;set;}

    }
}
