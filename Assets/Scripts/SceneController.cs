using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public void LoadSceneGame()
    {
        SceneManager.LoadScene("Snake");
    }

    public void LoadSceneHighScore()
    {
        SceneManager.LoadScene("HighScore");
    }

    public void LoadSceneMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
