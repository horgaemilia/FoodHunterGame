using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
public class MenuUiHandles : MonoBehaviour
{
    [SerializeField] InputField userameInput;
    [SerializeField] Text bestScoreText;

    private void Start()
    {
        bestScoreText.gameObject.SetActive(false);
        SetBestScoreText();
    }


    private void SetBestScoreText()
    {
        if (MainManager.Instance != null)
        {
            MainManager.Instance.LoadStats();
            int score = MainManager.Instance.GetScore();
            string username = MainManager.Instance.GetBestUsername();
            bestScoreText.gameObject.SetActive(true);
            bestScoreText.text = "Best: " + username + ": " + score;
            
        }
    }

    public void Quit()
    {
        if (MainManager.Instance != null)
            MainManager.Instance.SaveStats();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void StartNew()
    {
        string username = userameInput.text.ToString();
        if (username == "")
            username = userameInput.placeholder.GetComponent<Text>().text.ToString();
        if (MainManager.Instance != null)
        {
            MainManager.Instance.LoadStats();
            MainManager.Instance.SetUsername(username);
            MainManager.Instance.SaveStats();
        }
        SceneManager.LoadScene("Game");
    }
}
