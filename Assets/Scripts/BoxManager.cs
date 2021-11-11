using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    public GameObject coinPrefab;
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Destroy(gameObject);
            Instantiate(coinPrefab, transform.position, coinPrefab.transform.rotation);
        }
    }
}
