using System.Diagnostics;

namespace SeesionMoniterService
{
    class Logger
    {
        public static void LogToEventViewer(string message)
        {
            if (!EventLog.SourceExists("SessionSource"))
            {
                EventLog.CreateEventSource("SessionSource", "SessionLogger");
            }

            EventLog log = new EventLog("SessionLogger");
            log.Source = "SessionSource";
            log.WriteEntry("Session Service : " + message);
        }
    }
}
