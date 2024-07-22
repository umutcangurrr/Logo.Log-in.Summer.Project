using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logo.Log_inSummer.Services
{
    public interface IServiceMonitor
    {
        void StartService(string serviceName);
        void CheckService(string serviceName);

    }
}
