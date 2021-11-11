using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    public float speedBall;
    private Rigidbody ball_RB;

    void Start()
    {
        ball_RB = GetComponent<Rigidbody>();
    }

    void Update()
    {   
        //transform.Translate(Vector3.forward * speedBall * Time.deltaTime);

        ball_RB.AddForce(transform.forward * speedBall * Time.deltaTime, ForceMode.Impulse);
    }

    private void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
            {
                Destroy(gameObject);
            }
    }
}
