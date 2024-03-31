using UnityEngine;

public class test : MonoBehaviour
{
    public float rotationSpeed = 50f;

    void Update()
    {
        // 자동차를 회전시키는 코드
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
