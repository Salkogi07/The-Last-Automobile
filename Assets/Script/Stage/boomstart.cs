using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boomstart : MonoBehaviour
{
    public RectTransform uiboom;
    public RectTransform uiboomboom;
    public float speed = 150f; // UI 요소의 이동 속도
    public float disappearHeight = -200; // UI 요소가 사라질 높이

    private bool canMove = false;

    public void startboom()
    {
        canMove= true;
        uiboom.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (canMove)
        {
            // UI 요소를 천천히 위로 이동
            uiboom.anchoredPosition += Vector2.down * speed * Time.deltaTime;

            if (uiboom.anchoredPosition.y <= disappearHeight)
            {
                uiboom.gameObject.SetActive(false);
                canMove = false;
                uiboomboom.gameObject.SetActive(true);
            }
        }
    }
}
