using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;

namespace DataUpdataSerivce
{
    public class Scheduler
    {
        private SchedulerConfiguration configuration = null;

        public Scheduler(SchedulerConfiguration config)
        {

            configuration = config;

        }

        public void Start()
        {
            /*
            while (true)
            {

                //执行每一个任务

                foreach (ISchedulerJob job in configuration.Jobs)
                {

                    ThreadStart myThreadDelegate = new ThreadStart(job.Execute);

                    Thread myThread = new Thread(myThreadDelegate);

                    myThread.Start();

                    //Thread.Sleep(configuration.SleepInterval);
                    Thread.Sleep(configuration.StartTime);

                }

            }
             * */

        }

    }

}
