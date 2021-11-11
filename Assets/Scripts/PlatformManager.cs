using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    private float speed = 2.0f;
    private Vector3 startPos; // = new Vector3(23, 5, 0);
    private Vector3 endPos; // = new Vector3(30, 5, 0);
    private bool isEnd;

    void Start()
    {
        startPos = transform.position;
        endPos.x = transform.position.x + 7;
    }

    void Update()
    {
        if (transform.position.x < startPos.x)
            isEnd = false;

        if (transform.position.x > endPos.x)
            isEnd = true;

        if (isEnd == false)
            transform.Translate(-Vector3.up * speed * Time.deltaTime);

        if (isEnd == true)
            transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
