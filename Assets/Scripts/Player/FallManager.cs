using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallManager : MonoBehaviour
{
    [SerializeField] private bool isFall;
    [SerializeField] private float timer;
    private float damageTime = 10;
    private float deathTime = 12;

    void Start()
    {
        timer = 0.0f;
    }

    void FixedUpdate()
    {
        if (isFall)
            timer += 0.1f;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball" || collision.gameObject.tag == "Coin" || collision.gameObject.layer == 6) // для игнорирования данных объектов (6 слой - room)
        {
            return;
        }

        if (timer > damageTime)
            PlayerController.healthPlayer -= 1;

        if (timer > deathTime)
            GameObject.Find("Game").GetComponent<GameController>().IsDeath(this.gameObject, this.gameObject.GetComponent<PlayerController>().deathWindow);
        
        isFall = false;
        timer = 0.0f;
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ball" || collision.gameObject.tag == "Coin" || collision.gameObject.layer == 6) // для игнорирования данных объектов (6 слой - room)
        {
            return;
        }

        isFall = true;
    }
}
