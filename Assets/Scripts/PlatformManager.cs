using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    private float speed = 2.0f;
    private Vector3 startPosPlatform_1;
    private Vector3 endPosPlatform_1;
    public bool isEndPlatform_1;
    private Vector3 startPosPlatform_2;
    private Vector3 endPosPlatform_2;
    public bool isEndPlatform_2;
    private Transform platform_1;
    private Transform platform_2;

    void Start()
    {
        platform_1 = GameObject.Find("Platform_1").GetComponent<Transform>();

        startPosPlatform_1 = platform_1.transform.position;
        endPosPlatform_1.x = platform_1.transform.position.x + 7;

        platform_2 = GameObject.Find("Platform_2").GetComponent<Transform>();

        startPosPlatform_2 = platform_2.transform.position;
        endPosPlatform_2.y = platform_2.transform.position.y + 7;
    }

    void Update()
    {
        Platform_1();
        //Platform_2();
    }

    void Platform_1()
    {
        if (platform_1.transform.position.x < startPosPlatform_1.x)
            isEndPlatform_1 = false;

        if (platform_1.transform.position.x > endPosPlatform_1.x)
            isEndPlatform_1 = true;

        if (isEndPlatform_1 == false)
            //platform_1.transform.position = platform_1.transform.position + Vector3.right * speed * Time.deltaTime;
            platform_1.transform.Translate(-Vector3.up * speed * Time.deltaTime);
            //platform_1.transform.position = Vector3.MoveTowards(startPosPlatform_1, endPosPlatform_1, speed * Time.deltaTime);

        if (isEndPlatform_1 == true)
            //platform_1.transform.position = platform_1.transform.position - Vector3.right * speed * Time.deltaTime;
            platform_1.transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void Platform_2()
    {
        if (platform_2.transform.position.y < startPosPlatform_2.y)
            isEndPlatform_2 = false;

        if (platform_2.transform.position.y > endPosPlatform_2.y)
            isEndPlatform_2 = true;

        if (isEndPlatform_2 == false)
            //platform_2.transform.position = platform_2.transform.position + Vector3.up * speed * Time.deltaTime;
            platform_2.transform.Translate(Vector3.right * speed * Time.deltaTime);

        if (isEndPlatform_2 == true)
            //platform_2.transform.position = platform_2.transform.position - Vector3.up * speed * Time.deltaTime;
            platform_2.transform.Translate(-Vector3.right * speed * Time.deltaTime);
    }

    

    void OnCollisionEnter(Collision collision)
    {
        //при сталкновении игрока с платформой игрок двигается на платформе
        if (collision.gameObject.tag == "Player")
        collision.transform.parent = transform;
    }

    void OnCollisionExit(Collision collision)
    {
        //когда игрок покидает платформу прекращаем двигать игрока вместе с платформой
        if (collision.gameObject.tag == "Player")
        collision.transform.parent = null;
    }
}
