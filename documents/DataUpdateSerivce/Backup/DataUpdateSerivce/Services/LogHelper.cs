using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace DataUpdateSerivce.Services
{
    public static class LogHelper
    {

        public static void WriteErrLog(string content, int codeType)
        {
            string sysErrBackukpPath = HttpContext.Current.Server.MapPath("~/Log");

            string sysErrFile = HttpContext.Current.Server.MapPath("~/Log/log.txt");
            //判断错误文件备份目录是否存在
            if (!System.IO.Directory.Exists(sysErrBackukpPath))
            {
                //不存在则创建
                System.IO.Directory.CreateDirectory(sysErrBackukpPath);
            }
            //判断错误文件是否存在
            if (!System.IO.File.Exists(sysErrFile))
            {
                //不存在则创建
                System.IO.File.Create(sysErrFile).Dispose();
            }
            else
            {
                //判断文件大小是否超出
                System.IO.FileInfo f = new System.IO.FileInfo(sysErrFile);
                if (f.Length > 300 * 1024)
                {
                    //如果文件大于300k，则文件复制到备份目录
                    f.CopyTo(sysErrBackukpPath + string.Format("{0:yyyymmddhhmmssmmm}", DateTime.Now));
                    f.Delete();

                }
            }

            string txt = System.Environment.NewLine + content + " 错误编码:" + codeType.ToString() + "           时间：" + DateTime.Now.ToString();
            System.IO.File.AppendAllText(sysErrFile, txt);

        }
    }
}