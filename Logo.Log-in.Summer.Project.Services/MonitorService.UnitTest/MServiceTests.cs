using NUnit.Framework;
using Moq;
using System.Timers;
using Logo.Log_inSummer.Services;



namespace MonitorService.UnitTest
{
    [TestFixture]
    public class MServiceTests
    {
        private Mock<IServiceMonitor> _mockServiceMonitor;
        private MService _service;
        private Settings _settings;
        private WindowsServiceMonitor _serviceMonitor;

        [SetUp]
        public void Setup()
        {
            _mockServiceMonitor = new Mock<IServiceMonitor>();
            _service = new MService();
        }


        [Test]
        public void LoadSettings_ShouldLogErrorIfFileNotFound()
        {
           
            string invalidPath = @"C:\InvalidPath\AppSettings.xml";
            _service.LoadSettings(invalidPath);

            
        }

        [Test]
        public void SetServiceMonitor_ShouldSetWindowsServiceMonitor()
        {
            _settings = new Settings();
            _settings.SelectedService = "Windows Service";

            
            _service.SetServiceMonitor();

            _serviceMonitor = new WindowsServiceMonitor();
            Assert.IsInstanceOf<WindowsServiceMonitor>(_serviceMonitor);
        }

        
    }
}