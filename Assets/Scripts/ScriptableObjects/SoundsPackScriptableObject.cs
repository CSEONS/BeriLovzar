using AYellowpaper.SerializedCollections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundsPack", menuName = "Card/SoundsPack", order = 1)]
public class SoundsPackScriptableObject : ScriptableObject
{
    [SerializeField] private MainMenuSingleton _mainMenuSingleton;

    [SerializedDictionary("Actor", "Voice")] 
    public SerializedDictionary<string, AudioClip> _sounds;
}
