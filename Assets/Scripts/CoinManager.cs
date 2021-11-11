using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 endPos;
    public bool isMoveCoin;

    void Start()
    {
        startPos = transform.position;
        endPos.y = transform.position.y + 0.3f;

        isMoveCoin = false;
    }

    void Update()
    {
        transform.Rotate(0, 0, 1);
        
        if (transform.position.y <= startPos.y)
        isMoveCoin = true;

        if (transform.position.y >= endPos.y)
        isMoveCoin = false;

        if (isMoveCoin == true)
        transform.Translate(-Vector3.forward * 0.5f * Time.deltaTime);

        if (isMoveCoin == false)
        transform.Translate(Vector3.forward * 0.5f * Time.deltaTime);
    }
}
