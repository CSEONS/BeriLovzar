using UnityEditor;
using UnityEngine;

public class CheckLevelValid : MonoBehaviour
{
    public GameLevel[] Levels; // Массив для хранения имен сцен

    private void Awake()
    {
        if (Levels.Length == 0)
        {
            Debug.LogError("Levels is empty.");
        }

        foreach (var sceneName in Levels)
        {
            if (SceneExists(sceneName.Name) is false)
            {
                Debug.LogError($"Scene with name \"{sceneName}\" not found.");
                return;
            }
        }

        Debug.Log("All scenes exist!");
    }

    bool SceneExists(string sceneName)
    {
        #if UNITY_EDITOR

        foreach (var scene in EditorBuildSettings.scenes)
        {
            if (scene.path.Contains(sceneName))
            {
                return true;
            }
        }

        #endif

        return false;
    }
}
