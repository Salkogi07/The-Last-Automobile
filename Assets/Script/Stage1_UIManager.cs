using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stage1_UIManager : MonoBehaviour
{
    private CarController RR;
    private inputManager inputManager;

    public Image resultImage;
    public Image loseImage;
    public Text resultTime;

    //public GameObject neeedle;
    private Text speedText;

    public float vehicleSpeed;


    public Text timerText;
    private float startTime;
    private bool isFinished = true;

    private void Awake()
    {
        RR = GameObject.FindWithTag("Player").GetComponent<CarController>();
        inputManager = GameObject.FindWithTag("Player").GetComponent<inputManager>();
        speedText = GameObject.Find("speed").GetComponent<Text>();
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
            timerText.text = minutes + ":" + seconds + ":" + milliseconds;
        }
    }

    public void updateNeedle()
    {
        speedText.text = (int)vehicleSpeed + "km/h";
    }

    public void FinishGameLose()
    {
        FinishTimer();
        loseImage.gameObject.SetActive(true);
        inputManager.handbrake = true;
        inputManager.enabled = false;
    }

    public void FinishGameWin()
    {
        FinishTimer();
        resultImage.gameObject.SetActive(true);
        inputManager.handbrake = true;
        inputManager.enabled = false;
    }

    public void StartTimer()
    {
        startTime = Time.time;
        isFinished = false;
    }

    public void FinishTimer()
    {
        isFinished = true;
        resultTime.text = timerText.text;
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
}
