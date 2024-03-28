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
            SetMessage("1���������� ���� Ŭ�̾� ���ּ���.");
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
            SetMessage("2���������� ���� Ŭ�̾� ���ּ���.");
        }
    }
}
