using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speedPlayer;
    public GameObject ballPrefab;

    private Animator playerAnim;
    private Rigidbody jumpPlayer;

    private bool isOnGround = true;

    private Vector3 deathSpace;

    private Transform spawnBall;
    

    void Start()
    {
        jumpPlayer = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();

        spawnBall = GameObject.Find("SpawnBall").GetComponent<Transform>();

        deathSpace = new Vector3(0, -15, 0); // определяю на каком расстоянии будет умирать игрок при падении в пустоту
    }

    void Update()
    {
        MoveCharecter();

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
        if (transform.position.y < deathSpace.y)
        {
            GameController.IsDeath(GameObject.Find("Player"));
        }
    }

    // пропишем проверку на соприкосновение с землей
    private void OnCollisionEnter (Collision collision)
    {
        //проверка на столкновение с слоем земли
        if (collision.gameObject.layer == 3)
        {
            isOnGround = true;
        }
        
        //проверка на столкновение с монетами
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            MainUI.coinCounter += 1;
        }
    }

    //Задаем движение персонажа
    void MoveCharecter() 
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
}
