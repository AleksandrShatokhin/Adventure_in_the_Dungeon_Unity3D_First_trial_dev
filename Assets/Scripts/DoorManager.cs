using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public GameObject winWindow;
    public GameObject player;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            if (MainUI.isRedKey == true && MainUI.isBlueKey == true && MainUI.isGreenKey == true)
            {
                MainUI.finalDoorText.text = "Игрок собрал все ключи. Нажмите Е";
                if (Input.GetKeyDown(KeyCode.E))
                    GameController.IsEndLevel(player, winWindow);
            }
            else
                MainUI.finalDoorText.text = "Нужны три ключа";
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            MainUI.finalDoorText.text = null;
    }
}
