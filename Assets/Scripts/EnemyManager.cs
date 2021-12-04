using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private Animator enemyAnim;
    private Rigidbody enemyRB;

    private Vector3 startEnemyPos, endEnemyPos;
    public bool isEnemyEndPos;
    private float speedEnemy = 2.5f;
    public Transform targetPlayer;
    private float distance; 

    void Start()
    {
        enemyAnim = GetComponent<Animator>();
        enemyRB = GetComponent<Rigidbody>();

        startEnemyPos = transform.position;
        endEnemyPos = new Vector3(transform.position.x + 16, transform.position.y, transform.position.z);
    }

    void Update()
    {
        //вычисляем дистанцию между врагом и игроком
        distance = Vector3.Distance(transform.position, targetPlayer.transform.position);

        Debug.Log(distance);

        if (distance < 10)
            MoveEnemyWhenPlayer();
        else 
            MoveEnemyWhenOne();
    }

    void MoveEnemyWhenPlayer()
    {
        //зададим поворот в направлении нашего игрока
        if (targetPlayer.transform.position.x < transform.position.x) // если наш игрок слева
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, -90, 0), 1);
            enemyAnim.SetFloat("Speed_f", 0.0f);
        }

        if (targetPlayer.transform.position.x > transform.position.x) // если наш игрок справа
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 90, 0), 1);
            enemyAnim.SetFloat("Speed_f", 0.0f);
        }
    }

    void MoveEnemyWhenOne()
    {
        if (transform.position.x < startEnemyPos.x)
            isEnemyEndPos = false;
        
        if (transform.position.x > endEnemyPos.x)
            isEnemyEndPos = true;

        if (isEnemyEndPos == false)
        {
            transform.position = transform.position + Vector3.right * speedEnemy * Time.deltaTime;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 90, 0), 1);
            enemyAnim.SetFloat("Speed_f", 0.3f);
        }
        
        if (isEnemyEndPos == true)
        {
            transform.position = transform.position - Vector3.right * speedEnemy * Time.deltaTime;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, -90, 0), 1);
            enemyAnim.SetFloat("Speed_f", 0.3f);
        }
    }
}
