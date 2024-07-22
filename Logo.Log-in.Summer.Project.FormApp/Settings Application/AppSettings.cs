using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Settings_Application
{
    public class AppSettings
    {
        public string ServiceName { get; set; }
        public string SelectedService { get; set; }
        public string LogLevel { get; set; }
        public int MonitoringInterval { get; set; }
    }
}
