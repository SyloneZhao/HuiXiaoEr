using System;
using System.Linq;
using System.Text;

namespace HuiXiaoEr.Model
{
    ///<summary>
    ///
    ///</summary>
    public partial class Meetting
    {
           public Meetting(){


           }
           /// <summary>
           /// Desc:编号ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int MeettingID {get;set;}

           /// <summary>
           /// Desc:酒店ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int HotelID {get;set;}

           /// <summary>
           /// Desc:会议室名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string MeettingName {get;set;}

           /// <summary>
           /// Desc:会议室图片
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string MeettingImg {get;set;}

           /// <summary>
           /// Desc:会议室价格
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string MeettingPrice {get;set;}

           /// <summary>
           /// Desc:会场面积
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int MeettingArea {get;set;}

           /// <summary>
           /// Desc:会场层高
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int MeettingHeight {get;set;}

           /// <summary>
           /// Desc:所在楼层
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int MeettingFloor {get;set;}

           /// <summary>
           /// Desc:场地特点
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string MeettingLabel {get;set;}

           /// <summary>
           /// Desc:课桌式
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string MeettingKZS {get;set;}

           /// <summary>
           /// Desc:宴会式
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string MeettingYHS {get;set;}

           /// <summary>
           /// Desc:U 型式
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string MeettingUXS {get;set;}

           /// <summary>
           /// Desc:鱼骨式
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string MeettingYGS {get;set;}

           /// <summary>
           /// Desc:剧院式
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string MeettingJYS {get;set;}

           /// <summary>
           /// Desc:董事会
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string MeettingDSH {get;set;}

           /// <summary>
           /// Desc:会场实景
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string MeettingScene {get;set;}

           /// <summary>
           /// Desc:添加时间
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime MeettingTime {get;set;}

    }
}
