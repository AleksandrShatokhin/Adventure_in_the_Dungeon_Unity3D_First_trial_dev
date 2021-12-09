using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speedPlayer;
    public GameObject ballPrefab;

    public GameObject deathWindow; // понадобилась переменная именно в этом скрипте, чтоб передать ее значение в GameController
    // при обращении к методу смерти игрока

    private Animator playerAnim;
    private Rigidbody jumpPlayer;

    private bool isOnGround = true;

    private Vector3 deathSpace;

    private Transform spawnBall;
    public static int healthPlayer;
    

    void Start()
    {
        jumpPlayer = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();

        spawnBall = GameObject.Find("SpawnBall").GetComponent<Transform>();

        deathSpace = new Vector3(0, -15, 0); // определяю на каком расстоянии будет умирать игрок при падении в пустоту

        healthPlayer = 5;
    }

    void Update()
    {
        MoveCharacter();

        //пропишем прыжок персонажа
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
            {
                jumpPlayer.AddForce(Vector3.up * 420, ForceMode.Impulse);
                playerAnim.SetTrigger("Jump_trig");
                isOnGround = false;
            }
        
        //пропишем выстрел игроком снаряда
        if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Instantiate(ballPrefab, spawnBall.transform.position, transform.rotation);
            }
        
        // пока введу данный код для уничтожения игрока, если он провелится в пустоту
        // потенциально сделать метод смерти и вызывать при падении
        if (transform.position.y < deathSpace.y || healthPlayer == 0)
            GameController.IsDeath(gameObject, deathWindow);
    }

    //Задаем движение персонажа
    void MoveCharacter() 
    {
        //по нажатию вправо
        if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.forward * speedPlayer * Time.deltaTime * Input.GetAxis("Horizontal"));
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 90, 0), 1);
                playerAnim.SetFloat("Speed_f", speedPlayer);
            }
        else playerAnim.SetFloat("Speed_f", 0);
        //по нажатию влево
        if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.back * speedPlayer * Time.deltaTime * Input.GetAxis("Horizontal"));
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, -90, 0), 1);
                playerAnim.SetFloat("Speed_f", speedPlayer);
            }
    }

    private void OnCollisionEnter (Collision collision)
    {
        //проверка на столкновение с слоем земли
        if (collision.gameObject.layer == 3 || collision.gameObject.layer == 8)
        {
            isOnGround = true;
        }
        
        //проверка на столкновение с монетами
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            MainUI.coinCounter += 1;
        }

        //проверка на столкновение с красным ключем
        if (collision.gameObject.tag == "RedKey")
        {
            MainUI.isRedKey = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "BlueKey")
        {
            MainUI.isBlueKey = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "GreenKey")
        {
            MainUI.isGreenKey = true;
            Destroy(collision.gameObject);
        }
    }
}
