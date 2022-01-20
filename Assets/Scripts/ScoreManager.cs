using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public Text scoreText;
    // public Text highscoreText;

    float score = 0;
    float highScore;
    public float transitionSpeed = 70;
    float displayScore;

    void Start()
    {
        scoreText.text = string.Format("SCORE: {0:00000}", displayScore);
    }

    private void Update()
    {
        displayScore = Mathf.MoveTowards(displayScore, score, transitionSpeed * Time.deltaTime);
        UpdateScoreDisplay();
    }

    public void UpdateScoreDisplay()
    {
        scoreText.text = string.Format("SCORE: {0:00000}", displayScore);
    }

    public void AddScore() 
    {
        score += 5;
    }

    public void ResetScore()
    {
        highScore = score;
        score = 0;
    }
}
