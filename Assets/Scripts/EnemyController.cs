using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5;
    [SerializeField] ControlPlayer controlPlayer;
    [SerializeField] GameObject smoke;
    protected int points;
    [SerializeField] GameManager gameManager;
    protected Rigidbody enemyRb;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        controlPlayer = GameObject.Find("Player").GetComponent<ControlPlayer>();
        enemyRb = gameObject.GetComponent<Rigidbody>();
        SetPoints();
    }

    protected virtual void SetPoints()
    {
        points = 5;
    }

    protected void MoveLeft()
    {
        transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
    }

    protected virtual void Move()
    {
        MoveLeft();
    }
    void DestroyOutOfBounds()
    {
        if (transform.position.x > 30)
            Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        if(controlPlayer.GetAmmunition() != 0 && gameManager.GetGameover() == false)
        {
            GameObject firework = Instantiate(smoke, transform.position, Quaternion.identity);
            firework.GetComponent<ParticleSystem>().Play();
            Destroy(gameObject);
            gameManager.AddPoints(points);           
        }
    }

    private void GameOver()
    {
        if (gameManager.GetGameover() == false)
        {
            GameObject firework = Instantiate(smoke, transform.position, Quaternion.identity);
            firework.GetComponent<ParticleSystem>().Play();
            Destroy(gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
        Move();
        DestroyOutOfBounds();
        GameOver();
    }
}
