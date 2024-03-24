using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public CarController RR;

    //public GameObject neeedle;
    public Text text;
    private float starPosiziton = 220f, endPosition = -41;
    private float desiredpossition;

    public float vehicleSpeed;

    private void Start()
    {
        
    }

    private void Update()
    {
        vehicleSpeed = RR.KPH;
        updateNeedle();
    }

    public void updateNeedle()
    {
        desiredpossition = starPosiziton - endPosition;
        float temp = vehicleSpeed / 180;
        text.text = (int)vehicleSpeed + "km/h";
        //neeedle.transform.eulerAngles = new Vector3(0, 0, (starPosiziton - temp * desiredpossition));
    }
}
