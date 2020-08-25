using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions: MonoBehaviour
{
    public void playButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void attributionsPage()
    {
        SceneManager.LoadScene(3);
    }

    public void mainMenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void quitGameButton()
    {
        Application.Quit();
    }

    public void replayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
