using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Google.ProtocolBuffers;
using com.gexin.rp.sdk.dto;
using com.igetui.api.openservice;
using com.igetui.api.openservice.igetui;
using com.igetui.api.openservice.igetui.template;
using com.igetui.api.openservice.payload;
using System.Net;

namespace Sylone.Comm
{
    public  class GeTui
    {
        //参数设置 <-----参数需要重新设置----->
        //http的域名
        private static String HOST = "http://sdk.open.api.igexin.com/apiex.htm";

        //https的域名
        //private static String HOST = "https://api.getui.com/apiex.htm";

        //定义常量, appId、appKey、masterSecret 采用本文档 "第二步 获取访问凭证 "中获得的应用配置
        private static String APPID = "pdVFFXVu197Uy97KmvooY1";
        private static String APPKEY = "948bKxXmBmAjzQjqWOiBE5";
        private static String MASTERSECRET = "SZ24ZFvJwp9LsTnqQQiHK9";

        //pushMessageToApp接口测试代码
        public static void pushMessageToApp(int id,string title,string des)
        {
            IGtPush push = new IGtPush(HOST, APPKEY, MASTERSECRET);
            // 定义"AppMessage"类型消息对象，设置消息内容模板、发送的目标App列表、是否支持离线发送、以及离线消息有效期(单位毫秒)
            AppMessage message = new AppMessage();

            NotificationTemplate template = NotificationTemplateDemo(id,title,des);

            message.IsOffline = true;                         // 用户当前不在线时，是否离线存储,可选
            message.OfflineExpireTime = 1000 * 3600 * 12;     // 离线有效时间，单位为毫秒，可选
            message.Data = template;
            //判断是否客户端是否wifi环境下推送，2:4G/3G/2G,1为在WIFI环境下，0为无限制环境
            //message.PushNetWorkType = 0; 
            //message.Speed = 1000;

            List<String> appIdList = new List<String>();
            appIdList.Add(APPID);

            List<String> phoneTypeList = new List<String>();   //通知接收者的手机操作系统类型
            //phoneTypeList.Add("ANDROID");
            //phoneTypeList.Add("IOS");

            List<String> provinceList = new List<String>();    //通知接收者所在省份
            //provinceList.Add("浙江");
            //provinceList.Add("上海");
            //provinceList.Add("北京");

            List<String> tagList = new List<string>();
            //tagList.Add("中文");

            message.AppIdList = appIdList;
            //message.PhoneTypeList = phoneTypeList;
            //message.ProvinceList = provinceList;
            //message.TagList = tagList;


            String pushResult = push.pushMessageToApp(message);
        }


        /*
         * 
         * 所有推送接口均支持四个消息模板，依次为透传模板，通知透传模板，通知链接模板，通知弹框下载模板
         * 注：IOS离线推送需通过APN进行转发，需填写pushInfo字段，目前仅不支持通知弹框下载功能
         *
         */
        //透传模板动作内容
        public static NotificationTemplate NotificationTemplateDemo(int id, string title, string des)
        {
            NotificationTemplate template = new NotificationTemplate();
            template.AppId = APPID;
            template.AppKey = APPKEY;
            //通知栏标题
            template.Title = title;
            //通知栏内容     
            template.Text = des;
            //通知栏显示本地图片
            template.Logo = "";
            //通知栏显示网络图标
            template.LogoURL = "";
            //应用启动类型，1：强制应用启动  2：等待应用启动
            template.TransmissionType = "1";
            //透传内容  
            template.TransmissionContent = id.ToString();
            //接收到消息是否响铃，true：响铃 false：不响铃   
            template.IsRing = true;
            //接收到消息是否震动，true：震动 false：不震动   
            template.IsVibrate = true;
            //接收到消息是否可清除，true：可清除 false：不可清除    
            template.IsClearable = true;
            //设置通知定时展示时间，结束时间与开始时间相差需大于6分钟，消息推送后，客户端将在指定时间差内展示消息（误差6分钟）
            String begin = DateTime.Now.ToString();
            String end = DateTime.Now.AddMinutes(10).ToString();
            template.setDuration(begin, end);

            return template;
        }
    }
}
