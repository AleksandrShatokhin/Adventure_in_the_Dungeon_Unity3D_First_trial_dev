using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject targetPlayer;
    private Vector3 offset = new Vector3(0, 8, -35);

    void Start()
    {
        
    }

    void LateUpdate()
    {
        transform.position = targetPlayer.transform.position + offset;
    }
}
