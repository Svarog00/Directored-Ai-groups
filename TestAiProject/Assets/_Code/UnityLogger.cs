using AiLibrary.Other;
using UnityEngine;

public class UnityLogger : IAiLogger
{
    public void Error(string message) => Debug.LogError(message);

    public void Log(string message) => Debug.Log(message);

    public void Warning(string message) => Debug.LogWarning(message);
}