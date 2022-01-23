using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public GameObject mainCam;
    public GameObject camOver;

    public void CamSwitch(string state)
    {
        switch(state)
        {
            case "Running":
            mainCam.SetActive(true);
            camOver.SetActive(false);
            break;

            case "GameOver":
            mainCam.SetActive(false);
            camOver.SetActive(true);
            break;
        }
    }

}
