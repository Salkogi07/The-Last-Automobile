using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("System")]
    public float[] rankScore = new float[5];
    public int stageLevel = 0;
    public int coin = 0;

    [Header("Car")]
    public float breakPower = 0f;
    public float downForceValue = 50f;
    public int moterTorque = 700;
    public float maxSpeed = 80f;
    public float steeringMax = 20f;
    public float thrust = 0f;

    [Header("AI Car")]
    public float AI_breakPower = 900000f;
    public float AI_downForceValue = 50f;
    public int AI_moterTorque = 2000;
    public float AI_maxSpeed = 100f;
    public float AI_steeringMax = 20f;
    public float AI_thrust = 1000f;

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
        DontDestroyOnLoad(gameObject);
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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
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

    }

    public void LoadStage3()
    {

    }
}
