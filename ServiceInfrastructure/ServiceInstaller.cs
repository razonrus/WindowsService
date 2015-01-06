using System.ComponentModel;
using WindowsService.Annotations;

namespace WindowsService.ServiceInfrastructure
{
    /// <summary>
    /// Инсталлятор для WindowsService
    /// </summary>
    [RunInstaller(true)]
    [DesignerCategory(""), UsedImplicitly]
    public class ServiceInstaller : ServiceInstallerBase
    {
        public const string ServiceName = "Windows Service Name";

        public ServiceInstaller() : base(ServiceName) { }
    }
}