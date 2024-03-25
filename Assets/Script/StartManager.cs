using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    private inputManager Player;
    private inputManager AI;
    public Text Countdown;
    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<inputManager>();
        Player.enabled = false;
        AI = GameObject.FindGameObjectWithTag("AI").GetComponent<inputManager>();
        AI.enabled = false;
    }
    void Start()
    {
        StartCoroutine(CountStart());
    }

    IEnumerator CountStart()
    {
        yield return new WaitForSeconds(0.5f);
        Countdown.text = "3";
        //家府
        Countdown.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        Countdown.gameObject.SetActive(false);
        Countdown.text = "2";
        //家府
        Countdown.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        Countdown.gameObject.SetActive(false);
        Countdown.text = "1";
        //家府
        Countdown.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        Countdown.gameObject.SetActive(false);
        //矫累 家府
        //鸥捞赣 矫累
        Player.enabled = true;
        AI.enabled = true;
    }
}
