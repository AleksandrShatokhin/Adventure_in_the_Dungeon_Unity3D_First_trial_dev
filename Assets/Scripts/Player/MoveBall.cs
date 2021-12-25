using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    private float speedBall = 50.0f;
    private Rigidbody ball_RB;
    public static int damage = 1;
    private GameObject MainGameObj;

    void Start()
    {
        ball_RB = GetComponent<Rigidbody>();

        MainGameObj = GameObject.Find("Game");
        //MainGameObj.GetComponent<AudioController>().PlayerCastBall();
    }

    void Update()
    {   
        ball_RB.AddForce(transform.forward * speedBall * Time.deltaTime, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.layer == 6 || collision.gameObject.layer == 3) //слои 3 и 6 - объекты помещения
            Destroy(gameObject);

        if (collision.gameObject.tag == "RedKey" || collision.gameObject.tag == "BlueKey" || collision.gameObject.tag == "GreenKey" || collision.gameObject.tag == "Coin" || collision.gameObject.tag == "Heart")
            Destroy(gameObject);

        // так как у меня получается несколько врагов на уровне
        // появилась необходимость объединить их под один слой
        // и разделить на разные тэги
        if (collision.gameObject.layer == 9)
        {
            Destroy(gameObject);

            // попадание снаряда в первого врага
            if (collision.gameObject.tag == "Enemy")
            {
                Enemy_1.healthEnemy -= damage;
                MainGameObj.GetComponent<AudioController>().PlayerHitEnemy(); // звук удара шарика по телу
            }
            
            // попадание снаряда во второго врага
            if (collision.gameObject.tag == "Enemy_2")
            {
                Enemy_2.healthEnemy -= damage;
                MainGameObj.GetComponent<AudioController>().PlayerHitEnemy(); // звук удара шарика по телу
            }

            // попадание снаряда в третьего врага
            if (collision.gameObject.tag == "Enemy_3")
            {
                Enemy_3.healthEnemy -= damage;
                MainGameObj.GetComponent<AudioController>().PlayerHitEnemy(); // звук удара шарика по телу
            }

            // попадание снаряда в четвертого врага
            if (collision.gameObject.tag == "Enemy_4")
            {
                Enemy_4.healthEnemy -= damage;
                MainGameObj.GetComponent<AudioController>().PlayerHitEnemy(); // звук удара шарика по телу
            }

            // попадание снаряда в пятого врага
            if (collision.gameObject.tag == "Enemy_5")
            {
                Enemy_5.healthEnemy -= damage;
                MainGameObj.GetComponent<AudioController>().PlayerHitEnemy(); // звук удара шарика по телу
            }
        }
    }
}
