using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMenu : MonoBehaviour
{
    private int _mainMenuSceneIndex = 0;

    public void GO()
    {
        SceneManager.LoadScene(_mainMenuSceneIndex);
    }
}
