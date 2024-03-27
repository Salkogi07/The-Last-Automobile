using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trep : MonoBehaviour
{
    bool atcion = false;
    public float speed = 10f;
    public GameObject obj;
    public GameObject point;
    public AudioSource audioSource;
    public AudioClip gorillaSound;


    private void Update()
    {
        if(atcion)
        {
            obj.transform.position = Vector3.Lerp(obj.transform.position, point.transform.position, Time.deltaTime * speed);
        }
    }

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

        // Play gorilla sound
        if (audioSource != null && gorillaSound != null)
        {
            audioSource.PlayOneShot(gorillaSound);
        }

        yield return new WaitForSeconds(2f);
        obj.SetActive(false);
        yield return new WaitForSeconds(3f);
        atcion = false;
    }
}
