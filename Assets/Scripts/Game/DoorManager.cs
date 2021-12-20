using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public GameObject winWindow;
    public GameObject player;
    private byte quantityCoin = 20; //переменная для вывода на экран разницы собранных монет от необходимого кол-ва

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            if (MainUI.isRedKey == true && MainUI.isBlueKey == true && MainUI.isGreenKey == true && MainUI.coinCounter >= 20)
            {
                MainUI.finalDoorText.text = "Игрок собрал всё необходимое. Нажмите Е";
                if (Input.GetKeyDown(KeyCode.E))
                    GameController.IsEndLevel(player, winWindow);
            }
            else
                MainUI.finalDoorText.text = "Нужны три ключа и " + (quantityCoin - MainUI.coinCounter) + " монет";
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            MainUI.finalDoorText.text = null;
    }
}
