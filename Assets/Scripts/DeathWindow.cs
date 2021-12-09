using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DeathWindow : MonoBehaviour
{
    public Button restart;
    public Button exit;

    void Start()
    {
        restart.onClick.AddListener(ToRestartLevel);
        exit.onClick.AddListener(ToExitMainMenu);
    }

    void ToRestartLevel()
    {
        SceneManager.LoadScene("MySceneOne");
    }

    void ToExitMainMenu()
    {
        SceneManager.LoadScene("MainManu");
    }
}
