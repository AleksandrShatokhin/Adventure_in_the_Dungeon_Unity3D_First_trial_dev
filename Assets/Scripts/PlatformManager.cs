using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    private float speed = 2.0f;

    public GameObject platform_1;
    private Vector3 startPosP1;
    private Vector3 endPosP1;
    private bool isEndP1 = false;

    public GameObject platform_2;
    private Vector3 startPosP2;
    private Vector3 endPosP2;
    private bool isEndP2 = false;


    void Start()
    {
        startPosP1 = platform_1.transform.position;
        endPosP1 = new Vector3(platform_1.transform.position.x + 7, platform_1.transform.position.y, platform_1.transform.position.z);

        startPosP2 = platform_2.transform.position;
        endPosP2 = new Vector3(platform_2.transform.position.x, platform_2.transform.position.y + 10, platform_2.transform.position.z);
    }

    void Update()
    {
        MovePlatform_1();
        MovePlatform_2();
    }

    void MovePlatform_1()
    {
        if (platform_1.transform.position.x < startPosP1.x)
            isEndP1 = false;

        if (platform_1.transform.position.x > endPosP1.x)
            isEndP1 = true;

        if (isEndP1 == false)
            platform_1.transform.Translate(-Vector3.up * speed * Time.deltaTime);

        if (isEndP1 == true)
           platform_1.transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void MovePlatform_2()
    {
        if (platform_2.transform.position.y < startPosP2.y)
            isEndP2 = false;
        
        if (platform_2.transform.position.y > endPosP2.y)
            isEndP2 = true;

        if (isEndP2 == false)
            platform_2.transform.Translate(Vector3.right * speed * Time.deltaTime);

        if (isEndP2 == true)
            platform_2.transform.Translate(-Vector3.right * speed * Time.deltaTime);

    }
}
