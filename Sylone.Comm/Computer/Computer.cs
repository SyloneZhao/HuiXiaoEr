using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;

namespace Sylone.Comm
{
    public class Computer
    {
        /// <summary>
        /// cpu序列号
        /// </summary>
        public static string CpuID; //1.cpu序列号
        /// <summary>
        /// mac序列号
        /// </summary>
        public static string MacAddress; //2.mac序列号
        /// <summary>
        /// 硬盘id
        /// </summary>
        public static string DiskID; //3.硬盘id
        /// <summary>
        /// ip地址
        /// </summary>
        public static string IpAddress; //4.ip地址
        /// <summary>
        /// 登录用户名
        /// </summary>
        public static string LoginUserName; //5.登录用户名
        /// <summary>
        /// 计算机名
        /// </summary>
        public static string ComputerName; //6.计算机名
        /// <summary>
        /// 系统类型
        /// </summary>
        public static string SystemType; //7.系统类型
        /// <summary>
        /// 内存量 单位：M
        /// </summary>
        public static string TotalPhysicalMemory; //8.内存量 单位：M
        public static string BIOS;
        static Computer()
        {
            CpuID = GetCpuID();
            MacAddress = GetMacAddress();
            DiskID = GetDiskID();
            BIOS = GetHardDiskID();
            IpAddress = GetIPAddress();
            LoginUserName = GetUserName();
            SystemType = GetSystemType();
            TotalPhysicalMemory = GetTotalPhysicalMemory();
            ComputerName = GetComputerName();
        }
        //1.获取CPU序列号代码 
        static string GetCpuID()
        {
            try
            {
                string cpuInfo = "";//cpu序列号 
                ManagementClass mc = new ManagementClass("Win32_Processor");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    cpuInfo = mo.Properties["ProcessorId"].Value.ToString();
                }
                moc = null;
                mc = null;
                return cpuInfo;
            }
            catch
            {
                return "";
            }
            finally
            {
            }

        }

        //2.获取网卡硬件地址 
        static string GetMacAddress()
        {
            try
            {
                string mac = "";
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    if ((bool)mo["IPEnabled"] == true)
                    {
                        mac = mo["MacAddress"].ToString();
                        break;
                    }
                }
                moc = null;
                mc = null;
                return mac;
            }
            catch
            {
                return "";
            }
            finally
            {
            }

        }
        //取第一块硬盘编号
        static string GetHardDiskID()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");
                String strHardDiskID = null;
                foreach (ManagementObject mo in searcher.Get())
                {
                    strHardDiskID = mo["SerialNumber"].ToString().Trim();
                    break;
                }
                return strHardDiskID;
            }
            catch
            {
                return "";
            }
        }//end

        //3.获取硬盘ID 
        static string GetDiskID()
        {
            try
            {
                String HDid = "";
                ManagementClass mc = new ManagementClass("Win32_DiskDrive");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {

                    HDid = (string)mo.Properties["SerialNumber"].Value;
                    //SerialNumber
                }
                moc = null;
                mc = null;
                return HDid;
            }
            catch
            {
                return "";
            }
            finally
            {
            }

        }
        static string GetBIOSID()
        {
            try
            {
                String HDid = "";
                ManagementClass mc = new ManagementClass("Win32_BIOS");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {

                    HDid = (string)mo.Properties["SerialNumber"].Value;
                    //SerialNumber
                }
                moc = null;
                mc = null;
                return HDid;
            }
            catch
            {
                return "";
            }
            finally
            {
            }

        }
        //4.获取IP地址 
        static string GetIPAddress()
        {
            try
            {
                string st = "";
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    if ((bool)mo["IPEnabled"] == true)
                    {
                        //st=mo["IpAddress"].ToString(); 
                        System.Array ar;
                        ar = (System.Array)(mo.Properties["IpAddress"].Value);
                        st = ar.GetValue(0).ToString();
                        break;
                    }
                }
                moc = null;
                mc = null;
                return st;
            }
            catch
            {
                return "";
            }
            finally
            {
            }

        }

        /// 5.操作系统的登录用户名 
        static string GetUserName()
        {
            try
            {
                string un = "";
                un = Environment.UserName;
                return un;
            }
            catch
            {
                return "";
            }
            finally
            {
            }

        }



        //6.获取计算机名
        static string GetComputerName()
        {
            try
            {
                return System.Environment.MachineName;

            }
            catch
            {
                return "";
            }
            finally
            {
            }
        }



        ///7 PC类型 
        static string GetSystemType()
        {
            try
            {
                string st = "";
                ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {

                    st = mo["SystemType"].ToString();

                }
                moc = null;
                mc = null;
                return st;
            }
            catch
            {
                return "";
            }
            finally
            {
            }
        }



        ///8.物理内存        
        static string GetTotalPhysicalMemory()
        {
            try
            {

                string st = "";
                ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {

                    st = mo["TotalPhysicalMemory"].ToString();

                }
                moc = null;
                mc = null;
                return st;
            }
            catch
            {
                return "";
            }
            finally
            {
            }

        }
    }
}
