using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainManuManager : MonoBehaviour
{
    public Button start;
    public Button exit;

    void Start()
    {
        start.onClick.AddListener(ToStartGame);
    }

    void ToStartGame()
    {
        SceneManager.LoadScene("MySceneOne");
    }
}
