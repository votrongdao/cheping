using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace DataUpdataSerivce
{
    public class SampleJob : ISchedulerJob
    {
        public void Execute()
        {
            Console.WriteLine(DateTime.Now);
            string FILE_NAME = "e:\\SchedulerJob.txt";
            string c = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            bool flag = false;
            if (!File.Exists(FILE_NAME))
            {

                flag = true;

                StreamWriter sr = File.CreateText(FILE_NAME);

                sr.Close();

            }
            StreamWriter x = new StreamWriter

    (FILE_NAME, true, System.Text.Encoding.Default);

            if (flag) { x.Write("计划任务测试开始："); }


            x.Write("\r\n" + c);

            x.Close();



        }
    }
}