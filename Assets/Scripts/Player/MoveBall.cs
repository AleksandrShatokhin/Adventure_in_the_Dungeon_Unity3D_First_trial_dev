using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    private float speedBall = 50.0f;
    private Rigidbody ball_RB;
    public static int damage = 1;

    void Start()
    {
        ball_RB = GetComponent<Rigidbody>();
    }

    void Update()
    {   
        ball_RB.AddForce(transform.forward * speedBall * Time.deltaTime, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.layer == 6 || collision.gameObject.layer == 3)
            Destroy(gameObject);

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            EnemyController.healthEnemy -= damage;
        }
    }
}
