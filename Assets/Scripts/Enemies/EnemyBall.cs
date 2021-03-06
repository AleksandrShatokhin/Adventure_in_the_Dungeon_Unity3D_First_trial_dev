using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBall : MonoBehaviour
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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.layer == 6 || collision.gameObject.layer == 3)
            Destroy(gameObject);
        
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            PlayerController.healthPlayer -= damage;
            GameObject.Find("Game").GetComponent<AudioController>().EnemyHitPlayer(); // звук удара шарика по телу игрока
        }
    }
}
