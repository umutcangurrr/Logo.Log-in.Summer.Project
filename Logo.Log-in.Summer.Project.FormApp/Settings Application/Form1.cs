using System.Xml.Linq;
using System.ServiceProcess;
using System.Xml.Serialization;

namespace Settings_Application
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Start_btn_Click(object sender, EventArgs e)
        {
            
            AppSettings settings = new AppSettings
            {
                ServiceName = ServiceName_txt.Text,
                SelectedService = SelectionService_cb.SelectedItem.ToString(),
                LogLevel = LogLevelSelection_cb.SelectedItem.ToString(),
                MonitoringInterval = (int)MonitorInterval_nud.Value
            };

            SettingsManager settingsManager = new SettingsManager();

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, "AppSettings.xml");
            settingsManager.SerializeSettings(settings, filePath);
            StartMonitoringService();

        }

        private void StartMonitoringService()
        {
            try
            {
                // MonitoringService'in durumunu kontrol et
                using (ServiceController sc = new ServiceController("MonitorService"))
                {
                    if (sc.Status == ServiceControllerStatus.Stopped)
                    {
                        // MonitoringService durmuşsa başlat
                        sc.Start();
                        sc.WaitForStatus(ServiceControllerStatus.Running);
                        MessageBox.Show("MonitoringService started successfully.");
                    }
                    else
                    {
                        MessageBox.Show("MonitoringService is already running.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
       


    }

        


    

       
}

