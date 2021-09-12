using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isGameOver;
    private int points = 0;
    private int seconds = 60;
    private int leftSeconds = 60;
    private float elapsedSeconds = 0;
    public int GetPoints()
    {
        return points;
    }

    public void AddPoints(int points)
    {
        this.points += points;
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(seconds);
        GameOver();
    }

    private void ComputeLeftSeconds()
    {
        elapsedSeconds += Time.deltaTime;
        leftSeconds = seconds - Mathf.RoundToInt(elapsedSeconds);
    }

    public bool GetGameover()
    {
        return isGameOver;
    }
    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        StartCoroutine(Timer());
    }

    void GameOver()
    {
        isGameOver = true;
        UpdateBestScore();
    }

    public float GetLeftSeconds()
    {
        return leftSeconds;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver == false)
            ComputeLeftSeconds();
    }

    void UpdateBestScore()
    {
        if (MainManager.Instance != null)
        {
            MainManager.Instance.LoadStats();
            string currentUsername = MainManager.Instance.GetUsername();
            if (points >= MainManager.Instance.GetScore())
            {
                MainManager.Instance.UpdateBestScore(currentUsername, points);
                MainManager.Instance.SaveStats();
            }
        }
    }
}
