using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject howToPlayPanel;
    public void PlayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(1);
        ScoreManager.scoreCount = 0;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void howtolay()
    {
        howToPlayPanel.SetActive(true);
    }
}
