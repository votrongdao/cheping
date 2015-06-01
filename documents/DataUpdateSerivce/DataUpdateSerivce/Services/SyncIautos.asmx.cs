using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using DataUpdataSerivce.Entity;
using System.Xml;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using DataUpdateSerivce.Services;

namespace DataUpdataSerivce.Services
{
    /// <summary>
    /// Update 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class SyncIautos : System.Web.Services.WebService
    {

        [WebMethod]
        public SyncResult UpdateData(List<UpdateDataData> datas)
        {

            SyncResult result = new SyncResult();
            UpdateDataData date = null;
            try
            {


                for (int i = 0; i < datas.Count; i++)
                {
                    date = datas[i];
                    SQLHelper.ExecuteSqlByUpdateDataDate(date);
                }
            }
            catch (FormatException ex)
            {
                result.result = 0;
                result.message = date.TableName + "类型错误:" + ex.ToString() + date.OperateID;
                return result;
            }
            catch (SqlException ex)
            {
                string returnStr = string.Empty;
                date.Record.ForEach(n => returnStr += string.Format("{0}:{1}\r\n", n.Name, n.Value));
                result.result = 0;
                result.message = date.TableName + "SQL错误：" + ex.ToString() + date.OperateID + "\r\n" + returnStr;
                return result;
            }
            catch (Exception ex)
            {
                result.result = 0;
                result.message = date.TableName + "其它错误：" + ex.ToString() + date.OperateID;
                return result;
            }
            result.result = 1;
            return result;
        }



        [WebMethod]
        public SyncResult AddField(List<AddFieldEntity> fields)
        {
            SyncResult result = new SyncResult();
            try
            {
                for (int i = 0; i < fields.Count; i++)
                {
                    SQLHelper.ExecuteSqlByAddField(fields[i]);
                }
                result.result = 1;

            }
            catch (Exception ex)
            {

                result.result = 0;
                result.message = ex.ToString();
            }
            return result;
        }

        [WebMethod]
        public SyncResult AddTable(AddTableEntity table)
        {
            SyncResult result = new SyncResult();
            try
            {
                bool isSuccess = SQLHelper.ExecuteSqlByAddTable(table);
                if (isSuccess)
                {
                    result.result = 1;
                }
                else
                {
                    result.result = 0;
                    result.message = "执行未成功";
                }
            }
            catch (Exception ex)
            {

                result.result = 0;
                result.message = ex.ToString();
            }
            return result;
        }

        [WebMethod]
        public SyncResult FindCount(string tableName)
        {
            SyncResult result = new SyncResult();
            try
            {
                result.result = 1;
                result.count = SQLHelper.FindCount(tableName);
            }
            catch (Exception ex)
            {

                result.result = 0;
                result.message = ex.ToString();
            }

            return result;
        }

        [WebMethod]
        public SyncResult FindTable(string tableName)
        {
            SyncResult result = new SyncResult();
            try
            {
                result.result = 1;
                result.fields = SQLHelper.FindTable(tableName);
            }
            catch (Exception ex)
            {
                result.result = 0;
                result.message = ex.ToString();

            }

            return result;
        }

        [WebMethod]
        public SyncResult FindData(FindDataEntity entity)
        {
            SyncResult result = new SyncResult();
            try
            {
                result.result = 1;
                result.datas = SQLHelper.FindData(entity);
            }
            catch (Exception ex)
            {
                result.result = 0;
                result.message = ex.ToString();
            }
            return result;
        }



        [WebMethod]
        public SyncResult UploadFile(string fileName, byte[] bytes)
        {
            LogHelper.WriteErrLog(string.Format("{0}文件开始上传", fileName), 901);
            SyncResult result = new SyncResult();
            string PartSavePath = Server.MapPath(ConfigurationManager.AppSettings.Get("PartSavePath"));
            string ZipSavePath = Server.MapPath(ConfigurationManager.AppSettings.Get("ZipSavePath"));
            string UnZipSavePath = Server.MapPath(ConfigurationManager.AppSettings.Get("UnZipSavePath"));
            if (!Directory.Exists(PartSavePath))
            {
                Directory.CreateDirectory(PartSavePath);
            }
            if (!Directory.Exists(ZipSavePath))
            {
                Directory.CreateDirectory(ZipSavePath);
            }
            if (!Directory.Exists(UnZipSavePath))
            {
                Directory.CreateDirectory(UnZipSavePath);
            }

            try
            {


                if (FileHelper.SaveFile(PartSavePath + fileName, bytes))
                {
                    result.result = 1;
                    //如果是最后一个文件开始合并
                    if (Directory.GetFiles(PartSavePath).Where(n => n.ToString().Contains(fileName.Split(' ')[0] + " ")).ToArray().Length == int.Parse(fileName.Split(' ')[1]))
                    {
                        string[] fileNames = new string[int.Parse(fileName.Split(' ')[1])];
                        for (int i = 1; i <= int.Parse(fileName.Split(' ')[1]); i++)
                        {
                            fileNames[i - 1] = PartSavePath + fileName.Split(' ')[0] + " " + fileName.Split(' ')[1] + " " + i.ToString() + ".spf";
                        }
                        string targetFileName = ZipSavePath + fileName.Split(' ')[0] + ".zip";
                        if (FileHelper.MergeFile(fileNames, targetFileName))
                        {
                            FileHelper.DeleteFile(fileNames);
                            string unZipFilePath = UnZipSavePath + fileName.Split(' ')[0] + ".csv";
                            if (FileHelper.UnGzipFile(targetFileName, unZipFilePath))
                            {
                                FileHelper.DeleteFile(new string[] { targetFileName });
                                result.result = 1;
                            }
                            else
                            {
                                result.result = 0;
                                result.message = "解压失败";
                                LogHelper.WriteErrLog(string.Format("FileName:{0}解压失败", fileName), 219);
                            }
                        }
                        else
                        {
                            result.result = 0;
                            result.message = "合并文件失败";
                            LogHelper.WriteErrLog(string.Format("FileName:{0}合并失败", fileName), 225);
                        }
                    }

                }




            }
            catch (Exception ex)
            {

                result.result = 0;
                result.message = ex.ToString();
                LogHelper.WriteErrLog(string.Format("FileName:{0}上传引发异常", fileName), 240);
            }
            finally
            {
                LogHelper.WriteErrLog(string.Format("FileName:{0}上传文件记录", fileName), 245);
            }






            return result;

        }




        [WebMethod]
        public SyncResult ImportData(string tableName)
        {
            SyncResult result = new SyncResult();
            string UnZipSavePath = Server.MapPath(ConfigurationManager.AppSettings.Get("UnZipSavePath"));
            try
            {
                if (File.Exists(UnZipSavePath + tableName + ".csv"))
                {
                    result.result = 1;
                    bool isSuccess = SQLHelper.ImportData(tableName, UnZipSavePath + tableName + ".csv");
                }
                else
                {
                    result.result = 0;
                    result.message = "文件不存在";
                }

            }
            catch (Exception ex)
            {
                result.result = 0;
                result.message = ex.ToString();

            }
            return result;
        }







    }
}
