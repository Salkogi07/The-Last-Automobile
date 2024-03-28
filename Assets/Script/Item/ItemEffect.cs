using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffect : MonoBehaviour
{
    private CameraCotroller camera;
    public float effectDuration = 5f; // ������ ȿ���� ���ӵǴ� �ð�
    public float thrust = 1000f; // ���� ũ��
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
            // �������� �Ծ��� �� ȿ�� ����
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
        // ������ ȿ�� Ȱ��ȭ
        while (effectDuration > 0)
        {
            rigidbody.AddForce(Vector3.forward * thrust);
            effectDuration -= Time.deltaTime;
            yield return null;
        }
        // ������ ȿ�� ��Ȱ��ȭ
        isBoosting = false;
        camera.isboost = false;
    }
}
