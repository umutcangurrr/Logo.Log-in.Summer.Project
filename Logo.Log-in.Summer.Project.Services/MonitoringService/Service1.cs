using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using SLogManager;
using System.ServiceProcess;
using System.Timers;
using System.IO;
using System.Xml.Serialization;

namespace Logo.Log_inSummer.Services
{
    public partial class MService : ServiceBase
    {
        private Timer _timer;
        Settings _settings = new Settings();
        private IServiceMonitor _serviceMonitor;
        string filePath = @"C:\Users\umut.gur\OneDrive - Logo\Desktop\AppSettings.xml";
        public MService()
        {
            InitializeComponent();
            
        }

        protected override void OnStart(string[] args)
        {
            
            LoadSettings(filePath);
            SetServiceMonitor();          
            _timer = new Timer(_settings.MonitoringInterval*1000); // MonitoringInterval seconds to milliseconds
            _timer.Elapsed += OnTimedEvent;
            _timer.AutoReset = true;
           _timer.Enabled = true;

        }

        protected override void OnStop()
        {
            _timer.Stop();
        }

        public void LoadSettings(string filePath)
        {
            try
            {               
                XmlSerializer serializer = new XmlSerializer(typeof(Settings));
                

                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    _settings = (Settings)serializer.Deserialize(fs);
                }
            }
            catch (FileNotFoundException ex)
            {
                LogManager.LogError("Monitoring Service: Error: XML file not found", ex);
            }
            catch (InvalidOperationException ex)
            {
                LogManager.LogError("Monitoring Service: Error: Invalid operation while deserializing XML", ex);
            }
            catch (Exception ex)
            {
                LogManager.LogError("Monitoring Service: Error: An error occurred while loading settings", ex);
            }
        }

        

        public void SetServiceMonitor()
        {
            
            if (_settings.SelectedService == "Windows Service")
            {
                _serviceMonitor = new WindowsServiceMonitor();
            }
            else if (_settings.SelectedService == "WebAPI Service")
            {
                _serviceMonitor = new IISServiceMonitor();
            }
        }

         void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            _serviceMonitor?.CheckService(_settings.ServiceName);
        }


    }
}
