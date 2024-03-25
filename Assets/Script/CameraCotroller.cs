using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraCotroller : MonoBehaviour
{
    private GameObject Player;
    private CarController RR;
    private GameObject cameraConstarint;
    private GameObject camerralookAt;

    private float speed = 0;
    public float defaltFOV = 0, desriedFOV = 0;
    [Range(0,5)]public float smothTime = 0;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        cameraConstarint = Player.transform.Find("camera constraint").gameObject;
        camerralookAt = Player.transform.Find("camera lookAt").gameObject;
        RR = Player.GetComponent<CarController>();
        defaltFOV = Camera.main.fieldOfView;
    }
   
    private void FixedUpdate()
    {
        follow();
        boostFOV();
    }

    private void follow()
    {
        speed = Mathf.Lerp(speed, RR.KPH / 2, Time.deltaTime);

        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position,cameraConstarint.transform.position,Time.deltaTime * speed);
        gameObject.transform.LookAt(camerralookAt.gameObject.transform.position);
    }

    private void boostFOV()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, desriedFOV, Time.deltaTime * smothTime);
        }
        else
        {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, defaltFOV, Time.deltaTime * smothTime);
        }
    }
}
