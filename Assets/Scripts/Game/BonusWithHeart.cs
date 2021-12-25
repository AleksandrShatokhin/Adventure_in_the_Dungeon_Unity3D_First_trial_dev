using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusWithHeart : MonoBehaviour
{
    public GameObject heartPrefab;
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Destroy(gameObject);
            Instantiate(heartPrefab, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), heartPrefab.transform.rotation);
            GameObject.Find("Game").GetComponent<AudioController>().PlayerDestroyBox(); // воспроизведем звук разрушения ящика
        }
    }
}
