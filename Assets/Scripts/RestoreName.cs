using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreName : MonoBehaviour
{
    public string nameSet;

    public void GetRestoredName()
    {
        nameSet = ScoreName.instance.nameSet;
    }
}
