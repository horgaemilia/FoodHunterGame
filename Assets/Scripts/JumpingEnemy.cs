using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingEnemy : EnemyController
{
    private bool isJumping = true;
    [SerializeField] float upForce = 8;
    // Start is called before the first frame update

    override protected void SetPoints()
    {
        points = 8;
    }

    protected override void Move()
    {
        base.Move();
        Jump();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }    
    }

    private void Jump()
    {
        if(isJumping == false)
        {
            enemyRb.AddForce(Vector3.up * upForce, ForceMode.Impulse);
            isJumping = true;
        }
    }

}
