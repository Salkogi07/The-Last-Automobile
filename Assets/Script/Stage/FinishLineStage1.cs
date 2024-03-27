using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineStage1 : MonoBehaviour
{
    private UIManager uiManager;
    bool finish = false;
    public int coin;

    private void Awake()
    {
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(!finish)
        {
            if (other.tag == "Player")
            {
                uiManager.FinishGameWin();
                GameManager.instance.coin += coin;
                GameManager.instance.stage2 = true;
                finish = true;
            }
            else
            {
                uiManager.FinishGameLose();
                finish = true;
            }
        }
    }
}
