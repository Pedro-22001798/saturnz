using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DeathMenu : MonoBehaviour
{

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        Circle.timer_enabled = true;
        SceneManager.LoadScene("Game");
    }
}
