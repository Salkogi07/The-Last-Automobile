using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private CarController RR;
    private inputManager inputManager;

    public Image ImgResult;
    public Image ImgLose;
    public Text textResultTime;
    public Text[] textResult;
    public Text[] textRank;
    public int stage = 0;

    private Text textSpeed;
    public float vehicleSpeed;


    public Text textTimer;
    private float startTime;
    private bool isFinished = true;
    float elapsedTime;

    private void Awake()
    {
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
            elapsedTime = Time.time - startTime;
            string minutes = ((int)elapsedTime / 60).ToString("00");
            string seconds = (elapsedTime % 60).ToString("00");
            string milliseconds = ((elapsedTime * 100) % 100).ToString("00");
            textTimer.text = minutes + ":" + seconds + ":" + milliseconds;
        }
    }

    public void AddTime(float time , List<float> playerTimes)
    {
        playerTimes.Add(time);
    }

    public void SortTimes(List<float> playerTimes)
    {
        playerTimes.Sort();
    }

    public void PrintTop5Ranking(List<float> playerTimes)
    {
        // 상위 5위까지만 반복하여 출력
        for (int i = 0; i < Mathf.Min(5, playerTimes.Count); i++)
        {
            string minutes = ((int)playerTimes[i] / 60).ToString("00");
            string seconds = (playerTimes[i] % 60).ToString("00");
            string milliseconds = ((playerTimes[i] * 100) % 100).ToString("00");

            textRank[i].text = "Rank " + (i + 1) + ": Time - " + minutes + ":" + seconds + ":" + milliseconds;
            //Debug.Log("Rank " + (i + 1) + ": Time - " + minutes + ":" + seconds + ":" + milliseconds);
        }
    }

    private void Rank(int getstage)
    {
        if(getstage == 1)
        {
            AddTime(elapsedTime, GameManager.instance.rankScoreStage1);
            SortTimes(GameManager.instance.rankScoreStage1);
            PrintTop5Ranking(GameManager.instance.rankScoreStage1);
        }
        else if(getstage == 2)
        {
            AddTime(elapsedTime,GameManager.instance.rankScoreStage2);
            SortTimes(GameManager.instance.rankScoreStage2);
            PrintTop5Ranking(GameManager.instance.rankScoreStage2);
        }
        else if(getstage == 3)
        {
            AddTime(elapsedTime, GameManager.instance.rankScoreStage3);
            SortTimes(GameManager.instance.rankScoreStage3);
            PrintTop5Ranking(GameManager.instance.rankScoreStage3);
        }
    }

    public void updateNeedle()
    {
        textSpeed.text = (int)vehicleSpeed + "km/h";
    }
    public void FinishGameWin()
    {
        FinishTimer();
        GameManager.instance.FinishGame();
        textResult[0].text = "100만원 획득 : " + GameManager.instance.item1_coin100;
        textResult[1].text = "500만원 획득 : " + GameManager.instance.item2_coin500;
        textResult[2].text = "1000만원 획득 : " + GameManager.instance.item3_coin1000;
        textResult[3].text = "순간 속도 소폭 증가 : " + GameManager.instance.item4_fast;
        textResult[4].text = "순간 속도 대폭 증가 : " + GameManager.instance.item5_veryfast;
        textResult[5].text = "아이템으로 획득한 금액 : " + GameManager.instance.getCoin + "만원";
        Rank(stage);
        ImgResult.gameObject.SetActive(true);
        inputManager.handbrake = true;
        inputManager.enabled = false;
        GameManager.instance.resetGame();
    }

    public void FinishGameLose()
    {
        FinishTimer();
        ImgLose.gameObject.SetActive(true);
        inputManager.handbrake = true;
        inputManager.enabled = false;
        GameManager.instance.resetGame();
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

    public void LoadStage2()
    {
        SceneManager.LoadScene("Stage2");
    }

    public void LoadStage3()
    {
        SceneManager.LoadScene("Stage3");
    }

    public void LoadStageEnd()
    {
        SceneManager.LoadScene("Ending");
    }
}
