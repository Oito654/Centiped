using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public GameObject mainCam;
    public GameObject camPause;

    public void CamSwitch(string state)
    {
        switch(state)
        {
            case "Pause":
            camPause.SetActive(true);
            mainCam.SetActive(false);
            break;

            case "Running":
            camPause.SetActive(false);
            mainCam.SetActive(true);
            break;
        }
    }

}
