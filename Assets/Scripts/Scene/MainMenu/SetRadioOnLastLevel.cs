using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRadioOnLastLevel : MonoBehaviour
{
    [SerializeField] private Transform RadioParent;

    private void OnEnable()
    {
        var children = RadioParent.GetComponentsInChildren<GameLevel>();

        if (children.Length == 0)
        {
            Debug.LogError($"{nameof(RadioParent)} children not found!");
        }

        foreach (var child in children)
        {
            if (child.Name == MainMenuSingleton.Instance.LastSelectedLevel) 
            {
                child.Toggle.isOn = true;
            }
        }
    }
}
