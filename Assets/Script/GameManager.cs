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
    public bool mountainsWheel_buy = false;
    public bool cityWheel_buy = false;
    public bool engine6_buy = false;
    public bool engine8_buy = false;
    public bool breakPart_buy = false;

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
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
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
