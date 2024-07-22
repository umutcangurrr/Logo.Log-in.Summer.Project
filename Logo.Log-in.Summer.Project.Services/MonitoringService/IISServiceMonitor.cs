using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices;
using Microsoft.Web.Administration;

namespace Logo.Log_inSummer.Services
{
    public class IISServiceMonitor : IServiceMonitor
    {
        public void StartService(string appPoolName)
        {
            try
            {
                using (ServerManager serverManager = new ServerManager())
                {
                    ApplicationPool appPool = serverManager.ApplicationPools.FirstOrDefault(ap => ap.Name == appPoolName);
                    if (appPool != null && appPool.State != ObjectState.Started)
                    {
                        appPool.Start();
                        SLogManager.LogManager.LogInformation($"Monitoring Service: AppPool {appPoolName} started.");
                    }
                    else if (appPool != null)
                    {
                        SLogManager.LogManager.LogInformation($"Monitoring Service: AppPool {appPoolName} is already running.");
                    }
                    else
                    {
                        SLogManager.LogManager.LogInformation($"Monitoring Service: AppPool {appPoolName} not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                SLogManager.LogManager.LogInformation($"Monitoring Service: Error starting AppPool {appPoolName}: {ex.Message}\n{ex.StackTrace}");
            }
        }

        public void CheckService(string appPoolName)
        {
            try
            {
                using (ServerManager serverManager = new ServerManager())
                {
                    ApplicationPool appPool = serverManager.ApplicationPools.FirstOrDefault(ap => ap.Name == appPoolName);
                    if (appPool != null && appPool.State != ObjectState.Started)
                    {
                        StartService(appPoolName);
                    }
                    else if (appPool != null)
                    {
                        SLogManager.LogManager.LogInformation($"Monitoring Service: AppPool {appPoolName} is running.");
                    }
                    else
                    {
                        SLogManager.LogManager.LogInformation($"Monitoring Service: AppPool {appPoolName} not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                SLogManager.LogManager.LogInformation($"Monitoring Service: Error checking AppPool {appPoolName}: {ex.Message}\n{ex.StackTrace}");
            }
        }

    }
}
