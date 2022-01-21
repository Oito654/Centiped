using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadInput : MonoBehaviour
{
    public ScoreName namSet;

    public void ReadStringInput(string s)
    {
        namSet.nameSet = s;
    }
}
