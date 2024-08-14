using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SimpleTrainCard", menuName = "Card/SimpleTrainCard", order = 1)]
public class SimpleTrainCardScriptableObject : ScriptableObject
{
    public string PrefabName => name;
    public string Name;
    public Sprite Image;
    public AudioClip Audio;
    public List<string> Tags;
}
