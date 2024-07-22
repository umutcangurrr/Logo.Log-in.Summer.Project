using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Logo.Log_inSummer.Services
{
    [XmlRoot("AppSettings")]
    public class Settings
    {
        public string ServiceName { get; set; }
        public string SelectedService { get; set; }
        public string LogLevel { get; set; }
        public int MonitoringInterval { get; set; }

    }
}
