using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainUI : MonoBehaviour
{
    public TextMeshProUGUI coinCounterText, healthText;
    public GameObject redKey, greenKey, blueKey;
    public static byte coinCounter;
    public static bool isRedKey, isGreenKey, isBlueKey;

    public static TextMeshProUGUI finalDoorText;


    void Start()
    {
        redKey.SetActive(false);
        blueKey.SetActive(false);
        greenKey.SetActive(false);

        isRedKey = true;
        isGreenKey = true; 
        isBlueKey = true;

        coinCounter = 0;

        finalDoorText = GameObject.Find("FinalDoorText").GetComponent<TextMeshProUGUI>();
        finalDoorText.text = null;
    }

    void Update()
    {
        coinCounterText.text = "Монеты: " + coinCounter;
        healthText.text = " - " + PlayerController.healthPlayer;

        KeyOnScreen();
    }

    void KeyOnScreen() // проверка подобраны ли ключи и вывод картинки на экран игроку
    {
        if (isBlueKey == true)
            blueKey.SetActive(true);

        if (isGreenKey == true)
            greenKey.SetActive(true);

        if (isRedKey == true)
            redKey.SetActive(true);
    }
}
