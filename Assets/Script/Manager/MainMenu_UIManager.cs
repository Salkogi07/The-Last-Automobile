using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu_UIManager : MonoBehaviour
{
    [Header("System")]
    public Text textCoint;
    public Image ImgMessage;
    public Text message;

    [Header("Part")]
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

    [Header("Part Coin Text")]
    public Text textDesertWheel;
    public Text textMountainsWheel;
    public Text textCityWheel;
    public Text textEngine6;
    public Text textEngine8;
    public Text textBreakPart;


    void Start()
    {
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
        SetPartCoin();
        CheckStore();
        WerePartCheeck(ImgDesrtWheel, GameManager.instance.desrtWheel);
        WerePartCheeck(ImgMountainsWheel, GameManager.instance.mountainsWheel);
        WerePartCheeck(ImgCityWheel, GameManager.instance.cityWheel);
        WerePartCheeck(ImgEngine6, GameManager.instance.engine6);
        WerePartCheeck(ImgEngine8, GameManager.instance.engine8);
        WerePartCheeck(ImgBreakPart, GameManager.instance.breakPart);
    }

    private void SetPartCoin()
    {
        PartCoinCheeck(textDesertWheel, GameManager.instance.desrtWheel_buy_coin);
        PartCoinCheeck(textMountainsWheel, GameManager.instance.mountainsWheel_buy_coin);
        PartCoinCheeck(textCityWheel, GameManager.instance.cityWheel_buy_coin);
        PartCoinCheeck(textEngine6, GameManager.instance.engine6_buy_coin);
        PartCoinCheeck(textEngine8 , GameManager.instance.engine8_buy_coin);
        PartCoinCheeck(textBreakPart, GameManager.instance.breakPart_buy_coin);
    }

    private void PartCoinCheeck(Text text, int coin)
    {
        if(coin != 0)
        {
            text.text = coin + "만원";
        }
        else
        {
            text.text = coin + "원";
        }
    }

    private void SetCoin()
    {
        if(GameManager.instance.coin != 0)
        {
            textCoint.text = GetThousand(GameManager.instance.coin) + "만원";
        }
        else
        {
            textCoint.text = GameManager.instance.coin + "원";
        }
    }

    private string GetThousand(int data)
    {
        return string.Format("{0:#,###}", data);
    }

    private void CheckStore()
    {
        if(GameManager.instance.desrtWheel_buy == true)
        {
            ImgDesrtWheel.gameObject.SetActive(true);
        }
        if(GameManager.instance.mountainsWheel_buy == true)
        {
            ImgMountainsWheel.gameObject.SetActive(true);
        }
        if(GameManager.instance.cityWheel_buy == true)
        {
            ImgCityWheel.gameObject.SetActive(true);
        }
        if(GameManager.instance.engine6_buy == true)
        {
            ImgEngine6.gameObject.SetActive(true);
        }
        if(GameManager.instance.engine8_buy == true)
        {
            ImgEngine8.gameObject.SetActive(true);
        }
        if(GameManager.instance.breakPart_buy == true)
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
        if(!GameManager.instance.desrtWheel_buy)
        {
            if(GameManager.instance.desrtWheel_buy_coin <= GameManager.instance.coin)
            {
                GameManager.instance.desrtWheel_buy = true;
                GameManager.instance.coin -= GameManager.instance.desrtWheel_buy_coin;
                SetMessage("구매에 성공하였습니다.");
            }
            else
            {
                SetMessage("자금이 부족합니다.");
            }
        }
        else
        {
            SetMessage("이미 구매한 상품입니다.");
        }
    }

    public void Buy_mountainsWheel()
    {
        if(!GameManager.instance.mountainsWheel_buy)
        {
            if(GameManager.instance.mountainsWheel_buy_coin <= GameManager.instance.coin)
            {
                GameManager.instance.mountainsWheel_buy = true;
                GameManager.instance.coin -= GameManager.instance.mountainsWheel_buy_coin;
                SetMessage("구매에 성공하였습니다.");
            }
            else
            {
                SetMessage("자금이 부족합니다.");
            }
        }
        else
        {
            SetMessage("이미 구매한 상품입니다.");
        }
    }

    public void Buy_cityWheel()
    {
        if( !GameManager.instance.cityWheel_buy)
        {
            if(GameManager.instance.cityWheel_buy_coin <= GameManager.instance.coin)
            {
                GameManager.instance.cityWheel_buy = true;
                GameManager.instance.coin -= GameManager.instance.cityWheel_buy_coin;
                SetMessage("구매에 성공하였습니다.");
            }
            else
            {
                SetMessage("자금이 부족합니다.");
            }
        }
        else
        {
            SetMessage("이미 구매한 상품입니다.");
        }
    }

    public void Buy_engine6()
    {
        if(!GameManager.instance.engine6_buy)
        {
            if(GameManager.instance.engine6_buy_coin <= GameManager.instance.coin)
            {
                GameManager.instance.engine6_buy = true;
                GameManager.instance.coin -= GameManager.instance.engine6_buy_coin;
                SetMessage("구매에 성공하였습니다.");
            }
            else
            {
                SetMessage("자금이 부족합니다.");
            }
        }
        else
        {
            SetMessage("이미 구매한 상품입니다.");
        }
    }

    public void Buy_engine8()
    {
        if(!GameManager.instance.engine8_buy)
        {
            if(GameManager.instance.engine8_buy_coin <= GameManager.instance.coin)
            {
                GameManager.instance.engine8_buy = true;
                GameManager.instance.coin -= GameManager.instance.engine8_buy_coin;
                SetMessage("구매에 성공하였습니다.");
            }
            else
            {
                SetMessage("자금이 부족합니다.");
            }
        }
        else
        {
            SetMessage("이미 구매한 상품입니다.");
        }
    }

    public void Buy_breakPart()
    {
        if (!GameManager.instance.breakPart_buy)
        {
            if(GameManager.instance.breakPart_buy_coin <= GameManager.instance.coin)
            {

                GameManager.instance.breakPart_buy = true;
                GameManager.instance.coin -= GameManager.instance.breakPart_buy_coin;
                SetMessage("구매에 성공하였습니다.");
            }
            else
            {
                SetMessage("자금이 부족합니다.");
            }
        }
        else
        {
            SetMessage("이미 구매한 상품입니다.");
        }
    }


    //부품 변경
    public void Were_desrtWheel()
    {
        GameManager.instance.desrtWheel = !GameManager.instance.desrtWheel;
        GameManager.instance.cityWheel = false;
        GameManager.instance.mountainsWheel = false;
        GameManager.instance.CheckStatePart();
        WerePartCheeck(ImgDesrtWheel,GameManager.instance.desrtWheel);
        WerePartCheeck(ImgMountainsWheel, GameManager.instance.mountainsWheel);
        WerePartCheeck(ImgCityWheel, GameManager.instance.cityWheel);
    }

    public void Were_mountainsWheel()
    {
        GameManager.instance.mountainsWheel = !GameManager.instance.mountainsWheel;
        GameManager.instance.cityWheel = false;
        GameManager.instance.desrtWheel= false;
        GameManager.instance.CheckStatePart();
        WerePartCheeck(ImgDesrtWheel, GameManager.instance.desrtWheel);
        WerePartCheeck(ImgMountainsWheel, GameManager.instance.mountainsWheel);
        WerePartCheeck(ImgCityWheel, GameManager.instance.cityWheel);
    }

    public void Were_cityWheel()
    {
        GameManager.instance.cityWheel = !GameManager.instance.cityWheel;
        GameManager.instance.mountainsWheel = false;
        GameManager.instance.desrtWheel = false;
        GameManager.instance.CheckStatePart();
        WerePartCheeck(ImgDesrtWheel, GameManager.instance.desrtWheel);
        WerePartCheeck(ImgCityWheel, GameManager.instance.cityWheel);
        WerePartCheeck(ImgMountainsWheel, GameManager.instance.mountainsWheel);
    }

    public void Were_engine6()
    {
        GameManager.instance.engine6 = !GameManager.instance.engine6;
        GameManager.instance.engine8 = false;
        GameManager.instance.CheckStatePart();
        WerePartCheeck(ImgEngine6, GameManager.instance.engine6);
        WerePartCheeck(ImgEngine8, GameManager.instance.engine8);
    }

    public void Were_engine8()
    {
        GameManager.instance.engine8 = !GameManager.instance.engine8;
        GameManager.instance.engine6 = false;
        GameManager.instance.CheckStatePart();
        WerePartCheeck(ImgEngine6, GameManager.instance.engine6);
        WerePartCheeck(ImgEngine8, GameManager.instance.engine8);
    }

    public void Were_breakPart()
    {
        GameManager.instance.breakPart = !GameManager.instance.breakPart;
        GameManager.instance.CheckStatePart();
        WerePartCheeck(ImgBreakPart, GameManager.instance.breakPart);
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

    public void LoadStage1()
    {
        SceneManager.LoadScene("Stage1");
    }

    public void SetStage()
    {
        SceneManager.LoadScene("StageSet");
    }
}
