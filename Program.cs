﻿using System;
using System.ServiceProcess;

namespace WindowsService
{
    public static class Program
    {
        #region Nested classes to support running as service

        private const string ServiceName = "MyService";

        private class Service : ServiceBase
        {
            public Service()
            {
                ServiceName = Program.ServiceName;
            }

            protected override void OnStart(string[] args)
            {
                Start(args);
            }

            protected override void OnStop()
            {
                Program.Stop();
            }
        }
        #endregion

        static void Main(string[] args)
        {
            if (!Environment.UserInteractive)
                // running as service
                using (var service = new Service())
                    ServiceBase.Run(service);
            else
            {
                // running as console app
                Start(args);

                Console.WriteLine("Press any key to stop...");
                Console.ReadKey(true);

                Stop();
            }
        }

        private static void Start(string[] args)
        {
            // onstart code here
        }

        private static void Stop()
        {
            // onstop code here
        }
    }
}
