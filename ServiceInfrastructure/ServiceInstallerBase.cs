using System.Configuration.Install;
using System.ServiceProcess;

namespace WindowsService.ServiceInfrastructure
{
    /// <summary>
    /// Базовый класс для инсталляторов Windows Service.
    /// </summary>
    [System.ComponentModel.DesignerCategory("")]
    public abstract class ServiceInstallerBase : Installer
    {
        protected ServiceInstallerBase(string serviceName)
        {
            Installers.Add(new System.ServiceProcess.ServiceInstaller { ServiceName = serviceName });
            Installers.Add(new ServiceProcessInstaller { Account = ServiceAccount.LocalSystem });
        }
    }
}