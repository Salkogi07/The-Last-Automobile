using UnityEngine;

public class test : MonoBehaviour
{
    public float rotationSpeed = 50f;

    void Update()
    {
        // �ڵ����� ȸ����Ű�� �ڵ�
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
