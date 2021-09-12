using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUiHandler : MonoBehaviour
{
    [SerializeField] Text score;
    [SerializeField] Text bestScoreText;
    [SerializeField] GameObject endGamePanel;
    [SerializeField] GameManager gameManager;
    [SerializeField] ControlPlayer controlPlayer;
    [SerializeField] Text leftAmmnoText;
    private string username;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        controlPlayer = GameObject.Find("Player").GetComponent<ControlPlayer>();
        endGamePanel.SetActive(false);
        SetCurrentUsername();
        SetCurrentScore();
        SetBestScore();
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
        int points = gameManager.GetPoints();
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

    private void SetAmmnoText()
    {
        if(controlPlayer != null)
        {
            float leftAmmno = controlPlayer.GetAmmunition();
            leftAmmnoText.text = "Ammunition: " + leftAmmno;
        }
    }

    // Update is called once per frame
    void Update()
    {
        SetAmmnoText();
    }
}
