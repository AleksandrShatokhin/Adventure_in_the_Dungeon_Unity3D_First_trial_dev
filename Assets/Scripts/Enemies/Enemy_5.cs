using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_5 : MonoBehaviour
{
    private Animator enemyAnim;
    private Rigidbody enemyRB;

    private Vector3 startEnemyPos, endEnemyPos;
    public bool isEnemyEndPos;
    private float speedEnemy = 2.5f;
    public Transform targetPlayer;
    private Transform spawnBall;
    public GameObject ballPrefab;
    private float distance;
    private float nextShot = 0.0f, shotRate = 2.0f; // переменные для контроля выстрелов
    public static int healthEnemy;
    private bool isAudioDeath;


    void Start()
    {
        enemyAnim = GetComponent<Animator>();
        enemyRB = GetComponent<Rigidbody>();

        targetPlayer = GameObject.Find("Player").GetComponent<Transform>();
        spawnBall = GameObject.Find("EnemySpawnBall_5").GetComponent<Transform>();

        startEnemyPos = transform.position;
        endEnemyPos = new Vector3(transform.position.x + 20, transform.position.y, transform.position.z);

        healthEnemy = 3;
        isAudioDeath = false;
    }

    void Update()
    {
        //вычисляем дистанцию между врагом и игроком
        distance = Vector3.Distance(transform.position, targetPlayer.transform.position);

        if (distance < 10)
            MoveEnemyWhenPlayer();
        else 
            MoveEnemyWhenOne();

        // сделаем проверку жизней вражеского персонажа и обратимся к методу смерти
        if (healthEnemy == 0)
            EnemyDeath();
    }

    void MoveEnemyWhenPlayer()
    {
        //зададим поворот в направлении нашего игрока
        if (targetPlayer.transform.position.x < transform.position.x) // если наш игрок слева
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, -90, 0), 1);
            enemyAnim.SetFloat("Speed_f", 0.0f);
            
            //чтоб выстрел не происходил, когда персонаж убит, добавлю доп условие
            if (healthEnemy > 0)
                EnemyShot();
        }

        if (targetPlayer.transform.position.x > transform.position.x) // если наш игрок справа
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 90, 0), 1);
            enemyAnim.SetFloat("Speed_f", 0.0f);
            
            //чтоб выстрел не происходил, когда персонаж убит, добавлю доп условие
            if (healthEnemy > 0)
                EnemyShot();
        }
    }

    void MoveEnemyWhenOne()
    {// зададим движение вражеского персонажа, когда нет рядом игрока
        if (transform.position.x < startEnemyPos.x)
            isEnemyEndPos = false;
        
        if (transform.position.x > endEnemyPos.x)
            isEnemyEndPos = true;

        if (isEnemyEndPos == false)
        {   //вражеский персонаж идет вправо, его тело поворачивается вправо
            transform.position = transform.position + Vector3.right * speedEnemy * Time.deltaTime;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 90, 0), 1);
            enemyAnim.SetFloat("Speed_f", 0.3f);
        }
        
        if (isEnemyEndPos == true)
        {   //вражеский персонаж идет влево, его тело поворачивается влево
            transform.position = transform.position - Vector3.right * speedEnemy * Time.deltaTime;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, -90, 0), 1);
            enemyAnim.SetFloat("Speed_f", 0.3f);
        }
    }

    void EnemyShot()
    {
        // отдельно мне еще понадобилось проверить положение игрока по У относительно персонажа врага
        // чтоб не происходило вражеского выстрела, когда игрок находится выше или ниже уровня вражеского персонажа
        // значения при проверке округлил до целого
        if (Time.time > nextShot && Mathf.Round(targetPlayer.transform.position.y) == Mathf.Round(transform.position.y))
            {
                nextShot = Time.time + shotRate;
                Instantiate(ballPrefab, spawnBall.transform.position, transform.rotation);
                GameObject.Find("Game").GetComponent<AudioController>().EnemyCastBall();
            }
    }

    void EnemyDeath()
    {
        enemyAnim.SetBool("Death_b", true);
        Destroy(gameObject, 2.0f);

        if (isAudioDeath == false)
        {
            GameObject.Find("Game").GetComponent<AudioController>().PlayerDeathEnemy(); // воспроизводим звук смерти
            isAudioDeath = true;
        }
    }
}
