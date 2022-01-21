using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreDisplay : MonoBehaviour
{
    public Text nameText;
    public Text scoreText;

    public void DisplayHighScore(string name, int score)
    {
        nameText.text = name;
        scoreText.text = score.ToString();
    }

    public void HideEntryDisplay()
    {
        nameText.text = "";
        scoreText.text = "";
    }
}
