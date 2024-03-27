using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowdownArea : MonoBehaviour
{
    // 감속할 정도
    public float slowdownFactor = 0.5f;

    // 충돌체가 영역 안에 들어왔을 때
    private void OnTriggerEnter(Collider other)
    {
        // 충돌체가 자동차인 경우에만 속도 조절
        CarController car = other.GetComponent<CarController>();
        if (car != null)
        {
            // 자동차의 속도를 감속
            car.ApplySlowdown(slowdownFactor);
        }
    }

    // 충돌체가 영역을 빠져나갈 때
    private void OnTriggerExit(Collider other)
    {
        // 충돌체가 자동차인 경우에만 속도 조절
        CarController car = other.GetComponent<CarController>();
        if (car != null)
        {
            // 자동차의 속도를 원래대로 복구
            car.RemoveSlowdown();
        }
    }
}
