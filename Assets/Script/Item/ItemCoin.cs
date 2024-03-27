using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCoin : MonoBehaviour
{
    [SerializeField] int index = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (index == 1)
            {
                GameManager.instance.item1_coin100++;
                Destroy(gameObject);
            }
            else if (index == 2)
            {
                GameManager.instance.item2_coin500++;
                Destroy(gameObject);
            }
            else if (index == 3)
            {
                GameManager.instance.item3_coin1000++;
                Destroy(gameObject);
            }
        }
    }
}
