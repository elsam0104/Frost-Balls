using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{
    private float endY;

    private Vector3 firstPos;
    private Vector3 endPos;

    [SerializeField]
    private float lerpTime = 2f;
    private float curTime = 0f;

    private void Awake()
    {
        firstPos = transform.position;
        endY = firstPos.y - BallManager.instance.GetTransform().position.y;
        endPos = transform.position;
        endPos.y = endY;
    }
    private void Update()
    {
        print($"endpos{endPos.y} newpos {BallManager.instance.GetTransform().position.y}  {Mathf.Abs(endPos.y - BallManager.instance.GetTransform().position.y)}");
        if (Mathf.Abs(endPos.y - BallManager.instance.GetTransform().position.y) >= 1f) // 기존 endpos와 크기 차이가 10이상 나면 카메라 이동
        {
            curTime = 0f;
            endY = Mathf.Clamp(BallManager.instance.GetTransform().position.y, 4.17f, 32.9f);
        }
    }
    private void LateUpdate()
    {
        curTime += Time.deltaTime;
        if (curTime > lerpTime)
        {
            curTime = lerpTime;
        }
        endPos.y = endY;
        transform.position = Vector3.Lerp(transform.position, endPos, curTime / lerpTime);
    }

}
