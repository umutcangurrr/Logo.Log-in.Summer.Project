using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Logo.Log_inSummer.Services
{
    public class WindowsServiceMonitor : IServiceMonitor
    {
        public void StartService(string serviceName)
        {
            using (ServiceController sc = new ServiceController(serviceName))
            {
                if (sc.Status == ServiceControllerStatus.Stopped)
                {
                    sc.Start();
                    sc.WaitForStatus(ServiceControllerStatus.Running);
                    SLogManager.LogManager.LogInformation($"Monitoring Service: {serviceName} started.");
                }
            }
        }

        public void CheckService(string serviceName)
        {
            using (ServiceController sc = new ServiceController(serviceName))
            {
                if (sc.Status != ServiceControllerStatus.Running)
                {
                    StartService(serviceName);
                }
                else
                {
                    SLogManager.LogManager.LogInformation($"Monitoring Service: {serviceName} running.");
                }
            }
        }
    }
}
