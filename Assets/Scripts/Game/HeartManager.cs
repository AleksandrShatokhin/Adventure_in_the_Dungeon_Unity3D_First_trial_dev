using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartManager : MonoBehaviour
{
    private Vector3 startPosHeart, endPosHeart;
    private bool isEndPos;

    void Start()
    {
        startPosHeart = transform.position;
        endPosHeart.y = transform.position.y + 0.3f;
    }

    void Update()
    {
        //вращение сердечка
        transform.Rotate(0, 0, 1);

        //движение вверх-вниз сердечка
        if (transform.position.y <= startPosHeart.y)
            isEndPos = true;
        if (transform.position.y >= endPosHeart.y)
            isEndPos = false;
        if (isEndPos == true)
            transform.Translate(Vector3.forward * 0.5f * Time.deltaTime);
        if (isEndPos == false)
            transform.Translate(-Vector3.forward * 0.5f * Time.deltaTime);
    }
}
