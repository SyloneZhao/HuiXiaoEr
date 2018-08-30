using System.Net;
using System.IO;
using System.Text;
namespace Sylone.Comm
{
    /// <summary>
    /// 共用工具类
    /// </summary>
    public class IpHelper
    {
        #region 获得用户IP
        /// <summary>
        /// 获得用户IP
        /// </summary>
        public static string GetUserIp()
        {
            string ip;
            string[] temp;
            bool isErr = false;
            if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_ForWARDED_For"] == null)
                ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
            else
                ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_ForWARDED_For"].ToString();
            if (ip.Length > 15)
                isErr = true;
            else
            {
                temp = ip.Split('.');
                if (temp.Length == 4)
                {
                    for (int i = 0; i < temp.Length; i++)
                    {
                        if (temp[i].Length > 3) isErr = true;
                    }
                }
                else
                    isErr = true;
            }

            if (isErr)
                return "1.1.1.1";
            else
                return ip;
        }
        #endregion

        private static  string url = "http://ip.taobao.com/service/getIpInfo.php?ip=";

        public static TaobaoData GetArea(string ip)
        {
            string areaJson;
            TaobaoData theData;
            try
            {
                //创建请求  
                WebRequest request = WebRequest.Create(url + ip);
                //发送请求，获取相应  
                WebResponse response = request.GetResponse();
                using (Stream stream = response.GetResponseStream())  //获取响应的数据流  
                {
                    using (StreamReader reader = new StreamReader(stream, Encoding.GetEncoding("utf-8")))  //指定的数据流初始化为StreamReader 类  
                    {
                        areaJson = reader.ReadToEnd();  //读取数据流中的所有字符  
                        theData = JsonHelper.JsonToObject<TaobaoData>(areaJson);
                        if (theData.code == "1")  //表示获取数据失败  
                        {
                            return null;
                        }
                        return theData;
                    }

                }
            }
            catch
            {
                return null;
            }

        }
        /// <summary>  
        /// ip数据  
        /// </summary>  
        public class IPData
        {
            /// <summary>  
            /// 国家  
            /// </summary>  
            public string country { get; set; }
            public string country_id { get; set; }
            /// <summary>  
            /// 区域  
            /// </summary>  
            public string area { get; set; }
            public string area_id { get; set; }
            /// <summary>  
            /// 省  
            /// </summary>  
            public string region { get; set; }
            public string region_id { get; set; }
            /// <summary>  
            /// 市  
            /// </summary>  
            public string city { get; set; }
            public string city_id { get; set; }
            /// <summary>  
            /// 县  
            /// </summary>  
            public string county { get; set; }
            public string county_id { get; set; }
            /// <summary>  
            /// isp  
            /// </summary>  
            public string isp { get; set; }
            public string isp_id { get; set; }
            /// <summary>  
            /// ip  
            /// </summary>  
            public string ip { get; set; }
        }
        /// <summary>  
        /// 淘宝数据  
        /// </summary>  
        public class TaobaoData
        {
            public string code { get; set; }
            public IPData data { get; set; }
        }
    }
}
