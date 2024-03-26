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
        gm.desrtWheel = true;
        gm.CheckStatePart();
    }

    public void Were_mountainsWheel()
    {
        gm.mountainsWheel = true;
        gm.CheckStatePart();
    }

    public void Were_cityWheel()
    {
        gm.cityWheel = true;
        gm.CheckStatePart();
    }

    public void Were_engine6()
    {
        gm.engine6 = true;
        gm.CheckStatePart();
    }

    public void Were_engine8()
    {
        gm.engine8 = true;
        gm.CheckStatePart();
    }

    public void Were_breakPart()
    {
        gm.breakPart = true;
        gm.CheckStatePart();
    }
}
