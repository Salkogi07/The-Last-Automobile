using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainRank : MonoBehaviour
{
    public Text[] Stage1Rank;
    public Text[] Stage2Rank;
    public Text[] Stage3Rank;

    private void Start()
    {
        PrintTop5Ranking(GameManager.instance.rankScoreStage1, Stage1Rank);
        PrintTop5Ranking(GameManager.instance.rankScoreStage2, Stage2Rank);
        PrintTop5Ranking(GameManager.instance.rankScoreStage3, Stage3Rank);
    }

    public void PrintTop5Ranking(List<float> playerTimes, Text[] textRank)
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
}
