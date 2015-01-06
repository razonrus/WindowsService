using System;
using System.ServiceProcess;
using System.Threading;

namespace WindowsService
{
    [System.ComponentModel.DesignerCategory("")]
    public class WindowsService : ServiceBase
    {
        private Thread workerThread;

        protected override void OnStart(string[] args)
        {
            base.OnStart(args);

            workerThread = new Thread(Run);
            if (!Environment.UserInteractive)
            {
                workerThread.IsBackground = true;
            }

            workerThread.Start();

            if (Environment.UserInteractive) workerThread.Join();
        }

        private static void Run()
        {
        }

        protected override void OnStop()
        {
            base.OnStop();
        }
    }
}