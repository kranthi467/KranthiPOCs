using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.ServiceProcess;
using System.Threading;

namespace SampleService
{
    public partial class RestrictTextFileService : ServiceBase
    {
        FileSystemWatcher watcher;
        public RestrictTextFileService()
        {
            InitializeComponent();
            watcher = new FileSystemWatcher(@"C:\Users\kranthi.ramasayam\Desktop\TestService", "*.txt");
            ServiceName = "SampleService";
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                watcher.NotifyFilter = NotifyFilters.LastAccess
                         | NotifyFilters.LastWrite
                         | NotifyFilters.FileName
                         | NotifyFilters.DirectoryName;

                watcher.Created += new FileSystemEventHandler(OnCreate);

                watcher.EnableRaisingEvents = true;
                watcher.IncludeSubdirectories = true;
                EventLog.WriteEntry("File Monitor Service", "Success: RestrictTextFileService");
            }
            catch
            {
                EventLog.WriteEntry("File Monitor Service", "Error while starting Service: RestrictTextFileService");
            }
        }

        public void Start()
        {
            watcher.NotifyFilter = NotifyFilters.LastAccess
                        | NotifyFilters.LastWrite
                        | NotifyFilters.FileName
                        | NotifyFilters.DirectoryName;

            watcher.Created += new FileSystemEventHandler(OnCreate);

            watcher.EnableRaisingEvents = true;
            watcher.IncludeSubdirectories = true;
            EventLog.WriteEntry("File Monitor Service", "Success");
            
            Thread.Sleep(int.MaxValue);
            Start();
        }

        private static void OnCreate(object source, FileSystemEventArgs e)
        {
            while (true)
            {
                try
                {
                    if (File.Exists(e.FullPath))
                    {
                        File.Delete(e.FullPath);
                        EventLog.WriteEntry("File Monitor Service", string.Format("File {0} {1}", e.FullPath, e.ChangeType.ToString()));
                    }
                    break;
                }
                catch
                {
                    Thread.Sleep(100);
                }
            }

        }

        protected override void OnStop()
        {
            watcher.EnableRaisingEvents = false;
            watcher.Dispose();
        }


    }

}
