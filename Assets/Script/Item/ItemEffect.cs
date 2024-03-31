using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class ItemEffect : MonoBehaviour
{
    public int index;
    public float thrust;
    private CarController car;


    private void Start()
    {
        car = GameObject.FindWithTag("Player").GetComponent<CarController>();
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
            car.speedMultiplier = thrust;
            // 아이템을 먹었을 때 효과 시작
            car.StartBoost();
            Destroy(gameObject);
        }
    }
}
