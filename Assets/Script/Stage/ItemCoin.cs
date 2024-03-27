using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCoin : MonoBehaviour
{
    [SerializeField] int index = 0;
    private GameManager gm;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (index == 1)
            {
                gm.item1_coin100++;
                Destroy(gameObject);
            }
            else if (index == 2)
            {
                gm.item2_coin500++;
                Destroy(gameObject);
            }
            else if (index == 3)
            {
                gm.item3_coin1000++;
                Destroy(gameObject);
            }
        }
    }
}
