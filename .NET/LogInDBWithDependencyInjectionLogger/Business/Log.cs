using Microsoft.Practices.Unity;
using DataAccess;
using Model;
using System;

namespace Business
{
    public interface ILogger
    {
        void EventLogger(EventLog modelObject, Exception exception = null);
    }
    public class Logger : ILogger
    {
        private ILog _Log;
        [Dependency]
        public ILog Log
        {
            get { return _Log; }
            set { _Log = value; }
        }

        public void EventLogger(EventLog modelObject, Exception exception = null)
        {
            if (exception == null)
            {
                _Log.LogEvent(modelObject);
            }
            else
            {
                _Log.LogException(modelObject, exception);
            }
        }
    }

    public interface ILog
    {
        void LogEvent(EventLog modelObject);
        void LogException(EventLog modelObject, Exception exception);
    }

    class Log : ILog
    {
        public void LogEvent(EventLog modelObject)
        {
            DataFactory LogData = new DataFactory();
            IData loging = LogData.GetData();
            modelObject.Type = LogType.EVENT;
            loging.LogEvent(modelObject);
        }

        public void LogException(EventLog modelObject, Exception exception)
        {
            DataFactory LogData = new DataFactory();
            IData loging = LogData.GetData();
            modelObject.Event = exception.Message;
            modelObject.Type = LogType.EXCEPTION;
            loging.LogEvent(modelObject);
        }
    }

    class LogText : ILog
    {
        public void LogEvent(EventLog modelObject)
        {
            DataFactory LogData = new DataFactory();
            IData loging = LogData.GetData();
            modelObject.Type = LogType.EVENT;
            loging.LogEvent(modelObject);
        }

        public void LogException(EventLog modelObject, Exception exception)
        {
            DataFactory LogData = new DataFactory();
            IData loging = LogData.GetData();
            modelObject.Event = exception.Message;
            modelObject.Type = LogType.EXCEPTION;
            loging.LogEvent(modelObject);
        }
    }
}
