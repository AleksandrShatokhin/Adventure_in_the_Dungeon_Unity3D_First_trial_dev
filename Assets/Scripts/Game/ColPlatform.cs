using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColPlatform : MonoBehaviour
{
    void OnCollisionEnter(Collision collision) //если на платформу попадает игрок, игрок двигается с платформой
    {
        if(collision.gameObject.tag == "Player")
        collision.transform.parent = transform;
    }

    void OnCollisionExit(Collision collision) //если игрок сходит с платформы, движение игрока прекращает быть связаным с платформой
    {
        if(collision.gameObject.tag == "Player")
        collision.transform.parent = null;
    }
}
