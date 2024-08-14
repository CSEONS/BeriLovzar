using UnityEngine;

[CreateAssetMenu(fileName = "MainMenuSingleton", menuName = "Singleton/MainMenuSingleton")]
public class MainMenuSingleton : SingletonScriptableObject<MainMenuSingleton>
{
    public string LastSelectedLevel;
}

