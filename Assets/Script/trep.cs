using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trep : MonoBehaviour
{
    bool atcion = false;
    public GameObject obj;

    private void OnTriggerEnter(Collider other)
    {
        if (!atcion)
        {
            StartCoroutine(startobj());
        }
    }

    IEnumerator startobj()
    {
        atcion = true;
        obj.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        obj.SetActive(false);
        yield return new WaitForSeconds(3f);
        atcion = false;
    }
}
