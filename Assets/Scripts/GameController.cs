using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private float speed;
    private Vector3 startPos;
    private Vector3 endPos;
    private bool isEnd;
    private GameObject platform1;

    // public void Platform_1(float speed, Vector3 startPos, Vector3 endPos, bool isEnd)
    // {
    //     this.speed = speed;
    //     this.startPos = startPos;
    //     this.endPos = endPos;
    //     this.isEnd = isEnd;
    // }

    void Update()
    {
        Platform_1(GameObject.Find("Platform_1"), platform1.transform.position, new Vector3(platform1.transform.position.x + 7, platform1.transform.position.y, platform1.transform.position.z), 2.0f, false);
    }

    // public static void Platform_1()
    // {
    //     float speed = 2.0f;
    //     Vector3 startPos;
    //     Vector3 endPos;
    //     bool isEnd = false;

    //     GameObject platform1 = GameObject.Find("Platform_1");

    //     startPos = platform1.transform.position;
    //     endPos = new Vector3(platform1.transform.position.x + 7, platform1.transform.position.y, platform1.transform.position.z);

    //     if (platform1.transform.position.x <= startPos.x)
    //         isEnd = false;

    //     if (platform1.transform.position.x > endPos.x)
    //         isEnd = true;

    //     if (isEnd == false)
    //         platform1.transform.Translate(Vector3.up * speed * Time.deltaTime);

    //     if (isEnd == true)
    //         platform1.transform.Translate(-Vector3.up * speed * Time.deltaTime);

    //     Debug.Log("Работет");
    // }

    public void Platform_1(GameObject platform1, Vector3 startPos, Vector3 endPos, float speed, bool isEnd)
    {
        this.platform1 = platform1;
        this.startPos = startPos;
        this.endPos = endPos;
        this.speed = speed;
        this.isEnd = isEnd;

        Debug.Log(platform1.transform.position);
    }
}
