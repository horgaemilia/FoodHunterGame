using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void MoveLeft()
    {
        transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
    }

    void DestroyOutOfBounds()
    {
        if (transform.position.x > 30)
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        MoveLeft();
        DestroyOutOfBounds();
    }
}
