using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSetUI : MonoBehaviour
{
    public Image ImgMessage;
    public Text message;

    private void SetMessage(string msg)
    {
        ImgMessage.gameObject.SetActive(true);
        message.text = msg;
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
        if (GameManager.instance.stage2)
        {
            SceneManager.LoadScene("Stage2");
        }
        else
        {
            SetMessage("1스테이지를 먼저 클이어 해주세요.");
        }
    }

    public void LoadStage3()
    {
        if (GameManager.instance.stage3)
        {
            SceneManager.LoadScene("Stage3");
        }
        else
        {
            SetMessage("2스테이지를 먼저 클이어 해주세요.");
        }
    }
}
