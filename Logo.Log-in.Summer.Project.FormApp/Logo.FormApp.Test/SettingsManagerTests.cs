using Moq;
using Settings_Application;
using System.IO.Abstractions;
using NUnit.Framework;

namespace Logo.FormApp.Test
{
    [TestFixture]
    public class SettingsManagerTests
    {
        private SettingsManager _settingsManager;
        private string _filePath;

        [SetUp]
        public void SetUp()
        {
            _settingsManager = new SettingsManager();
            _filePath = Path.Combine(Path.GetTempPath(), "AppSettings.xml");
        }

        [TearDown]
        public void TearDown()
        {
            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }
        }

        [Test]
        public void SaveSettings_ShouldCreateFile()
        {
            // Arrange
            var settings = new AppSettings
            {
                ServiceName = "MyService",
                SelectedService = "Windows Service",
                LogLevel = "Info",
                MonitoringInterval = 10
            };

            // Act
            _settingsManager.SerializeSettings(settings, _filePath);

            // Assert
            Assert.That(File.Exists(_filePath), Is.True);
        }
    }
}