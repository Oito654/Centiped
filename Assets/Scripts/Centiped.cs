using System.Collections.Generic;
using UnityEngine;

public class Centiped : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;
    private List<Transform> _segments = new List<Transform>();
    public Transform segmentPrefab;
    public Food resetFoodPosition;
    public int initalSize = 3;
    public ScoreManager score;
    public GameObject pauseMenu;
    public GameObject mainCam;
    public GameObject camPause;
    public bool isPaused = true;

    private void Start() {
        ResetState();
        pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
        isPaused = false;
        PauseMenuController(isPaused);
    }

    private void Update() 
    {
        if(!isPaused)
        {
            if (this._direction.x != 0f)
            {
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
                    this._direction = Vector2.up;
                } else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
                    this._direction = Vector2.down;
                }
            }
            else if (this._direction.y != 0f)
            {
                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
                    this._direction = Vector2.right;
                } else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
                    this._direction = Vector2.left;
                }
            }
        }
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(!isPaused)
            {
                PauseGame();
            } 
            else 
            {
                UnPauseGame();    
            }
        }
         
    }

    private void FixedUpdate() 
    {

        for(int i = _segments.Count - 1; i > 0; i--)
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
       segment.position = _segments[ _segments.Count - 1].position;

       _segments.Add(segment);
       score.AddScore();
    }

    private void ResetState()
    {
        for(int i = 1; i < _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }

        _segments.Clear();
        _segments.Add(this.transform);

        for(int i = 1; i < this.initalSize; i++)
        {
            _segments.Add(Instantiate(this.segmentPrefab));
        }

        score.ResetScore();

        resetFoodPosition.RandomizePosition();

        this.transform.position = Vector3.zero;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Food")
            Grow();
        if(other.tag == "Obstacle")
            ResetState();
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
        PauseMenuController(isPaused);
    }

    private void UnPauseGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        PauseMenuController(isPaused);
    }

    public void PauseMenuController(bool isPaused)
    {
        if(isPaused == true)
        {
            pauseMenu.SetActive(true);
            camPause.SetActive(true);
            mainCam.SetActive(false);
        }
        else
        {
            pauseMenu.SetActive(false);
            camPause.SetActive(false);
            mainCam.SetActive(true);
        }
    }

}
