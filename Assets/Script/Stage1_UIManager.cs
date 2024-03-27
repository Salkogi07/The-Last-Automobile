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

    public void FinishGameLose()
    {
        FinishTimer();
        ImgLose.gameObject.SetActive(true);
        inputManager.handbrake = true;
        inputManager.enabled = false;
    }

    public void FinishGameWin()
    {
        FinishTimer();
        textResult[0].text = gm.item1_coin100 + "만원";
        ImgResult.gameObject.SetActive(true);
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
        textResultTime.text = textTimer.text;
        // 여기에 게임이 종료될 때의 처리를 추가하세요.
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
