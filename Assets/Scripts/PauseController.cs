using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject pauseMenu;
    public CamController camController;
    public void Start()
    {
        pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
        isPaused = false;
        PauseMenuController(isPaused);
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
        PauseMenuController(isPaused);
    }

    private void UnPauseGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        PauseMenuController(isPaused);
    }

    // public bool GetIsPaused()
    // {

    // }

    public void PauseMenuController(bool isPaused)
    {
        if (isPaused == true)
        {
            pauseMenu.SetActive(true);
        }
        else
        {
            pauseMenu.SetActive(false);
        }
    }
}
