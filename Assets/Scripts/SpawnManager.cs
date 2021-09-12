using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] GameManager gameManager;
    private float xPosition = -4;
    private float yPosition = 1;
    private float zPosition = 0;
    private float startTime = 1;
    private float delay = 1f;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        InvokeRepeating("SpawnEnemy", startTime, delay);
    }

    void SpawnEnemy()
    {
        if (gameManager.GetGameover() == false)
        {
            int randomIndex = Random.Range(0, enemyPrefabs.Count);
            Vector3 position = new Vector3(xPosition, yPosition, zPosition);
            Instantiate(enemyPrefabs[randomIndex], position, enemyPrefabs[randomIndex].transform.rotation);
        }
    }
}
