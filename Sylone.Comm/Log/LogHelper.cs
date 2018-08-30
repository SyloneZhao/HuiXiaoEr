using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sylone.Comm
{
    public class LogHelper
    {
        /// <summary>
        /// 生成日志信息——Fatal(致命错误)
        /// </summary>
        /// <param name="message">日志内容</param>
        public static void Fatal(string message)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("Fatal");
            if (log.IsFatalEnabled)
            {
                log.Fatal(message);
            }
            log = null;
        }

        /// <summary>
        /// 生成日志信息——Fatal(致命错误)
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="message">日志内容</param>
        public static void Fatal(string name, string message)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(name);
            if (log.IsFatalEnabled)
            {
                log.Fatal(message);
            }
            log = null;
        }


        /// <summary>
        /// 生成日志信息——Error（一般错误）
        /// </summary>
        /// <param name="message">日志内容</param>
        public static void Error(string message)
        {
            try
            {
                log4net.ILog log = log4net.LogManager.GetLogger("Error");
                if (log.IsErrorEnabled)
                {
                    log.Error(message);
                }
                log = null;
            }
            catch (Exception ex)
            { 
                
            }
        }

        /// <summary>
        /// 生成日志信息——Error（一般错误）
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="message">日志内容</param>
        public static void Error(string name, string message)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(name);
            if (log.IsErrorEnabled)
            {
                log.Error(message);
            }
            log = null;
        }

        /// <summary>
        /// 生成日志信息——Warn（警告）
        /// </summary>
        /// <param name="message">日志内容</param>
        public static void Warn(string message)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("Warn");
            if (log.IsWarnEnabled)
            {
                log.Warn(message);
            }
            log = null;
        }

        /// <summary>
        /// 生成日志信息——Warn（警告）
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="message">日志内容</param>
        public static void Warn(string name, string message)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(name);
            if (log.IsWarnEnabled)
            {
                log.Warn(message);
            }
            log = null;
        }

        /// <summary>
        /// 生成日志信息——Info（一般信息）
        /// </summary>
        /// <param name="message">日志内容</param>
        public static void Info(string message)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("Info");
            if (log.IsInfoEnabled)
            {
                log.Info(message);
            }
            log = null;
        }

        /// <summary>
        /// 生成日志信息——Info（一般信息）
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="message">日志内容</param>
        public static void Info(string name, string message)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(name);
            if (log.IsInfoEnabled)
            {
                log.Info(message);
            }
            log = null;
        }

        /// <summary>
        /// 生成日志信息——Debug（调试信息）
        /// </summary>
        /// <param name="message">日志内容</param>
        public static void Debug(string message)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("Debug");
            if (log.IsDebugEnabled)
            {
                log.Debug(message);
            }
            log = null;
        }

        /// <summary>
        /// 生成日志信息——Debug（调试信息）
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="message">日志内容</param>
        public static void Debug(string name, string message)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(name);
            if (log.IsDebugEnabled)
            {
                log.Debug(message);
            }
            log = null;
        }
    }
}
