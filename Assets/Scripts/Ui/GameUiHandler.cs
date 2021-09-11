using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUiHandler : MonoBehaviour
{
    [SerializeField] Text score;
    [SerializeField] Text bestScoreText;
    [SerializeField] GameObject endGamePanel;
    private bool isGameOver;
    private int points = 0;
    private string username;
    // Start is called before the first frame update
    void Start()
    {
        isGameOver = true;
        endGamePanel.SetActive(false);
        SetCurrentUsername();
        SetCurrentScore();
        SetBestScore();
    }

    public bool GetGameover()
    {
        return isGameOver;
    }

    private void SetCurrentUsername()
    {
        if(MainManager.Instance != null)
        {
            MainManager.Instance.LoadStats();
            this.username = MainManager.Instance.GetUsername();
        }
    }

    private void SetCurrentScore()
    {
        score.text = username + ": " + points;
    }

    private void SetBestScore()
    {
        if (MainManager.Instance != null)
        {
            MainManager.Instance.LoadStats();
            string bestUsername = MainManager.Instance.GetBestUsername();
            int bestScore = MainManager.Instance.GetScore();
            bestScoreText.text = "Best: " + bestUsername + " with " + bestScore;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
