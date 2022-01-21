using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public GameObject mainCam;
    public GameObject camPause;
    public GameObject camOver;

    public void CamSwitch(string state)
    {
        switch(state)
        {
            case "Pause":
            camPause.SetActive(true);
            mainCam.SetActive(false);
            camOver.SetActive(false);
            break;

            case "Running":
            camPause.SetActive(false);
            mainCam.SetActive(true);
            camOver.SetActive(false);
            break;

            case "GameOver":
            mainCam.SetActive(false);
            camPause.SetActive(false);
            camOver.SetActive(true);
            break;
        }
    }

}
