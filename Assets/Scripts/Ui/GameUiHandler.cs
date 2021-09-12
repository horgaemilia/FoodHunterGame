using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameUiHandler : MonoBehaviour
{
    [SerializeField] Text score;
    [SerializeField] Text bestScoreText;
    [SerializeField] GameObject endGamePanel;
    [SerializeField] GameManager gameManager;
    [SerializeField] ControlPlayer controlPlayer;
    [SerializeField] Text leftAmmnoText;
    private string username;
    [SerializeField] Text timer;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        controlPlayer = GameObject.Find("Player").GetComponent<ControlPlayer>();
        endGamePanel.SetActive(false);
        SetCurrentUsername();
        SetBestScore();
    }

    void ShowEndGamePanel()
    {
        if (gameManager.GetGameover())
            endGamePanel.SetActive(true);
    }


    private void SetCurrentUsername()
    {
        if(MainManager.Instance != null)
        {
            MainManager.Instance.LoadStats();
            this.username = MainManager.Instance.GetUsername();
        }
    }

    private void UpdateTimer()
    {
        float leftSeconds = gameManager.GetLeftSeconds();
        timer.text = "left: " + leftSeconds + "s";
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

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    // Update is called once per frame
    void Update()
    {
        SetCurrentScore();
        SetAmmnoText();
        UpdateTimer();
        ShowEndGamePanel();
    }
}
