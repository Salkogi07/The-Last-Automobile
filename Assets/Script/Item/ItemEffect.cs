using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffect : MonoBehaviour
{
    private CameraCotroller camera;
    public float effectDuration = 5f; // 아이템 효과가 지속되는 시간
    public float thrust = 1000f; // 힘의 크기
    public int index;

    private bool isBoosting = false;

    private void Start()
    {
        camera = GameObject.Find("Main Camera").GetComponent<CameraCotroller>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(index == 1)
            {
                GameManager.instance.item4_fast++;
            }
            else if(index == 2)
            {
                GameManager.instance.item5_veryfast++;
            }
            // 아이템을 먹었을 때 효과 시작
            StartBoost(other.GetComponent<Rigidbody>());
            Destroy(gameObject);
        }
    }

    void StartBoost(Rigidbody rb)
    {
        if (!isBoosting)
        {
            isBoosting = true;
            camera.isboost= true;
            StartCoroutine(BoostTimer(rb));
        }
    }

    IEnumerator BoostTimer(Rigidbody rigidbody)
    {
        // 아이템 효과 활성화
        while (effectDuration > 0)
        {
            rigidbody.AddForce(Vector3.forward * thrust);
            effectDuration -= Time.deltaTime;
            yield return null;
        }
        // 아이템 효과 비활성화
        isBoosting = false;
        camera.isboost = false;
    }
}
