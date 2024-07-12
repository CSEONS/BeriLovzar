using UnityEngine;

[CreateAssetMenu(fileName = "SimpleTrainCard", menuName = "Card/SimpleTrainCard", order = 1)]
public class SimpleTrainCardScriptableObject : ScriptableObject
{
    public Sprite Image;
    public AudioClip Audio;
}
