using UnityEngine;

public abstract class SingletonScriptableObject<T> : ScriptableObject where T : ScriptableObject
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Resources.Load<T>($"Singletons/{typeof(T).Name}");

                if (instance == null)
                {
                    instance = CreateInstance<T>();
                    Debug.LogWarning($"{typeof(T).Name} not found in Resources, a new instance has been created. (custom)");
                }
            }
            return instance;
        }
    }

    public static bool ExistsInResources()
    {
        return Resources.Load<T>($"Singletons/{typeof(T).Name}") != null;
    }
}
