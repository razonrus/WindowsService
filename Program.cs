using System;
using System.ComponentModel;
using System.ServiceProcess;
using WindowsService.Annotations;
using WindowsService.ServiceInfrastructure;
using ServiceInstaller = WindowsService.ServiceInfrastructure.ServiceInstaller;

namespace WindowsService
{
    [DesignerCategory(""), UsedImplicitly]
    public class Program : ServiceRunnerBase
    {
        private static void Main()
        {

            var service = new WindowsService { ServiceName = ServiceInstaller.ServiceName };

            if (Environment.UserInteractive)
            {
                //Running in console
                RunAsConsoleApp(service, null);
            }
            else
            {
                //Running as windows service
                ServiceBase.Run(service);
            }
        }
    }
}
