using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void loadGameScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void loadMenuScene()
    {
        SceneManager.LoadScene("MainMenue");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
