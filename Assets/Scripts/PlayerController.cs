using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float coinCounter = 0;
    public float speedPlayer;
    public GameObject ballPrefab;

    private Animator playerAnim;
    private Rigidbody jumpPlayer;

    private bool isOnGround = true;

    //private Vector3 posPlayer;
    //public Quaternion rotPlayer;

    private Transform spawnBall;
    

    void Start()
    {
        jumpPlayer = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();

        //posPlayer = transform.position;

        spawnBall = GameObject.Find("SpawnBall").GetComponent<Transform>();
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
    }

    // пропишем проверку на соприкосновение с землей
    private void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.layer == 3)
        {
            isOnGround = true;
        }
        

        if (collision.gameObject.tag == "Coin")
        {
            coinCounter = coinCounter + 1;
            Destroy(collision.gameObject);
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

        /*rotPlayer = transform.rotation;
        //зададим, чтоб не терялось положение по оси z
        if (transform.position.z != posPlayer.z)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            }
        //зададим, чтоб персонаж не падал
        if (transform.rotation.x != rotPlayer.x)
            {
                transform.rotation = Quaternion.Euler(0, transform.rotation.y, transform.rotation.z);
            }
        if (transform.rotation.z != rotPlayer.z)
            {
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);
            }*/
    }
}
