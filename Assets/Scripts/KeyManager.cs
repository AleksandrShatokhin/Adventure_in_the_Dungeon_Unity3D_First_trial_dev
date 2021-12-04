using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    private Vector3 startPos, endPos;
    private bool isMoveKey;

    void Start()
    {
        startPos = transform.position;
        endPos.y = transform.position.y + 0.3f;

        isMoveKey = false;
    }

    void Update()
    {
        if (transform.position.y <= startPos.y)
            isMoveKey = true;

        if (transform.position.y >= endPos.y)
            isMoveKey = false;

        if (isMoveKey == true)
            transform.position = transform.position + Vector3.up * 0.3f * Time.deltaTime;
            
        if (isMoveKey == false)
            transform.position = transform.position - Vector3.up * 0.3f * Time.deltaTime;
    }
}
