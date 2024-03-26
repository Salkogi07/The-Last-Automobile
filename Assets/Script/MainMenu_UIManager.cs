using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu_UIManager : MonoBehaviour
{
    GameManager gm;
    public Image desrtWheel;
    public Image mountainsWheel;
    public Image cityWheel;
    public Image engine6;
    public Image engine8;
    public Image breakPart;

    public GameObject camer1;
    public GameObject camer2;
    public GameObject camerapoint;
    public GameObject cameraBackpoint;
    public float speed = 1f;
    public bool cameraMove = false;


    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        desrtWheel.gameObject.SetActive(false);
        mountainsWheel.gameObject.SetActive(false);
        cityWheel.gameObject.SetActive(false);
        engine6.gameObject.SetActive(false);
        engine8.gameObject.SetActive(false);
        breakPart.gameObject.SetActive(false);

        CheckStore();
    }

    private void Update()
    {
        if (cameraMove)
        {
            camer2.transform.position = Vector3.Lerp(camer2.transform.position, camerapoint.transform.position, Time.deltaTime * speed);
        }
    }

    private void CheckStore()
    {
        if(gm.desrtWheel == true)
        {
            desrtWheel.gameObject.SetActive(true);
        }
        if(gm.mountainsWheel == true)
        {
            mountainsWheel.gameObject.SetActive(true);
        }
        if(gm.cityWheel == true)
        {
            cityWheel.gameObject.SetActive(true);
        }
        if(gm.engine6 == true)
        {
            engine6.gameObject.SetActive(true);
        }
        if(gm.engine8 == true)
        {
            engine8.gameObject.SetActive(true);
        }
        if(gm.breakPart == true)
        {
            breakPart.gameObject.SetActive(true);
        }
    }

    public void Buy_desrtWheel()
    {
        desrtWheel.gameObject.SetActive (true);
        gm.desrtWheel_buy = true;
    }

    public void Buy_mountainsWheel()
    {
        mountainsWheel.gameObject.SetActive(true);
        gm.mountainsWheel_buy = true;
    }

    public void Buy_cityWheel()
    {
        cityWheel.gameObject.SetActive(true);
        gm.cityWheel_buy = true;
    }

    public void Buy_engine6()
    {
        engine6.gameObject.SetActive(true);
        gm.engine6_buy = true;
    }

    public void Buy_engine8()
    {
        engine8.gameObject.SetActive(true);
        gm.engine8_buy = true;
    }

    public void Buy_breakPart()
    {
        breakPart.gameObject.SetActive(true);
        gm.breakPart_buy = true;
    }


    //부품 변경
    public void Were_desrtWheel()
    {
        gm.desrtWheel = !gm.desrtWheel;
        gm.cityWheel = false;
        gm.mountainsWheel = false;
        gm.CheckStatePart();
        WerePartCheeck(desrtWheel,gm.desrtWheel);
        WerePartCheeck(mountainsWheel, gm.mountainsWheel);
        WerePartCheeck(cityWheel, gm.cityWheel);
    }

    public void Were_mountainsWheel()
    {
        gm.mountainsWheel = !gm.mountainsWheel;
        gm.cityWheel = false;
        gm.desrtWheel= false;
        gm.CheckStatePart();
        WerePartCheeck(desrtWheel, gm.desrtWheel);
        WerePartCheeck(mountainsWheel, gm.mountainsWheel);
        WerePartCheeck(cityWheel, gm.cityWheel);
    }

    public void Were_cityWheel()
    {
        gm.cityWheel = !gm.cityWheel;
        gm.mountainsWheel = false;
        gm.desrtWheel = false;
        gm.CheckStatePart();
        WerePartCheeck(desrtWheel, gm.desrtWheel);
        WerePartCheeck(cityWheel, gm.cityWheel);
        WerePartCheeck(mountainsWheel, gm.mountainsWheel);
    }

    public void Were_engine6()
    {
        gm.engine6 = !gm.engine6;
        gm.engine8 = false;
        gm.CheckStatePart();
        WerePartCheeck(engine6, gm.engine6);
        WerePartCheeck(engine8, gm.engine8);
    }

    public void Were_engine8()
    {
        gm.engine8 = !gm.engine8;
        gm.engine6 = false;
        gm.CheckStatePart();
        WerePartCheeck(engine6, gm.engine6);
        WerePartCheeck(engine8, gm.engine8);
    }

    public void Were_breakPart()
    {
        gm.breakPart = !gm.breakPart;
        gm.CheckStatePart();
        WerePartCheeck(breakPart, gm.breakPart);
    }

    public void RepairShop()
    {
        camer1.gameObject.SetActive(false);
        camer2.gameObject.SetActive(true);
        cameraMove = true;
    }

    public void RepairShopBack()
    {
        cameraMove = false;
        camer2.transform.position = cameraBackpoint.transform.position;
        camer1.gameObject.SetActive(true);
        camer2.gameObject.SetActive(false);
    }

    public void WerePartCheeck(Image img, bool part)
    {
        if(part == true)
        {
            img.color = Color.green;
        }
        else
        {
            img.color = new Color(164/255f,169/255f,170/255f);
        }
    }
}
