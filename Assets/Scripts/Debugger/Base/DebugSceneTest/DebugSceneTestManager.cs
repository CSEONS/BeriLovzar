using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TNRD;
using AYellowpaper;
using System.IO;
using System.Linq;
using Kilosoft.Tools;

public class DebugSceneTestManager : MonoBehaviour
{
    [RequireInterface(typeof(ISceneTest))]
    [SerializeField]
    private List<UnityEngine.Object> _tests;


    [EditorButton("Execute Tests")]
    public void ExecuteTests()
    {
        var logBuilder = new LogBuilder();

        foreach (var testObject in _tests)
        {
            if (testObject is ISceneTest test)
            {
                if (test.IsPassed())
                {
                    logBuilder.AddLogSuccess($"Test success. Name: {testObject.name}");
                }
            }
            else
            {
                logBuilder.AddLogError($"Object does not implement ISceneTest interface. Name: {testObject.name}");
            }
        }

        logBuilder.Build();
    }
}
