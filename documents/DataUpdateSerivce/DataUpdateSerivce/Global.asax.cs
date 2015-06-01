using System;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Routing;

namespace DataUpdataSerivce
{
    public class Global : HttpApplication
    {
        public System.Threading.Thread schedulerThread = null;
        void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes();





            SchedulerConfiguration config = new SchedulerConfiguration(1000 * 3);

            config.Jobs.Add(new SampleJob());

            Scheduler scheduler = new Scheduler(config);

            System.Threading.ThreadStart myThreadStart = new System.Threading.ThreadStart(scheduler.Start);

            System.Threading.Thread schedulerThread = new System.Threading.Thread(myThreadStart);

            schedulerThread.Start();

        }

        private void RegisterRoutes()
        {
            // Edit the base address of Service1 by replacing the "Service1" string below
            RouteTable.Routes.Add(new ServiceRoute("Service1", new WebServiceHostFactory(), typeof(Service1)));
        }


        protected void Application_End(Object sender, EventArgs e)
        {

            if (null != schedulerThread)
            {

                schedulerThread.Abort();

            }

        }

    }
}
