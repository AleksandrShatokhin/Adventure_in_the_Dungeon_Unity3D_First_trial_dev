using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private float speed = 2.0f;
    private Vector3 startPos;
    private Vector3 endPos;
    public bool isEnd;
//---------------------------------------------------------------------------------------------------------

    void Start()
    {
        startPos = transform.position;
        endPos.x = transform.position.x + 7;
    }

    public void Platform_1()
    {
        GameObject platform = GameObject.Find("Platform_1");
        if (platform.transform.position.x < startPos.x)
            isEnd = false;

        if (platform.transform.position.x > endPos.x)
            isEnd = true;

        if (isEnd == false)
            transform.Translate(-Vector3.up * speed * Time.deltaTime);

        if (isEnd == true)
            transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
