using System;
using System.Linq;
using System.Text;

namespace HuiXiaoEr.Model
{
    ///<summary>
    ///
    ///</summary>
    public partial class Hotel
    {
           public Hotel(){


           }
           /// <summary>
           /// Desc:编号ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int HotelID {get;set;}

           /// <summary>
           /// Desc:名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string HotelName {get;set;}

           /// <summary>
           /// Desc:图片
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string HotelImg {get;set;}

           /// <summary>
           /// Desc:距离
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string HotelDistance {get;set;}

           /// <summary>
           /// Desc:位置
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string HotelPosition {get;set;}

           /// <summary>
           /// Desc:最大会场
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int HotelMeettingMax {get;set;}

           /// <summary>
           /// Desc:最多容纳
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int HotelPeopleMax {get;set;}

           /// <summary>
           /// Desc:特点
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string HotelLabel {get;set;}

           /// <summary>
           /// Desc:价格
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string HotelPrice {get;set;}

           /// <summary>
           /// Desc:地区
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string HotelArea {get;set;}

           /// <summary>
           /// Desc:类型
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string HotelType {get;set;}

           /// <summary>
           /// Desc:会场数量
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int HotelMeettingCount {get;set;}

           /// <summary>
           /// Desc:客房数量
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? HotelRoomCount {get;set;}

           /// <summary>
           /// Desc:轮播图1
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string HotelBanner1 {get;set;}

           /// <summary>
           /// Desc:轮播图2
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string HotelBanner2 {get;set;}

           /// <summary>
           /// Desc:开业时间
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string HotelOpenTime {get;set;}

           /// <summary>
           /// Desc:最近装修
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string HotelFixTime {get;set;}

           /// <summary>
           /// Desc:酒店介绍
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string HotelAbout {get;set;}

           /// <summary>
           /// Desc:酒店服务设施
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string HotelService {get;set;}

           /// <summary>
           /// Desc:会议服务设施
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string HotelMeetting {get;set;}

           /// <summary>
           /// Desc:酒店餐饮设施
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string HotelDinner {get;set;}

           /// <summary>
           /// Desc:客房服务设施
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string HotelRoom {get;set;}

           /// <summary>
           /// Desc:曾举办
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string HotelHistory {get;set;}

           /// <summary>
           /// Desc:添加时间
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime HotelTime {get;set;}

    }
}
