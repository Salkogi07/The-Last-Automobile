using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public RectTransform uiElement; // 이동시킬 UI 요소의 RectTransform
    public boom boom;
    public float speed = 10f; // UI 요소의 이동 속도
    public float disappearHeight = 200f; // UI 요소가 사라질 높이

    private bool canMove = true;

    private void Awake()
    {
        boom = GetComponent<boom>();
    }

    private void Update()
    {
        if (canMove)
        {
            // UI 요소를 천천히 위로 이동
            uiElement.anchoredPosition += Vector2.up * speed * Time.deltaTime;

            if (uiElement.anchoredPosition.y >= disappearHeight)
            {
                uiElement.gameObject.SetActive(false);
                canMove = false;
                boom.planestart();
            }

        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
