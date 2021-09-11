using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isGameOver;
    private int points = 0;

    public int GetPoints()
    {
        return points;
    }

    public bool GetGameover()
    {
        return isGameOver;
    }
    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
