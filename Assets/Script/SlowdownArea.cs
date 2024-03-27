using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowdownArea : MonoBehaviour
{
    // ������ ����
    public float slowdownFactor = 0.5f;

    // �浹ü�� ���� �ȿ� ������ ��
    private void OnTriggerEnter(Collider other)
    {
        // �浹ü�� �ڵ����� ��쿡�� �ӵ� ����
        CarController car = other.GetComponent<CarController>();
        if (car != null)
        {
            // �ڵ����� �ӵ��� ����
            car.ApplySlowdown(slowdownFactor);
        }
    }

    // �浹ü�� ������ �������� ��
    private void OnTriggerExit(Collider other)
    {
        // �浹ü�� �ڵ����� ��쿡�� �ӵ� ����
        CarController car = other.GetComponent<CarController>();
        if (car != null)
        {
            // �ڵ����� �ӵ��� ������� ����
            car.RemoveSlowdown();
        }
    }
}
