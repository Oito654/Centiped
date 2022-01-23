using System.Collections.Generic;
using UnityEngine;

public class Centiped : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;
    private List<Transform> _segments = new List<Transform>();
    public Transform segmentPrefab;
    public int initalSize = 3;
    public ScoreManager score;
    public GameOverController gameOverController;
    private bool gameOver = true;

    private void Start()
    {
        gameOverController.Restart(_segments, initalSize, segmentPrefab, score);
        gameOver = false;
    }

    private void Update()
    {
        if (this._direction.x != 0f)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                this._direction = Vector2.up;
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                this._direction = Vector2.down;
            }
        }
        else if (this._direction.y != 0f)
        {
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                this._direction = Vector2.right;
            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                this._direction = Vector2.left;
            }
        }
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                gameOver = false;
                gameOverController.Restart(_segments, initalSize, segmentPrefab, score);
            }
        }


    }

    private void FixedUpdate()
    {

        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }

        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + _direction.x,
            Mathf.Round(this.transform.position.y) + _direction.y,
            0.0f
        );
    }

    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;

        _segments.Add(segment);
        score.AddScore();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
            Grow();
        if (other.tag == "Obstacle")
        {
            gameOver = true;
            gameOverController.GameOver();
        }
    }

}
