using System.Text;
using UnityEngine;

class LogBuilder
{
    public bool HaveAnyLogs => 
        _sbLogText.Length > 0        || 
        _sbLogWarningText.Length > 0 ||
        _sbLogErrorText.Length   > 0;

    public bool HaveErrorLogs => _sbLogErrorText.Length > 0;
    public bool HaveWarningLogs => _sbLogWarningText.Length > 0;
    public bool HaveLogs => _sbLogText.Length > 0;

    private readonly StringBuilder _sbLogText;
    private readonly StringBuilder _sbLogErrorText;
    private readonly StringBuilder _sbLogWarningText;

    public LogBuilder()
    {
        _sbLogText = new StringBuilder();
        _sbLogErrorText = new StringBuilder();
        _sbLogWarningText = new StringBuilder();
    }

    public LogBuilder AddLog(object message)
    {
        _sbLogText.Append($"<color=white>{message}</color>\n");

        return this;
    }

    public LogBuilder AddLogSuccess(object message)
    {
        _sbLogText.Append($"<color=green>{message}</color>\n");

        return this;
    }

    public LogBuilder AddLogWarning(object message)
    {
        _sbLogWarningText.Append($"<color=yellow>{message}</color>\n");

        return this;
    }
    public LogBuilder AddLogError(object message)
    {
        _sbLogErrorText.Append($"<color=red>{message}</color>\n");
        return this;
    }

    public void Build()
    {
        if(_sbLogText.Length > 0)
            Debug.Log(_sbLogText.ToString());

        if(_sbLogWarningText.Length > 0)
            Debug.LogWarning(_sbLogWarningText.ToString());

        if(_sbLogErrorText.Length > 0)
            Debug.LogError(_sbLogErrorText.ToString());
    }
}