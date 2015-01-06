using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.ServiceProcess;

namespace WindowsService.ServiceInfrastructure
{
    public abstract class ServiceRunnerBase
    {
        public static void RunAsConsoleApp(ServiceBase service, string[] args)
        {
            handler = ConsoleEventCallback;
            SetConsoleCtrlHandler(handler, true);
            serviceToRun = service;
            CallServiceMethod(serviceToRun, "OnStart", new object[] { args });
        }

        private static void CallServiceMethod(ServiceBase serviceToRun, string methodName, object[] args)
        {
            var method = typeof(ServiceBase).GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);
            method.Invoke(serviceToRun, args);
        }

        static bool ConsoleEventCallback(int eventType)
        {
            if (eventType == 2)
            {
                Console.WriteLine("Console window closing, death imminent");

                CallServiceMethod(serviceToRun, "OnStop", null);
            }
            return false;
        }
        static ConsoleEventDelegate handler;   // Keeps it from getting garbage collected
        private static ServiceBase serviceToRun;
        // Pinvoke
        private delegate bool ConsoleEventDelegate(int eventType);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetConsoleCtrlHandler(ConsoleEventDelegate callback, bool add);

    }
}