using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScores : MonoBehaviour
{
    public HighScoreDisplay[] highScoreDisplayArray;

    List<HighScoreEntry> scores = new List<HighScoreEntry>();

    void Start()
    {
        List<HighScoreEntry> xmlScores = XMLController.instance.LoadScores();

        foreach(HighScoreEntry score in xmlScores)
        {
            AddNewScore(score.name, score.score);
        }

        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        scores.Sort((HighScoreEntry x, HighScoreEntry y) => y.score.CompareTo(x.score));

        for (int i = 0; i < highScoreDisplayArray.Length; i++)
        {
            if (i < scores.Count)
            {
                highScoreDisplayArray[i].DisplayHighScore(scores[i].name, scores[i].score);
            }
            else
            {
                highScoreDisplayArray[i].HideEntryDisplay();
            }
        }
    }

    public void AddNewScore(string entryName, int entryScore)
    {
        scores.Add(new HighScoreEntry { name = entryName, score = entryScore }); 
    }

    public void SaveNewScore(string name, int score)
    {
        AddNewScore(name,score);
        List<HighScoreEntry> scoreToAdd = new List<HighScoreEntry>();
        scoreToAdd.AddRange(scores);
        int scoresEntrysIndex = 0;
        
        for(int i = scoreToAdd.Count; i > 0; i-- )
        {
            scoresEntrysIndex++;
        }

        if(scoresEntrysIndex >= 6)
        {
            scoreToAdd.Sort((HighScoreEntry x, HighScoreEntry y) => y.score.CompareTo(x.score));
            scoreToAdd.RemoveAt(5);
        }

        XMLController.instance.SaveScores(scoreToAdd);   
    }
}
