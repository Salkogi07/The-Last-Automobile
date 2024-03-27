using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stage1_UIManager : MonoBehaviour
{
    private GameManager gm;
    private CarController RR;
    private inputManager inputManager;

    public Image ImgResult;
    public Image ImgLose;
    public Text textResultTime;
    public Text[] textResult;

    //public GameObject neeedle;
    private Text textSpeed;

    public float vehicleSpeed;


    public Text textTimer;
    private float startTime;
    private bool isFinished = true;

    private void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        RR = GameObject.FindWithTag("Player").GetComponent<CarController>();
        inputManager = GameObject.FindWithTag("Player").GetComponent<inputManager>();
        textSpeed = GameObject.Find("speed").GetComponent<Text>();
    }

    private void Update()
    {
        vehicleSpeed = RR.KPH;
        updateNeedle();

        if (!isFinished)
        {
            float elapsedTime = Time.time - startTime;
            string minutes = ((int)elapsedTime / 60).ToString("00");
            string seconds = (elapsedTime % 60).ToString("00");
            string milliseconds = ((elapsedTime * 100) % 100).ToString("00");
            textTimer.text = minutes + ":" + seconds + ":" + milliseconds;
        }
    }

    public void updateNeedle()
    {
        textSpeed.text = (int)vehicleSpeed + "km/h";
    }
    public void FinishGameWin()
    {
        FinishTimer();
        gm.FinishGame();
        textResult[0].text = "100���� ȹ�� : " + gm.item1_coin100;
        textResult[1].text = "500���� ȹ�� : " + gm.item2_coin500;
        textResult[2].text = "1000���� ȹ�� : " + gm.item3_coin1000;
        textResult[3].text = "���� �ӵ� ���� ���� : " + gm.item4_fast;
        textResult[4].text = "���� �ӵ� ���� ���� : " + gm.item5_veryfast;
        textResult[5].text = "���������� ȹ���� �ݾ� : " + gm.getCoin + "����";
        ImgResult.gameObject.SetActive(true);
        inputManager.handbrake = true;
        inputManager.enabled = false;
        gm.resetGame();
    }

    public void FinishGameLose()
    {
        FinishTimer();
        ImgLose.gameObject.SetActive(true);
        inputManager.handbrake = true;
        inputManager.enabled = false;
        gm.resetGame();
    }


    public void StartTimer()
    {
        startTime = Time.time;
        isFinished = false;
    }

    public void FinishTimer()
    {
        isFinished = true;
        textResultTime.text = textTimer.text;
        // ���⿡ ������ ����� ���� ó���� �߰��ϼ���.
    }


    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadStage1()
    {
        SceneManager.LoadScene("Stage1");
    }

    public void LoadStage2()
    {
        SceneManager.LoadScene("Stage2");
    }
}
