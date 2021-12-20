using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static void IsDeath(GameObject player, GameObject deathWindow)
    {
        Destroy(player);
        CameraController.isDeathPlayer = true;
        PlatformManager.isDeathPlayer = true;
        Instantiate(deathWindow);
    }

    public static void IsEndLevel(GameObject player, GameObject winWindow)
    {
        Destroy(player);
        CameraController.isDeathPlayer = true;
        PlatformManager.isDeathPlayer = true;
        Instantiate(winWindow);
    }
}
