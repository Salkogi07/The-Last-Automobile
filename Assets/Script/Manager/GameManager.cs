using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("System")]
    public List<float> rankScoreStage1;
    public List<float> rankScoreStage2;
    public List<float> rankScoreStage3;
    public bool stage1 = false;
    public bool stage2 = false;
    public bool stage3 = false;
    public int coin = 0;
    public int getCoin = 0;

    [Header("Item")]
    public int item1_coin100 = 0;
    [SerializeField] private int coin_value1 = 100;
    [Space(5)]
    public int item2_coin500 = 0;
    [SerializeField] private int coin_value2 = 500;
    [Space(5)]
    public int item3_coin1000 = 0;
    [SerializeField] private int coin_value3 = 1000;
    [Space(5)]
    public int item4_fast = 0;
    [SerializeField] private int fast_value1 = 1000;
    [Space(5)]
    public int item5_veryfast = 0;
    [SerializeField] private int fast_value2 = 2000;

    [Header("Car")]
    public float breakPower = 0f;
    public float downForceValue = 50f;
    public int moterTorque = 700;
    public float maxSpeed = 80f;
    public float steeringMax = 20f;
    public float thrust1 = 1000f;
    public float thrust2 = 3000f;

    [Header("Store")]
    public bool desrtWheel_buy = false;
    public int desrtWheel_buy_coin = 300;
    [Space(5)]
    public bool mountainsWheel_buy = false;
    public int mountainsWheel_buy_coin = 300;
    [Space(5)]
    public bool cityWheel_buy = false;
    public int cityWheel_buy_coin = 300;
    [Space(5)]
    public bool engine6_buy = false;
    public int engine6_buy_coin = 1000;
    [Space(5)]
    public bool engine8_buy = false;
    public int engine8_buy_coin = 5000;
    [Space(5)]
    public bool breakPart_buy = false;
    public int breakPart_buy_coin = 200;

    [Header("Were")]
    public bool desrtWheel = false;
    public bool mountainsWheel = false;
    public bool cityWheel = false;
    public bool engine6 = false;
    public bool engine8 = false;
    public bool breakPart = false;

    private void Awake()
    {
        instance = this;
    }

    public void CheckStatePart()
    {
        if(engine6 == false && engine8 == false)
        {
            maxSpeed = 80f;
            moterTorque = 700;
        }
        if(engine6 == true)
        {
            maxSpeed = 120f;
            moterTorque = 1500;
        }
        if(engine8 == true)
        {
            maxSpeed = 180f;
            moterTorque = 2000;
        }
        if(breakPart == true)
        {
            breakPower = 9000000f;
        }
        else
        {
            breakPower = 0f;
        }
    }

    public void FinishGame()
    {
        int coin100 = item1_coin100 * coin_value1;
        int coin500 = item2_coin500 * coin_value2;
        int coin1000 = item3_coin1000 * coin_value3;
        getCoin = coin100 + coin500 + coin1000;
        coin = coin + getCoin;
    }

    public void resetGame()
    {
        item1_coin100 = 0;
        item2_coin500 = 0;
        item3_coin1000 = 0;
        item4_fast = 0;
        item5_veryfast = 0;
        getCoin = 0;
    }
}
