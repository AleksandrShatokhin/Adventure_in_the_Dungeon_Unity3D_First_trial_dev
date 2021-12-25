using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speedPlayer;
    public GameObject ballPrefab;
    private GameObject MainGameObj;

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
        MainGameObj = GameObject.Find("Game");

        deathSpace = new Vector3(0, -15, 0); // определяю на каком расстоянии будет умирать игрок при падении в пустоту

        healthPlayer = 5;
    }

    void Update()
    {
        MoveCharacter(); //вызываем метод движения

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
            Jump(); //вызываем метод прыжка игрока

        if (Input.GetKeyDown(KeyCode.F))
            Shot(); //вызываем метод выстрела персонажа
        
        // пока введу данный код для уничтожения игрока, если он провелится в пустоту
        // потенциально сделать метод смерти и вызывать при падении
        if (transform.position.y < deathSpace.y || healthPlayer <= 0)
            MainGameObj.GetComponent<GameController>().IsDeath(gameObject, deathWindow);
    }

    
    void MoveCharacter() //Задаем движение персонажа
    {
        //по нажатию вправо
        if (Input.GetKey(KeyCode.D))
            {
                MoveToRight();
            }
        
        //пришлось убрать пока данную сточку кода, данная строка срабатывает из скрипта UIManagement!!!
        //else playerAnim.SetFloat("Speed_f", 0); 
        
        //по нажатию влево
        if (Input.GetKey(KeyCode.A))
            {
                MoveToLeft();
            }
    }

    public void MoveToRight() //движение персонажа вправо
    {
        transform.Translate(Vector3.forward * speedPlayer * Time.deltaTime /** Input.GetAxis("Horizontal")*/);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 90, 0), 1);
        playerAnim.SetFloat("Speed_f", speedPlayer);
    }

    public void MoveToLeft() //движение персонажа влево
    {
        transform.Translate(Vector3.forward * speedPlayer * Time.deltaTime /** Input.GetAxis("Horizontal")*/);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, -90, 0), 1);
        playerAnim.SetFloat("Speed_f", speedPlayer);
    }

    public void Jump() //пропишем прыжок персонажа
    {
        if (isOnGround)
        {
            jumpPlayer.AddForce(Vector3.up * 420, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            isOnGround = false;
        }
    }

    public void Shot() //пропишем выстрел игроком снаряда
    {
        Instantiate(ballPrefab, spawnBall.transform.position, transform.rotation);
    }

    private void OnCollisionEnter (Collision collision)
    {
        //проверка на столкновение с слоем земли и бонусов (с бонусами необходимо, чтоб от них тоже можно было отпрыгнуть)
        if (collision.gameObject.layer == 3 || collision.gameObject.layer == 8)
        {
            isOnGround = true;
        }
        
        //проверка на столкновение с монетами
        // if (collision.gameObject.tag == "Coin")
        // {
        //     Destroy(collision.gameObject);
        //     MainUI.coinCounter += 1;
        //     playerAudio.PlayOneShot(audioPickedUpCoin, 0.3f); //воспроизведение звука подбора монет
        // }

        if (collision.gameObject.tag == "Heart")
            {
                Destroy(collision.gameObject);
                healthPlayer += 1;
                MainGameObj.GetComponent<AudioController>().PlayerPickedUpHeart(); //воспроизведение звука подбора жизней
            }

        //проверка на столкновение с красным ключем
        if (collision.gameObject.tag == "RedKey")
        {
            MainUI.isRedKey = true;
            Destroy(collision.gameObject);
            MainGameObj.GetComponent<AudioController>().PlayerPickedUpKey(); //воспроизведение звука подбора ключа
        }

        //проверка на столкновение с синим ключем
        if (collision.gameObject.tag == "BlueKey")
        {
            MainUI.isBlueKey = true;
            Destroy(collision.gameObject);
            MainGameObj.GetComponent<AudioController>().PlayerPickedUpKey(); //воспроизведение звука подбора ключа
        }

        //проверка на столкновение с зеленым ключем
        if (collision.gameObject.tag == "GreenKey")
        {
            MainUI.isGreenKey = true;
            Destroy(collision.gameObject);
            MainGameObj.GetComponent<AudioController>().PlayerPickedUpKey(); //воспроизведение звука подбора ключа
        }
    }

    void OnTriggerEnter(Collider collider) //перевел все монетки в триггер, так как при падении сверху на монетку падение игрока замедлялось
    {
        if (collider.gameObject.tag == "Coin")
        {
            Destroy(collider.gameObject);
            MainUI.coinCounter += 1;
            MainGameObj.GetComponent<AudioController>().PlayerPickedUpCoin(); //воспроизведение звука подбора монет
        }
    }
}
