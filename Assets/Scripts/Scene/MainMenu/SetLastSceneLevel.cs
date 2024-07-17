using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLastSceneLevel : MonoBehaviour
{
    public void SetLastLevel(GameLevel level)
    {
        MainMenuSingleton.Instance.LastSelectedLevel = level.Name;
    }
}
