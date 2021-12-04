using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    private bool P4 = true, P5 = true; //добавил переменные, чтоб наладить взаимодействие 4 и 5 платформ
    private float speed = 2.0f;

    public GameObject platform_1, platform_2, platform_3, platform_4, platform_5, platform_6, platform_7, platform_8, platform_9;
    private Vector3 startPosP1, startPosP2, startPosP3, startPosP4, startPosP5, startPosP6, startPosP7, startPosP8, startPosP9;
    private Vector3 endPosP1, endPosP2, endPosP3, endPosP4, endPosP5, endPosP6, endPosP7, endPosP8, endPosP9;
    private bool isEndP1 = false, isEndP2 = false, isEndP3 = false, isEndP4 = false, isEndP5 = false, isEndP6 = false, isEndP7 = false, isEndP8 = false, isEndP9 = false;

    public static bool isDeathPlayer = false;


    void Start()
    {
        startPosP1 = platform_1.transform.position;
        endPosP1 = new Vector3(platform_1.transform.position.x + 7, platform_1.transform.position.y, platform_1.transform.position.z);

        startPosP2 = platform_2.transform.position;
        endPosP2 = new Vector3(platform_2.transform.position.x, platform_2.transform.position.y + 10, platform_2.transform.position.z);

        startPosP3 = platform_3.transform.position;
        endPosP3 = new Vector3(platform_3.transform.position.x, platform_3.transform.position.y + 17, platform_3.transform.position.z);

        startPosP4 = platform_4.transform.position;
        endPosP4 = new Vector3(platform_4.transform.position.x + 18, platform_4.transform.position.y, platform_4.transform.position.z);

        startPosP5 = platform_5.transform.position;
        endPosP5 = new Vector3(platform_5.transform.position.x, platform_5.transform.position.y + 10, platform_5.transform.position.z);

        startPosP6 = platform_6.transform.position;
        endPosP6 = new Vector3(platform_6.transform.position.x, platform_6.transform.position.y + 30, platform_6.transform.position.z);

        startPosP7 = platform_7.transform.position;
        endPosP7 = new Vector3(platform_7.transform.position.x - 13, platform_7.transform.position.y, platform_7.transform.position.z);

        startPosP8 = platform_8.transform.position;
        endPosP8 = new Vector3(platform_8.transform.position.x + 13, platform_8.transform.position.y, platform_8.transform.position.z);

        startPosP9 = platform_9.transform.position;
        endPosP9 = new Vector3(platform_9.transform.position.x, platform_9.transform.position.y - 16, platform_9.transform.position.z);
    }

    void Update()
    {
        if (isDeathPlayer == false)
        {
            MovePlatform_1();
            MovePlatform_2();
            MovePlatform_3();
            MovePlatform_4();
            MovePlatform_5();
            MovePlatform_6();
            MovePlatform_7();
            MovePlatform_8();
            MovePlatform_9();
        }
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

    void MovePlatform_3()
    {
        if (platform_3.transform.position.y < startPosP3.y)
            isEndP3 = false;

        if (platform_3.transform.position.y > endPosP3.y)
            isEndP3 = true;

        if (isEndP3 == false)
            platform_3.transform.Translate(Vector3.right * speed * Time.deltaTime);

        if (isEndP3 == true)
            platform_3.transform.Translate(-Vector3.right * speed * Time.deltaTime);
    }

    void MovePlatform_4()
    {
        if (platform_4.transform.position.x < startPosP4.x)
        {
            isEndP4 = false;
            P4 = true;
        }

        if (platform_4.transform.position.x > endPosP4.x)
        {
            isEndP4 = true;
            P4 = false;
        }

        if (isEndP4 == false)
            platform_4.transform.Translate(-Vector3.up * speed * Time.deltaTime);

        if (isEndP4 == true)
           platform_4.transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void MovePlatform_5()
    {
        if (platform_5.transform.position.y < startPosP5.y)
        {
            isEndP5 = false;
            P5 = true;
        }

        if (platform_5.transform.position.y > endPosP5.y)
        {
            isEndP5 = true;
            P5 = false;
        }

        if (isEndP5 == false && P4 == true && P5 == true)
            platform_5.transform.Translate(Vector3.right * speed * Time.deltaTime);

        if (isEndP5 == true && P4 == false && P5 == false)
            platform_5.transform.Translate(-Vector3.right * speed * Time.deltaTime);
    }

    void MovePlatform_6()
    {
        if (platform_6.transform.position.y < startPosP6.y)
            isEndP6 = false;

        if (platform_6.transform.position.y > endPosP6.y)
            isEndP6 = true;

        if (isEndP6 == false)
            platform_6.transform.Translate(Vector3.right * speed * Time.deltaTime);

        if (isEndP6 == true)
            platform_6.transform.Translate(-Vector3.right * speed * Time.deltaTime);
    }

    void MovePlatform_7()
    {
        if (platform_7.transform.position.x < endPosP7.x)
            isEndP7 = true;
        
        if (platform_7.transform.position.x > startPosP7.x)
            isEndP7 = false;

        if (isEndP7 == false)
            platform_7.transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (isEndP7 == true)
            platform_7.transform.Translate(-Vector3.up * speed * Time.deltaTime);
    }

    void MovePlatform_8()
    {
        if (platform_8.transform.position.x < startPosP8.x)
            isEndP8 = false;

        if (platform_8.transform.position.x > endPosP8.x)
            isEndP8 = true;

        if (isEndP8 == false)
            platform_8.transform.Translate(-Vector3.up * speed * Time.deltaTime);

        if (isEndP8 == true)
           platform_8.transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void MovePlatform_9()
    {
        if (platform_9.transform.position.y < endPosP9.y)
            isEndP9 = true;

        if (platform_9.transform.position.y > startPosP9.y)
            isEndP9 = false;

        if (isEndP9 == false)
            platform_9.transform.Translate(-Vector3.right * speed * Time.deltaTime);

        if (isEndP9 == true)
           platform_9.transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}