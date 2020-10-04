using System;

namespace Model
{
    public class EventLog
    {
        public LogType Type;
        public string userName;
        public string Event;
    }

    public enum LogType
    {
        EVENT = 1,
        EXCEPTION
    }
}
