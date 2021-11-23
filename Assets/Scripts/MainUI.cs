using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainUI : MonoBehaviour
{
    public TextMeshProUGUI coinCounterText;
    public static byte coinCounter = 0;

    void Update()
    {
        coinCounterText.text = "Монеты: " + coinCounter;
    }
}
