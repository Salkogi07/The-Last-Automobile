using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boom : MonoBehaviour
{
    public RectTransform uiElement; // �̵���ų UI ����� RectTransform
    public boomstart bs;
    public float speed = 10f; // UI ����� �̵� �ӵ�
    public float disappearHeight = -700; // UI ��Ұ� ����� ����

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
            // UI ��Ҹ� õõ�� ���� �̵�
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
