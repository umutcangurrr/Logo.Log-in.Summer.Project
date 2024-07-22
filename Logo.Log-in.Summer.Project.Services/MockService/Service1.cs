using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using SLogManager;

namespace MockService
{
    public partial class MockService : ServiceBase
    {

        private FileSystemWatcher _watcher;
        private readonly string _fileToWatch = @"C:\Users\umut.gur\OneDrive - Logo\Desktop\Mock Folder";

        public MockService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
           
            InitializeWatcher();
        }

        protected override void OnStop()
        {
            LogManager.LogInformation("Mock Service: Mock Service stopped.");
            _watcher.Dispose();
        }

        private void InitializeWatcher()
        {
            var directoryToWatch = Path.GetDirectoryName(_fileToWatch);
            var fileNameToWatch = Path.GetFileName(_fileToWatch);

            _watcher = new FileSystemWatcher(directoryToWatch)
            {
                //Neleri izleyecek
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.LastWrite,
                Filter = fileNameToWatch
            };

            _watcher.Changed += OnChanged;
            _watcher.Created += OnChanged;
            _watcher.Deleted += OnChanged;
            _watcher.Renamed += OnRenamed;

            _watcher.EnableRaisingEvents = true;
        }

        // Herhangi bir değişiklikte çalışacak
        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            LogManager.LogInformation($"File {e.ChangeType}: {e.FullPath}");
        }

        // Takip ettiği dosya yeniden adlandırılırsa çalışacak
        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            LogManager.LogInformation($"File renamed from {e.OldFullPath} to {e.FullPath}");
        }



    }
}
