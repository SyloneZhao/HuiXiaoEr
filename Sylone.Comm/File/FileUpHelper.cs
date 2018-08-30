using System;
using System.Web.UI.WebControls;
using System.Web;
using System.Web.UI.HtmlControls;

namespace Sylone.Comm
{
    /// <summary>
    /// 文件上传帮助类
    /// </summary>
    public class FileUpHelper
    {
        private static string fileType = ConfigHelper.GetAppSettings("UploadFileType");
        private static int fileSize = ConfigHelper.GetConfigInt("UploadFileSize");
        #region 上传文件
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="file">文件</param>
        /// <param name="filePath">文件路径</param>
        /// <param name="fileType">文件类型</param>
        /// <param name="allPath">是否返回完整路径</param>
        public static string UploadFile(HttpPostedFileBase file, string filePath,bool allPath)
        {
            if (file.ContentLength > 0)
            {
                if (file.ContentLength / 1024 < fileSize*1024)
                {
                    string MimeType = file.ContentType;
                    //验证合法的文件
                    if (CheckFileExt(fileType, MimeType))
                    {
                       string savePath = HttpContext.Current.Server.MapPath(filePath);
                        if (!DirectoryHelper.IsExistDirectory(savePath))
                        {
                            DirectoryHelper.CreateDirectory(savePath);
                        }
                        string fileExt = file.FileName.Substring(file.FileName.LastIndexOf("."));
                        string fileName = GetUploadFileName();
                        string fileAllPath = savePath + fileName + fileExt;
                        file.SaveAs(fileAllPath);
                        return allPath==true?fileAllPath: filePath+ fileName + fileExt;
                    }
                    else
                    {
                       throw new Exception("不被允许的上传文件类型");
                    }
                }
                else
                {
                    throw new Exception("上传文件不能大于"+ fileSize + "M");
                }
            }
            else
            {
                throw new Exception("没有上传文件");
            }
        }
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="file">文件</param>
        /// <param name="filePath">文件路径</param>
        /// <param name="fileType">文件类型</param>
        /// <param name="allPath">是否返回完整路径</param>
        public static string UploadFile(HttpPostedFile file, string filePath, bool allPath,string fileName="")
        {
            if (file.ContentLength > 0)
            {
                if (file.ContentLength / 1024 < fileSize * 1024)
                {
                    string MimeType = file.ContentType;
                    //验证合法的文件
                    if (CheckFileExt(fileType, MimeType))
                    {
                        string savePath = HttpContext.Current.Server.MapPath(filePath);
                        if (!DirectoryHelper.IsExistDirectory(savePath))
                        {
                            DirectoryHelper.CreateDirectory(savePath);
                        }
                        string fileExt = file.FileName.Substring(file.FileName.LastIndexOf("."));
                        if (fileName == "") {
                            fileName = GetUploadFileName();
                        }
                        string fileAllPath = savePath + fileName + fileExt;
                        file.SaveAs(fileAllPath);
                        return allPath == true ? fileAllPath : filePath + fileName + fileExt;
                    }
                    else
                    {
                        throw new Exception("不被允许的上传文件类型");
                    }
                }
                else
                {
                    throw new Exception("上传文件不能大于" + fileSize + "M");
                }
            }
            else
            {
                throw new Exception("没有上传文件");
            }
        }
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="PosPhotoUpload">控件</param>
        /// <param name="saveFileName">保存的文件名</param>
        /// <param name="imagePath">保存的文件路径</param>
        /// <param name="allPath">是否返回完整路径</param>
        public static string UploadFile(FileUpload PosPhotoUpload, string filePath, string imagePath, bool allPath)
        {

            if (PosPhotoUpload.HasFile)
            {
                if (PosPhotoUpload.PostedFile.ContentLength / 1024 < fileSize * 1024)
                {
                    string MimeType = PosPhotoUpload.PostedFile.ContentType;
                    //验证合法的文件
                    if (CheckFileExt(fileType, MimeType))
                    {
                        string savePath = HttpContext.Current.Server.MapPath(filePath);
                        if (!DirectoryHelper.IsExistDirectory(savePath))
                        {
                            DirectoryHelper.CreateDirectory(savePath);
                        }
                        string fileExt = PosPhotoUpload.FileName.Substring(PosPhotoUpload.FileName.LastIndexOf("."));
                        string fileName = GetUploadFileName();
                        string fileAllPath = savePath + fileName + fileExt;
                        PosPhotoUpload.PostedFile.SaveAs(fileAllPath);
                        return allPath == true ? fileAllPath : filePath + fileName + fileExt;
                    }
                    else
                    {
                        throw new Exception("不被允许的上传文件类型");
                    }
                }
                else
                {
                    throw new Exception("上传文件不能大于" + fileSize + "M");
                }
            }
            else
            {
                throw new Exception("没有上传文件");
            }
        }
        #endregion

        #region 生成上传文件名
        /// <summary>
        /// 生成上传文件名
        /// </summary>
        /// <returns></returns>
        public static string GetUploadFileName()
        {
            string Result = "";
            DateTime time = DateTime.Now;
            Result += time.Year.ToString() + ConvertHelper.RepairZero(time.Month.ToString(), 2) + ConvertHelper.RepairZero(time.Day.ToString(), 2) + ConvertHelper.RepairZero(time.Hour.ToString(), 2) + ConvertHelper.RepairZero(time.Minute.ToString(), 2) + ConvertHelper.RepairZero(time.Second.ToString(), 2) + ConvertHelper.RepairZero(time.Millisecond.ToString(), 3);
            return (Result);
        } 
        #endregion

    

        #region 检查是否为合法的上传文件
        /// <summary>
        /// 检查是否为合法的上传文件
        /// </summary>
        /// <returns></returns>
        private static bool CheckFileExt(string _fileType, string _fileExt)
        {
            string[] allowExt = _fileType.Split('|');
            for (int i = 0; i < allowExt.Length; i++)
            {
                if (allowExt[i].ToLower() == _fileExt.ToLower()) { return true; }
            }
            return false;
        }
        #endregion
    }
}
