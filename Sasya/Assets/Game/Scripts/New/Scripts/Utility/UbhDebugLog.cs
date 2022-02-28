using System.Diagnostics;
using System.Text;
using UnityEngine;

/// <summary>
/// The class that wrapped the Unity debug log.
/// </summary>
public static class UbhDebugLog
{
    private const string PREFIX = "[UBH] ";

    private static bool s_enableDebugLog = true;

    public static void EnableDebugLog()
    {
        s_enableDebugLog = true;
    }

    public static void DisableDebugLog()
    {
        s_enableDebugLog = false;
    }

    public static bool IsEnableLog()
    {
        return s_enableDebugLog;
    }

    public static void Log(object message)
    {
       
    }

    public static void Log(object message, Object context)
    {
        
    }

    public static void LogWarning(object message)
    {
      
    }

    public static void LogWarning(object message, Object context)
    {
       
    }

    public static void LogError(object message)
    {
        
    }

    public static void LogError(object message, Object context)
    {
       
    }
}
