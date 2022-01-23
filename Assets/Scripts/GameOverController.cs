using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    public CamController camController;
    public Centiped centiped;
    public Food resetFoodPosition;
    public HighScores highScores;
    public void GameOver()
    {
        Time.timeScale = 0;
        highScores.SaveNewScore(ScoreName.instance.nameSet, (int)centiped.score.score);
        camController.CamSwitch("GameOver");
    }

    public void Restart(List<Transform> segments, int initalSize, Transform segmentPrefab, ScoreManager score)
    {
        Time.timeScale = 1;
        ResetState(segments,initalSize,segmentPrefab,score);
        camController.CamSwitch("Running");
    }

    private void ResetState(List<Transform> segments, int initalSize, Transform segmentPrefab, ScoreManager score)
    {
        for(int i = 1; i < segments.Count; i++)
        {
            Destroy(segments[i].gameObject);
        }

        segments.Clear();
        segments.Add(centiped.transform);

        for(int i = 1; i < initalSize; i++)
        {
            segments.Add(Instantiate(segmentPrefab));
        }

        score.ResetScore();

        resetFoodPosition.RandomizePosition();

        centiped.transform.position = Vector3.zero;
    }
}
