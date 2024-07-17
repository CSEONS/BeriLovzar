using UnityEngine;

[CreateAssetMenu(fileName = "MainMenuSingleton", menuName = "Singleton/MainMenuSingleton")]
public class MainMenuSingleton : ScriptableObject
{
    public string LastSelectedLevel;

    private static MainMenuSingleton instance;

    public static MainMenuSingleton Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Resources.Load<MainMenuSingleton>("Singletons/MainMenuSingleton");
            }
            return instance;
        }
    }
}
