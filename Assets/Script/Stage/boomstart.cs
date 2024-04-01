using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boomstart : MonoBehaviour
{
    public RectTransform uiboom;
    public RectTransform uiboomboom;
    public float speed = 150f; // UI ����� �̵� �ӵ�
    public float disappearHeight = -200; // UI ��Ұ� ����� ����

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
            // UI ��Ҹ� õõ�� ���� �̵�
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
