using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManagement : MonoBehaviour
{
    public GameObject player;
    public Button jumpButton, shotButton, moveRightButton, moveLeftButton;
    [SerializeField] private bool isMoveRight, isMoveLeft;


    void Start()
    {
        jumpButton.onClick.AddListener(JumpClick);
        shotButton.onClick.AddListener(ShotClick);
    }

    void Update()
    {
        if (isMoveLeft)
        {
            player.GetComponent<PlayerController>().MoveToLeft();
        }
        else player.GetComponent<Animator>().SetFloat("Speed_f", 0);
        
        if (isMoveRight)
        {
            player.GetComponent<PlayerController>().MoveToRight();
        }
    }

    void JumpClick() // действия при нажатии на кнопку UI для прыжка
    {
        player.GetComponent<PlayerController>().Jump();
    }

    void ShotClick() // действия при нажатии на кнопку UI для выстрела
    {
        if (DoorManager.inTrigger == false) // если игрок не вошел в триггер двери, кнопка стреляет
        {
            player.GetComponent<PlayerController>().Shot();
            GameObject.Find("Game").GetComponent<AudioController>().PlayerCastBall();
        }
        else // если игрок в триггере двери, кнопка позволяет закончить уровень
        {
            if (DoorManager.isAll == true)
                GameObject.Find("Door").GetComponent<DoorManager>().WinLevel();
        }
    }

    public void PointerDownLeft() //по нажатию кнопки влево
    {
        isMoveLeft = true;
    }

    public void PointerUpLeft() //когда отжимается кнопка влево
    {
        isMoveLeft = false;
    }

    public void PointerDownRight() //по нажатию кнопки вправо
    {
        isMoveRight = true;
    }

    public void PointerUpRight() //кгда кнопка вправо отжимается
    {
        isMoveRight = false;
    }
}
