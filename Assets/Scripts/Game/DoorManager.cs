using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public GameObject winWindow;
    public GameObject player;
    private byte quantityCoin = 20; //переменная для вывода на экран разницы собранных монет от необходимого кол-ва
    public static bool  inTrigger, isAll; // для проверки вошел ли игрок в зону триггера, чтоб изменять в дальнейшем дествия кнопки выстрела

    void Start()
    {
        inTrigger = false;
        isAll = false;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            inTrigger = true;

            if (MainUI.isRedKey == true && MainUI.isBlueKey == true && MainUI.isGreenKey == true && MainUI.coinCounter >= 20)
            {
                MainUI.finalDoorText.text = "Всё собрано. Нажмите на выстрел";
                isAll = true;
                if (Input.GetKeyDown(KeyCode.E))
                    WinLevel();
            }
            else
                if (quantityCoin - MainUI.coinCounter <= 0)
                    MainUI.finalDoorText.text = "Нужны три ключа";
                else
                    if (quantityCoin - MainUI.coinCounter == 1)
                        MainUI.finalDoorText.text = "Нужны три ключа и ещё " + (quantityCoin - MainUI.coinCounter) + " монета";
                    else
                        MainUI.finalDoorText.text = "Нужны три ключа и ещё " + (quantityCoin - MainUI.coinCounter) + " монет";
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            inTrigger = false;
            MainUI.finalDoorText.text = null;
        }
    }

    public void WinLevel() // вызов победного canvas
    {
        GameObject.Find("Game").GetComponent<GameController>().IsEndLevel(player, winWindow);
    }
}
