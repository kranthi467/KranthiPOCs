using System;
using System.Diagnostics;
using System.ServiceProcess;

namespace SeesionMoniterService
{
    public partial class Service1 : ServiceBase
    {
        private EventLog _secuirityLog;

        public Service1()
        {
            InitializeComponent();
            _secuirityLog = new EventLog("Security");
        }

        protected override void OnStart(string[] args)
        {
            Logger.LogToEventViewer("Session Service Started...." + Environment.NewLine + "System log On time :" + DateTime.Now);

            try
            {
                _secuirityLog.EnableRaisingEvents = true;
                _secuirityLog.EntryWritten += SecurityLogEntryForPassword;
            }
            catch (Exception e)
            {
                Logger.LogToEventViewer(e.Message + e.TargetSite + "\n Service Ended with exception");
            }
        }

        protected void SecurityLogEntryForPassword(object sender, EntryWrittenEventArgs e)
        {
            if (e.Entry.EventID == 4625)
            {
                Logger.LogToEventViewer("Wrong Password At: \n" + DateTime.Now);
            }
        }

        protected override void OnStop()
        {
            Logger.LogToEventViewer("Session Service Stopped");
        }

        protected override void OnSessionChange(SessionChangeDescription changeDescription)
        {
            switch (changeDescription.Reason)
            {
                case SessionChangeReason.SessionLogon:
                    Logger.LogToEventViewer("System Log On Time: \n " + DateTime.Now);
                    break;
                case SessionChangeReason.SessionLogoff:
                    Logger.LogToEventViewer("System Log Off Time: \n " + DateTime.Now);
                    break;
                case SessionChangeReason.SessionLock:
                    Logger.LogToEventViewer("System Locked Time Time: \n " + DateTime.Now);
                    break;
                case SessionChangeReason.SessionUnlock:
                    Logger.LogToEventViewer("System Unlocked Time Time: \n " + DateTime.Now);
                    break;
            }

        }

        protected override void OnShutdown()
        {
            Logger.LogToEventViewer("System Shutdown Time: \n" + DateTime.Now);
        }
    }
}
