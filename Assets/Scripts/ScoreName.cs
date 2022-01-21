using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreName : MonoBehaviour
{
    public static ScoreName instance;
    public string nameSet;

    private void Awake() 
    {
        instance = this;

        DontDestroyOnLoad(this.gameObject);
    }
}
