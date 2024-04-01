using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boom : MonoBehaviour
{
    public RectTransform uiElement; // 이동시킬 UI 요소의 RectTransform
    public boomstart bs;
    public float speed = 10f; // UI 요소의 이동 속도
    public float disappearHeight = -700; // UI 요소가 사라질 높이

    private bool canMove = false;

    private void Awake()
    {
        bs = GetComponent<boomstart>();
    }

    public void planestart()
    {
        canMove = true;
    }

    private void Update()
    {
        if (canMove)
        {
            // UI 요소를 천천히 위로 이동
            uiElement.anchoredPosition += Vector2.left * speed * Time.deltaTime;

            if (uiElement.anchoredPosition.x <= disappearHeight)
            {
                bs.startboom();
            }
            if(uiElement.anchoredPosition.x <= -2000)
            {
                canMove = false;
                uiElement.gameObject.SetActive(false);
            }

        }
    }
}
