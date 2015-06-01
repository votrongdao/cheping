using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace DataUpdataSerivce
{
    public class SchedulerConfiguration
    {
        TimeSpan startTime = new TimeSpan(14, 21, 0);

        //时间间隔

        private int sleepInterval;

        //任务列表

        private ArrayList jobs = new ArrayList();

        public int SleepInterval { get { return sleepInterval; } }

        public ArrayList Jobs { get { return jobs; } }

        public TimeSpan StartTime
        {
            get
            {
                TimeSpan now = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                TimeSpan result = new TimeSpan(0, 0, 0);
                if (now < startTime)
                {
                    result = startTime - now;
                }
                else
                {
                    result = new TimeSpan(24,0, 0) + now - startTime;
                }
                return result;
            }
        }

        //调度配置类的构造函数

        public SchedulerConfiguration(int newSleepInterval)
        {

            sleepInterval = newSleepInterval;

        }

    }

}
