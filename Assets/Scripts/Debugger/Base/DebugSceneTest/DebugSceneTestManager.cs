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
    [SerializeField] private DebugSingleton _debugSingleton;

    [RequireInterface(typeof(ISceneTest))]
    [SerializeField]
    private List<UnityEngine.Object> _tests;

    [EditorButton("Execute Tests")]
    public void ExecuteTests()
    {
        foreach (var testObject in _tests)
        {
            if (testObject is ISceneTest test)
            {
                if (!test.CheckTest())
                {
                    Debug.LogError($"<color=red>==Invalid test==\nTest name: \"{test.Name}\"</color>");
                }
                else
                {
                    Debug.Log($"<color=green>==Test Passed==\nTest name: \"{test.Name}\"</color>");
                }
            }
            else
            {
                Debug.LogWarning("<color=yellow>Object does not implement ISceneTest interface.</color>");
            }
        }
    }
}
