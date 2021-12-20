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
            Instantiate(coinPrefab, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), coinPrefab.transform.rotation);
        }
    }
}
