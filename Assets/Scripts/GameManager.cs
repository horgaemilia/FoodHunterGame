using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isGameOver;
    private int points = 0;
    private int seconds = 60;
    private int leftSeconds = 60;
    public int GetPoints()
    {
        return points;
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(seconds);
        GameOver();
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
