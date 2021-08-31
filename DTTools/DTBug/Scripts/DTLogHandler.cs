using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class DTLogHandler : ILogHandler
{
    public static ILogHandler defaultHandler { get; private set; }

    public IConsole console;

    public DTLogHandler()
    {
        defaultHandler = Debug.unityLogger.logHandler;
        Debug.unityLogger.logHandler = this;
    }

    public void LogException(Exception exception, Object context)
    {
            console.AddLine(LogType.Exception, exception.Message);
            defaultHandler.LogException(exception, context);
    }

    public void LogFormat(LogType logType, Object context, string format, params object[] args)
    {
            console.AddLine(logType, string.Format(format, args));
            defaultHandler.LogFormat(logType, context, format, args);
    }

    public void OnDestroy()
    {
        Debug.unityLogger.logHandler = defaultHandler;
        Debug.Log("Default LogHandler set");
    }
}
