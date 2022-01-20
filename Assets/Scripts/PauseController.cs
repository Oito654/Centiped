using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public GameObject pauseMenu;
    public CamController camController;
    private void Start()
    {
        pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
        UnPauseGame();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        camController.CamSwitch("Pause");
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1;
        camController.CamSwitch("Running");
    }
}
