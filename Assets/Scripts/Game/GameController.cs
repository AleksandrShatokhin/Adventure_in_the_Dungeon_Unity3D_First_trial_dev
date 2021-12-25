using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject Enemy_1, Enemy_2, Enemy_3, Enemy_4, Enemy_5;
    public GameObject SpawnEnemy_1, SpawnEnemy_2, SpawnEnemy_3, SpawnEnemy_4, SpawnEnemy_5;

    void Start()
    {
        SpawnEnemy(); // спауним всех enemy при старте игры (рестарте)
    }
    public void IsDeath(GameObject player, GameObject deathWindow)
    {
        Destroy(player);
        CameraController.isDeathPlayer = true;
        PlatformManager.isDeathPlayer = true;
        Instantiate(deathWindow);
        this.gameObject.GetComponent<AudioController>().GameOver(); // для воспроизведения звука смерти игрока
    }

    public void IsEndLevel(GameObject player, GameObject winWindow)
    {
        Destroy(player);
        CameraController.isDeathPlayer = true;
        PlatformManager.isDeathPlayer = true;
        Instantiate(winWindow);
        this.gameObject.GetComponent<AudioController>().PlayerWinLevel(); // для воспроизведения звука открывания финальной двери
    }

    public void SpawnEnemy()
    {
        Instantiate(Enemy_1, SpawnEnemy_1.transform.position, Enemy_1.transform.rotation);
        Instantiate(Enemy_2, SpawnEnemy_2.transform.position, Enemy_2.transform.rotation);
        Instantiate(Enemy_3, SpawnEnemy_3.transform.position, Enemy_3.transform.rotation);
        Instantiate(Enemy_4, SpawnEnemy_4.transform.position, Enemy_4.transform.rotation);
        Instantiate(Enemy_5, SpawnEnemy_5.transform.position, Enemy_5.transform.rotation);
    }
}
