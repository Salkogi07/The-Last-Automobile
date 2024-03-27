using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public RectTransform uiElement; // �̵���ų UI ����� RectTransform
    public float speed = 10f; // UI ����� �̵� �ӵ�
    public float disappearHeight = 200f; // UI ��Ұ� ����� ����

    private bool canMove = true;

    private void Update()
    {
        if (canMove)
        {
            // UI ��Ҹ� õõ�� ���� �̵�
            uiElement.anchoredPosition += Vector2.up * speed * Time.deltaTime;

            if (uiElement.anchoredPosition.y >= disappearHeight)
            {
                uiElement.gameObject.SetActive(false);
                canMove = false;
            }

        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
