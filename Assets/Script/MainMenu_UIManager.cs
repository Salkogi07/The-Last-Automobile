using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu_UIManager : MonoBehaviour
{
    [Header("System")]
    public Text textCoint;
    public Image ImgMessage;
    public Text message;

    [Header("Part")]
    GameManager gm;
    public Image ImgDesrtWheel;
    public Image ImgMountainsWheel;
    public Image ImgCityWheel;
    public Image ImgEngine6;
    public Image ImgEngine8;
    public Image ImgBreakPart;

    [Header("RepairShop")]
    public GameObject camer1;
    public GameObject camer2;
    public GameObject camerapoint;
    public GameObject cameraBackpoint;
    public float speed = 1f;
    public bool cameraMove = false;


    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        ImgDesrtWheel.gameObject.SetActive(false);
        ImgMountainsWheel.gameObject.SetActive(false);
        ImgCityWheel.gameObject.SetActive(false);
        ImgEngine6.gameObject.SetActive(false);
        ImgEngine8.gameObject.SetActive(false);
        ImgBreakPart.gameObject.SetActive(false);

        CheckStore();
    }

    private void Update()
    {
        if (cameraMove)
        {
            camer2.transform.position = Vector3.Lerp(camer2.transform.position, camerapoint.transform.position, Time.deltaTime * speed);
        }

        SetCoin();
    }

    private void SetCoin()
    {
        if(gm.coin != 0)
        {
            textCoint.text = GetThousand(gm.coin) + "만원";
        }
        else
        {
            textCoint.text = "0";
        }
    }

    private string GetThousand(int data)
    {
        return string.Format("{0:#,###}", data);
    }

    private void CheckStore()
    {
        if(gm.desrtWheel == true)
        {
            ImgDesrtWheel.gameObject.SetActive(true);
        }
        if(gm.mountainsWheel == true)
        {
            ImgMountainsWheel.gameObject.SetActive(true);
        }
        if(gm.cityWheel == true)
        {
            ImgCityWheel.gameObject.SetActive(true);
        }
        if(gm.engine6 == true)
        {
            ImgEngine6.gameObject.SetActive(true);
        }
        if(gm.engine8 == true)
        {
            ImgEngine8.gameObject.SetActive(true);
        }
        if(gm.breakPart == true)
        {
            ImgBreakPart.gameObject.SetActive(true);
        }
    }

    private void SetMessage(string msg)
    {
        ImgMessage.gameObject.SetActive(true);
        message.text = msg;
    }

    public void Buy_desrtWheel()
    {
        if(gm.desrtWheel_buy_coin < gm.coin)
        {
            ImgDesrtWheel.gameObject.SetActive (true);
            gm.desrtWheel_buy = true;
            gm.coin -= gm.desrtWheel_buy_coin;
        }
        else
        {
            SetMessage("자금이 부족합니다.");
        }
    }

    public void Buy_mountainsWheel()
    {
        if(gm.mountainsWheel_buy_coin < gm.coin)
        {
            ImgMountainsWheel.gameObject.SetActive(true);
            gm.mountainsWheel_buy = true;
        }
        else
        {
            SetMessage("자금이 부족합니다.");
        }
    }

    public void Buy_cityWheel()
    {
        if(gm.cityWheel_buy_coin < gm.coin)
        {
            ImgCityWheel.gameObject.SetActive(true);
            gm.cityWheel_buy = true;
        }
        else
        {
            SetMessage("자금이 부족합니다.");
        }
    }

    public void Buy_engine6()
    {
        if(gm.engine6_buy_coin < gm.coin)
        {
            ImgEngine6.gameObject.SetActive(true);
            gm.engine6_buy = true;
        }
        else
        {
            SetMessage("자금이 부족합니다.");
        }
    }

    public void Buy_engine8()
    {
        if(gm.engine8_buy_coin < gm.coin)
        {
            ImgEngine8.gameObject.SetActive(true);
            gm.engine8_buy = true;
        }
        else
        {
            SetMessage("자금이 부족합니다.");
        }
    }

    public void Buy_breakPart()
    {
        if(gm.breakPart_buy_coin > gm.coin)
        {
            ImgBreakPart.gameObject.SetActive(true);
            gm.breakPart_buy = true;
        }
        else
        {
            SetMessage("자금이 부족합니다.");
        }
    }


    //부품 변경
    public void Were_desrtWheel()
    {
        gm.desrtWheel = !gm.desrtWheel;
        gm.cityWheel = false;
        gm.mountainsWheel = false;
        gm.CheckStatePart();
        WerePartCheeck(ImgDesrtWheel,gm.desrtWheel);
        WerePartCheeck(ImgMountainsWheel, gm.mountainsWheel);
        WerePartCheeck(ImgCityWheel, gm.cityWheel);
    }

    public void Were_mountainsWheel()
    {
        gm.mountainsWheel = !gm.mountainsWheel;
        gm.cityWheel = false;
        gm.desrtWheel= false;
        gm.CheckStatePart();
        WerePartCheeck(ImgDesrtWheel, gm.desrtWheel);
        WerePartCheeck(ImgMountainsWheel, gm.mountainsWheel);
        WerePartCheeck(ImgCityWheel, gm.cityWheel);
    }

    public void Were_cityWheel()
    {
        gm.cityWheel = !gm.cityWheel;
        gm.mountainsWheel = false;
        gm.desrtWheel = false;
        gm.CheckStatePart();
        WerePartCheeck(ImgDesrtWheel, gm.desrtWheel);
        WerePartCheeck(ImgCityWheel, gm.cityWheel);
        WerePartCheeck(ImgMountainsWheel, gm.mountainsWheel);
    }

    public void Were_engine6()
    {
        gm.engine6 = !gm.engine6;
        gm.engine8 = false;
        gm.CheckStatePart();
        WerePartCheeck(ImgEngine6, gm.engine6);
        WerePartCheeck(ImgEngine8, gm.engine8);
    }

    public void Were_engine8()
    {
        gm.engine8 = !gm.engine8;
        gm.engine6 = false;
        gm.CheckStatePart();
        WerePartCheeck(ImgEngine6, gm.engine6);
        WerePartCheeck(ImgEngine8, gm.engine8);
    }

    public void Were_breakPart()
    {
        gm.breakPart = !gm.breakPart;
        gm.CheckStatePart();
        WerePartCheeck(ImgBreakPart, gm.breakPart);
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
