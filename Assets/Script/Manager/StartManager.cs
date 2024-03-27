using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    private UIManager uiManager;
    private inputManager Player;
    private inputManager AI;
    private Text Countdown;

    private void Awake()
    {
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<inputManager>();
        Player.enabled = false;
        AI = GameObject.FindGameObjectWithTag("AI").GetComponent<inputManager>();
        AI.enabled = false;
        Countdown = GameObject.Find("Countdown").GetComponent<Text>();
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
        uiManager.StartTimer();
        Player.enabled = true;
        AI.enabled = true;
    }
}
