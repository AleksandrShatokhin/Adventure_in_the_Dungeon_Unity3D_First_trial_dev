using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainUI : MonoBehaviour
{
    public TextMeshProUGUI coinCounterText;
    public GameObject redKey, greenKey, blueKey;
    public static byte coinCounter = 0;
    public static bool isRedKey = false, isGreenKey = false, isBlueKey = false;


    void Start()
    {
        redKey.SetActive(false);
        blueKey.SetActive(false);
        greenKey.SetActive(false);
    }

    void Update()
    {
        coinCounterText.text = "Монеты: " + coinCounter;

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
