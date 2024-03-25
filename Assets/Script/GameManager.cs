using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("System")]
    public float[] rankScore = new float[5];
    public int stageLevel = 0;

    [Header("Car")]
    public float breakPower = 0f;
    public float downForceValue = 50f;
    public int moterTorque = 500;
    public float maxSpeed = 50f;
    public float steeringMax = 20f;
    public float thrust = 0f;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }
}
