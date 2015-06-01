using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.IO.Compression;
using DataUpdateSerivce.Services;

namespace DataUpdataSerivce.Entity
{
    public static class FileHelper
    {
        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static bool SaveFile(string fileName, byte[] buffer)
        {
            Stream s = new FileStream(fileName, FileMode.Create);
            s.Write(buffer, 0, buffer.Length);
            s.Flush();
            s.Close();
            if (File.Exists(fileName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public static void DeleteFile(string[] fileNames)
        {
            foreach (string fileName in fileNames)
            {
                FileInfo file = new FileInfo(fileName);
                file.Delete();
            }

        }
        /// <summary>
        /// 合并文件
        /// </summary>
        /// <param name="arrFileNames"></param>
        /// <param name="targetFileName"></param>
        /// <returns></returns>
        public static bool MergeFile(string[] arrFileNames, string targetFileName)
        {
            int iSumFile = arrFileNames.Length;
            FileStream AddStream = new FileStream(targetFileName, FileMode.OpenOrCreate);
            //以合并后的文件名称和打开方式来创建、初始化FileStream文件流
            BinaryWriter AddWriter = new BinaryWriter(AddStream);
            //以FileStream文件流来初始化BinaryWriter书写器，此用以合并分割的文件
            /*循环合并小文件，并生成合并文件 */
            for (int i = 0; i < iSumFile; i++)
            {
                FileStream TempStream = null;
                BinaryReader TempReader = null;
                try
                {
                    TempStream = new FileStream(arrFileNames[i], FileMode.Open);
                }
                catch (Exception)
                {
                    //如果源文件不存在
                    AddWriter.Close();
                    AddStream.Close();
                    File.Delete(targetFileName);
                    return false;
                }
                //以小文件所对应的文件名称和打开模式来初始化FileStream文件流，起读取分割作用
                try
                {
                    TempReader = new BinaryReader(TempStream);
                    //用FileStream文件流来初始化BinaryReader文件阅读器，也起读取分割文件作用
                    AddWriter.Write(TempReader.ReadBytes((int)TempStream.Length));
                }
                catch (Exception)
                {

                }
                //读取分割文件中的数据，并生成合并后文件
                try
                {
                    TempReader.Close();
                }
                catch (Exception)
                {

                }
                try
                {
                    //关闭BinaryReader文件阅读器
                    TempStream.Close();
                }
                catch (Exception)
                {

                }
                //关闭FileStream文件流
                //显示合并进程
            }
            AddWriter.Close();
            //关闭BinaryWriter文件书写器
            AddStream.Close();
            //关闭FileStream文件流
            if (File.Exists(targetFileName) && new FileInfo(targetFileName).Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 解压文件
        /// </summary>
        /// <param name="zipfilename"></param>
        /// <param name="unzipfilename"></param>
        /// <returns></returns>
        public static bool UnGzipFile(string zipfilename, string unzipfilename)
        {
            bool blResult = false;//表示解压是否成功的返回结果
            //创建压缩文件的输入流实例
            FileStream fs = new FileStream(zipfilename, FileMode.Open);
            GZipStream zipFile = new GZipStream(fs, CompressionMode.Decompress);
            //创建目标文件的流
            FileStream destFile = File.Open(unzipfilename, FileMode.Create);
            try
            {
                int buffersize = 2048;//缓冲区的尺寸，一般是2048的倍数
                byte[] FileData = new byte[buffersize];//创建缓冲数据
                while (buffersize > 0)//一直读取到文件末尾
                {
                    buffersize = zipFile.Read(FileData, 0, buffersize);//读取压缩文件数据
                    destFile.Write(FileData, 0, buffersize);//写入目标文件
                }
                if (File.Exists(unzipfilename))
                {
                    blResult = true;
                    LogHelper.WriteErrLog(string.Format("{0}:文件解压成功!", unzipfilename), 902);
                }
            }
            catch (Exception ee)
            {
                LogHelper.WriteErrLog(string.Format("{0}:文件解压失败!ex:{1}", unzipfilename, ee.ToString()), 902);
                blResult = false;
            }
            finally
            {
                destFile.Close();//关闭目标文件
                zipFile.Close();//关闭压缩文件

            }
            return blResult;
        }
    }
}